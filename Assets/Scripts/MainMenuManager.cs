using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class MainMenuManager : MonoBehaviour
{
    public GameObject slider;
    public GameObject ShurikenSelector;
    public GameObject BackButton;
    public GameObject ShowButton;
    public GameObject PlayButton;
    public GameObject VolumeButton;
    public GameObject ExitButton;
    private bool showSlider;
    private bool showShuriken;
    public static MainMenuManager Instance { get; private set; }
    public string userId;
    public GameObject timerDataPrefab;
    public InputActionReference exitAction;


    void OnEnable()
    {
        exitAction.action.Enable();
        exitAction.action.performed += OnExitPerformed;
    }
    void OnDisable()
    {
        exitAction.action.performed -= OnExitPerformed;
        exitAction.action.Disable();
    }
    private void Awake()
    {
        //if (Instance == null)
        //{
            //Instance = this;
            //DontDestroyOnLoad(gameObject); // Solo si quieres que persista
        //}
        //else
        //{
            //Destroy(gameObject);
            //return;
        //}
        if (PlayerPrefs.HasKey("UserId")) userId = PlayerPrefs.GetString("UserId");
        else
        {
            userId = Guid.NewGuid().ToString();
            PlayerPrefs.SetString("UserId", userId);
        }
    }

    private async void Start()
    {
        if (FindObjectOfType<PersistantTimerData>() == null) Instantiate(timerDataPrefab);
        showSlider = false;
        showShuriken = false;
    }
    public void QuitGame()
    {
        if (PersistantTimerData.Instance != null)
        {
            PersistantTimerData.Instance.UploadData();
            Application.Quit();
        }
        else Application.Quit();
    }
    private void OnExitPerformed(InputAction.CallbackContext context)
    {
        QuitGame();
    }
    public void Play()
    {
        SceneManager.LoadScene(1);
    }
    public void ShowVolumeSlider()
    {
        showSlider = !showSlider;
        slider.SetActive(showSlider);
    }
    public void ShowShurikens()
    {
        ShurikenSelector.SetActive(true);
        PlayButton.SetActive(false);
        VolumeButton.SetActive(false);
        ExitButton.SetActive(false);
        BackButton.SetActive(true);
        ShowButton.SetActive(false);
    }
    public void Back()
    {
        ShurikenSelector.SetActive(false);
        PlayButton.SetActive(true);
        VolumeButton.SetActive(true);
        ExitButton.SetActive(true);
        BackButton.SetActive(false);
        ShowButton.SetActive(true);
    }
    private IEnumerator QuitAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        Application.Quit();
    }
}
