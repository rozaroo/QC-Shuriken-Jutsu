using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrunkScore : MonoBehaviour
{
    private Collider2D col;

    void Awake()
    {
        col = GetComponent<Collider2D>();
    }

    private void OnEnable()
    {
        col.enabled = true;
    }
    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if (collision.CompareTag("Player"))
        {
            FindAnyObjectByType<Score>().UpdateScore();
            col.enabled = false;
        }
    }
}

