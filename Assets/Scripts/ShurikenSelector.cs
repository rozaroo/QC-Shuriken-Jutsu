using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ShurikenSelector : MonoBehaviour
{
    public MainMenuManager menu;
    public Image[] shurikenButtonImages;
    private int ShurikenOneCount = 0;
    private int ShurikenTwoCount = 0;
    private int ShurikenThreeCount = 0;
    
    public void SelectShuriken(int index) 
    {
        if (ShurikenData.Instance != null) ShurikenData.Instance.selectedShurikenIndex = index;
        StartCoroutine(ButtonFlash(shurikenButtonImages[index]));
        //Enviar evento a Analytics
        string userId = menu.userId;
        if (ShurikenData.Instance.selectedShurikenIndex == 0) 
        {
            ShurikenOneCount++;
            Debug.Log($"[ShurikenSelector] Usuario: {userId} seleccionó el shuriken #{index}, {ShurikenOneCount} veces");
            AnalyticsManager.Instance.ShurikenSelected(index, userId, ShurikenOneCount);
        }
        if (ShurikenData.Instance.selectedShurikenIndex == 1)
        {
            ShurikenTwoCount++;
            Debug.Log($"[ShurikenSelector] Usuario: {userId} seleccionó el shuriken #{index}, {ShurikenTwoCount} veces");
            AnalyticsManager.Instance.ShurikenSelected(index, userId, ShurikenTwoCount);
        }
        if (ShurikenData.Instance.selectedShurikenIndex == 2)
        {
            ShurikenThreeCount++;
            Debug.Log($"[ShurikenSelector] Usuario: {userId} seleccionó el shuriken #{index}, {ShurikenThreeCount} veces");
            AnalyticsManager.Instance.ShurikenSelected(index, userId, ShurikenThreeCount);
        }
    }
    IEnumerator ButtonFlash(Image buttonImage)
    {
        Color originalColor = buttonImage.color;
        buttonImage.color = Color.gray;
        yield return new WaitForSeconds(0.15f);
        buttonImage.color = originalColor;
    }
}

