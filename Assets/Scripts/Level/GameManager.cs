using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using TMPro;
using System.Threading.Tasks;

public class GameManager : MonoBehaviour
{
    public GameObject gameoverCanvas;
    public Score score;
    public GameObject playerPrefab;
    public Sprite[] shurikenSprites;
    public Transform SpawnPoint;
    public Transform pauseMenuTransform;
    public InputActionReference pauseAction;
    private bool isPaused;

    void OnEnable() 
    {
        pauseAction.action.Enable();
        pauseAction.action.performed += TogglePause;
    }
    void OnDisable() 
    {
        pauseAction.action.performed -= TogglePause;
        pauseAction.action.Disable();
    }
    void Start() 
    {
        Time.timeScale = 1;
        PlayerPrefs.GetInt("BestScore", 0).ToString();
        int selectedIndex = PlayerPrefs.GetInt("SelectedShuriken", 0);
        GameObject player = Instantiate(playerPrefab, SpawnPoint.position, Quaternion.identity);
        Transform shurikenChild = player.transform.Find("ShurikenSprite");
        if (shurikenChild != null)
        {
            SpriteRenderer sr = shurikenChild.GetComponent<SpriteRenderer>();
            sr.sprite = shurikenSprites[selectedIndex];
        }
    }
    public async Task GameOver() 
    {
        gameoverCanvas.SetActive(true);
        Time.timeScale = 0;
        int currentScore = score.GetCurrentScore();
    }
    public void Restart() 
    {
        SceneManager.LoadScene(1);
    }
    public void MainMenu() 
    {
        SceneManager.LoadScene(0);
    }
    //Pausa
    private void TogglePause(InputAction.CallbackContext context) 
    {
        isPaused = !isPaused;
        if (isPaused) ShowPauseMenu();
        else HidePauseMenu();
    }
    public void ShowPauseMenu()
    {
        pauseMenuTransform.gameObject.SetActive(true);
        StartCoroutine(ShowPauseCoroutine());
    }
    private IEnumerator ShowPauseCoroutine()
    {
        yield return StartCoroutine(ScaleOverTime(pauseMenuTransform,Vector3.zero, Vector3.one, 0.2f));
        Time.timeScale = 0f;
    }
    public void HidePauseMenu()
    {
        Time.timeScale = 1f;
        StartCoroutine(HidePauseCoroutine());
    }
    private IEnumerator HidePauseCoroutine()
    {
        yield return StartCoroutine(ScaleOverTime(pauseMenuTransform, pauseMenuTransform.localScale, Vector3.zero, 0.2f));
        pauseMenuTransform.gameObject.SetActive(false);
    }
    private IEnumerator ScaleOverTime(Transform target, Vector3 from, Vector3 to, float duration)
    {
        float t = 0f;
        target.localScale = from;
        while (t < duration)
        {
            t += Time.unscaledDeltaTime;
            float factor = t / duration;
            target.localScale = Vector3.Lerp(from, to, factor);
            yield return null;
        }
        target.localScale = to;
    }
}

