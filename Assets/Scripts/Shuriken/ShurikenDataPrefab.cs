using UnityEngine;

[CreateAssetMenu(fileName = "ShurikenDataPrefab", menuName = "Scriptable Objects/ShurikenDataPrefab")]
public class ShurikenDataPrefab : ScriptableObject
{
    public Vector2[] colliderPointsSpriteOne;
    public Vector2[] colliderPointsSpriteTwo;
    public Vector2[] colliderPointsSpriteThree;
}
