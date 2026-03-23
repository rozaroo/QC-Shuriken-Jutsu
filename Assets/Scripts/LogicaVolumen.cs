using UnityEngine;
using UnityEngine.UI;

public class LogicaVolumen : MonoBehaviour
{
    public Slider slider;

    void Start()
    {
        float savedVolume = PlayerPrefs.GetFloat("volumenAudio", 0.5f);
        slider.value = savedVolume;
        slider.onValueChanged.AddListener(ChangeSlider);
        ApplyVolume(savedVolume);
    }
    public void ChangeSlider(float valor) 
    {
        PlayerPrefs.SetFloat("volumenAudio", valor);
        PlayerPrefs.Save();
        ApplyVolume(valor);
    }
    private void ApplyVolume(float valor) 
    {
        // Usamos Wwise para controlar el volumen de la música, lo que es más eficiente y profesional que controlar el volumen directamente en Unity. Esto también nos permite tener un control más granular sobre el audio y aplicar efectos si es necesario.
        // Convertir de 0-1 a 0-100 para RTPC Wwise - Wwise generalmente espera valores en un rango de 0 a 100 para RTPCs, así que hacemos la conversión aquí
        float wwiseVolume = valor * 100f;
        AkSoundEngine.SetRTPCValue("MusicVolume", wwiseVolume);
    }
    void OnDestroy()
    {
        // Evita listeners duplicados al recargar escenas
        slider.onValueChanged.RemoveListener(ChangeSlider);
    }
}

