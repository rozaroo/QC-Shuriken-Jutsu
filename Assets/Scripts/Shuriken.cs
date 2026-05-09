using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shuriken : MonoBehaviour
{
    private float velocity = 3;
    private Rigidbody2D rb2D;
    public AudioSource audioSource;
    public Sprite[] availableSprites;
    public PolygonCollider2D polygonCollider;
    public ShurikenDataPrefab shurikenColliderData;
    void Start() 
    {
        rb2D = GetComponent<Rigidbody2D>();
        Transform spriteChild = transform.Find("ShurikenSprite");
        if (spriteChild != null && ShurikenData.Instance != null)
        {
            int index = ShurikenData.Instance.selectedShurikenIndex;
            SpriteRenderer sr = spriteChild.GetComponent<SpriteRenderer>();
            if (index >= 0 && index < availableSprites.Length)
            {
                sr.sprite = availableSprites[index];
                // Cambiar forma del Polygon Collider
                switch (index)
                {
                    case 0:
                        polygonCollider.SetPath(0, shurikenColliderData.colliderPointsSpriteOne);
                        break;
                    case 1:
                        polygonCollider.SetPath(0, shurikenColliderData.colliderPointsSpriteTwo);
                        break;
                    case 2:
                        polygonCollider.SetPath(0, shurikenColliderData.colliderPointsSpriteThree);
                        break;
                }
            }
        }
    }
    void Update() 
    {
        if (Input.touchCount > 0) 
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began) rb2D.linearVelocity = Vector2.up * velocity;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision) 
    {
        if (collision.gameObject.CompareTag("Floor") || collision.gameObject.CompareTag("Trunk"))
        {
            FindAnyObjectByType<GameManager>().GameOver();
            audioSource.Play();
        }
    }
}

