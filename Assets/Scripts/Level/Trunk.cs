using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trunk : MonoBehaviour
{
    public TrunkPool trunkpool;
    
    void Update() 
    {
        transform.position += Vector3.left * trunkpool.speed * Time.deltaTime;
    }
}

