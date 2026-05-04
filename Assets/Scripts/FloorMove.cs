using UnityEngine;

public class FloorMove : MonoBehaviour
{
    private float speed = 1.25f;
    private float width;
    private float startPos;
    public SpriteRenderer SpriteRenderer;

    void Start()
    {
        width = SpriteRenderer.bounds.size.x;
        startPos = transform.position.x;
    }

    void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;
        if (transform.position.x <= startPos - width) transform.position += Vector3.right * width * 2;
        
    }
}

