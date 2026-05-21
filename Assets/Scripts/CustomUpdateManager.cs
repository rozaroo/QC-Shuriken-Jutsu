using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CustomUpdateManager : MonoBehaviour
{
    private static List<ICustomUpdate> updatables = new();

    void Update()
    {
        for (int i = 0; i < updatables.Count; i++)
            updatables[i].OnCustomUpdate();   
    }
    public static void Register(ICustomUpdate updatable)
    {
        if (!updatables.Contains(updatable)) updatables.Add(updatable);
    }

    public static void Unregister(ICustomUpdate updatable)
    {
        if (updatables.Contains(updatable)) updatables.Remove(updatable);
    }
}

