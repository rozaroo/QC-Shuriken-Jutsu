using UnityEngine;

public class AudioInit : MonoBehaviour
{
    void Start()
    {
        uint bankID;
        AkSoundEngine.LoadBank("Main", out bankID);
    }
}

