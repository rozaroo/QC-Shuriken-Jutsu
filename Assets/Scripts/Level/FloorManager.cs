using UnityEngine;

public class FloorManager : MonoBehaviour, ICustomUpdate
{
    public Transform[] floors; // arrastrás los 3 pisos acá
    //public float speed = 1.25f;
    public SpeedEnviroment speedEnviroment;
    private float width;
    public Score score;
    private int lastScoreThreshold = 0;
    private float speed;

    void Start()
    {
        width = floors[0].GetComponent<SpriteRenderer>().bounds.size.x;
        speed = speedEnviroment.Speed[0];
    }

    public void OnCustomUpdate()
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
        int currentScore = score.GetCurrentScore();
        if (currentScore >= lastScoreThreshold + 10)
        {
            speed *= 1.5f;
            lastScoreThreshold = currentScore;
        }
    }
    void OnEnable()
    {
        CustomUpdateManager.Register(this);
    }

    void OnDisable()
    {
        CustomUpdateManager.Unregister(this);
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
