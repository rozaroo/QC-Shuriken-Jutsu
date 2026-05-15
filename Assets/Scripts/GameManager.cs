using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.Threading.Tasks;

public class GameManager : MonoBehaviour
{
    public GameObject gameoverCanvas;
    public Score score;
    public GameObject playerPrefab;
    public Sprite[] shurikenSprites;
    public Transform SpawnPoint;

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
}

