using UnityEngine;

public class ColliderPointExtractor : MonoBehaviour
{
    public PolygonCollider2D poly;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        PrintPoints();
    }
    [ContextMenu("Print Collider Points")]
    void PrintPoints()
    {
        Vector2[] points = poly.points;

        string result = "";

        foreach (Vector2 point in points)
        {
            result += $"new Vector2({point.x}f, {point.y}f),\n";
        }

        Debug.Log(result);
    }
}
