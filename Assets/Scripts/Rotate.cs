using UnityEngine;

public class Rotate : MonoBehaviour
{
    private float rotationSpeed = 360f;
    public Rigidbody2D rb;
    void FixedUpdate()
    {
        rb.MoveRotation(rb.rotation + rotationSpeed * Time.fixedDeltaTime);
    }
}
