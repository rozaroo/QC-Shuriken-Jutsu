using UnityEngine;

public class FloorManager : MonoBehaviour
{
    public Transform[] floors; // arrastrás los 3 pisos acá
    public float speed = 1.25f;

    private float width;

    void Start()
    {
        width = floors[0].GetComponent<SpriteRenderer>().bounds.size.x;
    }

    
    void Update()
    {
        float leftEdge = Camera.main.transform.position.x - (Camera.main.orthographicSize * Camera.main.aspect);

        foreach (Transform floor in floors)
        {
            floor.position += Vector3.left * speed * Time.deltaTime;

            if (floor.position.x + width < leftEdge)
            {
                Transform rightMost = GetRightMostFloor();

                floor.position = new Vector3(rightMost.position.x + width, floor.position.y, floor.position.z);
            }
        }
    }

    Transform GetRightMostFloor()
    {
        Transform rightMost = floors[0];
        foreach (Transform f in floors)
        {
            if (f.position.x > rightMost.position.x) rightMost = f;
        }
        return rightMost;
    }
}
