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
        AkSoundEngine.PostEvent("Play_Music", gameObject);
    }
}

