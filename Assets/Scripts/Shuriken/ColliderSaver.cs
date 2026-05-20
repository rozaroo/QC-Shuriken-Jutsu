using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class ColliderSaver : MonoBehaviour
{
    public PolygonCollider2D polygonCollider;

    public ShurikenDataPrefab data;

    void Start()
    {
        SavePoints();
    }
    [ContextMenu("Save Points")]
    void SavePoints()
    {
        data.colliderPointsSpriteThree = polygonCollider.points;

#if UNITY_EDITOR
        EditorUtility.SetDirty(data);
        AssetDatabase.SaveAssets();
#endif

        Debug.Log("Points saved!");
    }
}
