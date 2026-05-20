using UnityEngine;

public class TrunkDisable : MonoBehaviour
{
    private float lifeTime = 10f;
    private void OnEnable()
    {
        CancelInvoke();
        Invoke(nameof(DisableTrunk), lifeTime);
    }
    void DisableTrunk()
    {
        gameObject.SetActive(false);
    }
}