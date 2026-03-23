using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class PauseButton : MonoBehaviour
{
    // Este script se encarga de pausar el juego y aplicar un efecto visual de post-procesado para indicar que el juego está en pausa.
    // El volumen de post-procesado para el efecto de pausa
    public Volume volume;
    private ColorAdjustments color;
    private bool isPaused = false;
    void Start()
    {
        volume.profile.TryGet(out color);
    }

    public void TogglePause()
    {
        isPaused = !isPaused;
        if (isPaused)
        {
            Time.timeScale = 0f;
            color.postExposure.value = -3f;
        }
        else
        {
            Time.timeScale = 1f;
            color.postExposure.value = 0f;
        }
    }
}
