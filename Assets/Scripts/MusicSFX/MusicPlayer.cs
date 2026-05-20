using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    public static MusicPlayer Instance;
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }
    void Start()
    {
        uint bankID;
        AkSoundEngine.LoadBank("Main", out bankID);
        AkSoundEngine.SetRTPCValue("MusicVolume", 50f);
        AkSoundEngine.PostEvent("Play_Music", gameObject);
    }
    private void OnApplicationFocus(bool hasFocus)
    {
        if (!hasFocus) AkSoundEngine.Suspend();
        else AkSoundEngine.WakeupFromSuspend();
    }
    //private void OnApplicationPause(bool pauseStatus)
    //{
    //    if (pauseStatus) AkSoundEngine.Suspend();
    //    else AkSoundEngine.WakeupFromSuspend();
    //}
}

