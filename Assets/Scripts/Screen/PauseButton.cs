using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class PauseButton : MonoBehaviour
{
    public Image buttonImage;
    public Sprite pauseSprite;
    public Sprite resumeSprite;
    public GameManager gameManager;
    private bool paused;

    void Start()
    {
        ApplyState();
    }

    public void TogglePause()
    {
        paused = !paused;
        ApplyState();
    }

    void ApplyState()
    {
        if (paused) Show();
        else Hide();
    }
    
    void Show()
    {
        gameManager.ShowPauseMenu();
        buttonImage.sprite = resumeSprite;
    }
    void Hide()
    {
        gameManager.HidePauseMenu();
        buttonImage.sprite = pauseSprite;
    }
}
