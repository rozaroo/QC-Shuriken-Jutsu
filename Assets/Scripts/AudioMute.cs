using UnityEngine;
using UnityEngine.UI;

public class AudioMute : MonoBehaviour
{
    public Image buttonImage;
    // Sprites para indicar el estado de la música - En lugar de activar/desactivar botones, cambiamos el sprite del botón para reflejar el estado actual
    public Sprite musicOnSprite;
    public Sprite musicOffSprite;
    private bool muted;

    void Start()
    {
        //Cargar estado guardado
        muted = PlayerPrefs.GetInt("Muted",0) == 1;
        ApplyState();
    }
    public void Mute() 
    {
        muted = !muted;
        //Guardar estado
        PlayerPrefs.SetInt("Muted", muted ? 1 : 0);
        PlayerPrefs.Save();
        ApplyState();
    }
    private void ApplyState() 
    {
        // Cambiar el estado de la música en Wwise y actualizar el sprite del botón - Usamos estados de Wwise para controlar la música, lo que es más eficiente, profesional y limpio
        if (muted) 
        {
            AkSoundEngine.SetState("MusicState", "MusicOff");
            buttonImage.sprite = musicOffSprite;
        }
        else
        {
            AkSoundEngine.SetState("MusicState", "MusicOn");
            buttonImage.sprite = musicOnSprite;
        }
    }
}

