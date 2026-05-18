using UnityEngine;

public class TrunkGap : MonoBehaviour
{
    public Transform topTrunk;
    public Transform bottomTrunk;
    private float minGap = 2f;
    private float maxGap = 5f;
    private float centerOffsetRange = 2f;

    public void RandomizeGap()
    {
        Renderer topRenderer = topTrunk.GetComponent<Renderer>();
        Renderer bottomRenderer = bottomTrunk.GetComponent<Renderer>();
        float visibleGap = Random.Range(minGap, maxGap);
        float centerY = Random.Range(-centerOffsetRange, centerOffsetRange);
        float topHeight = topRenderer.bounds.size.y;
        float bottomHeight = bottomRenderer.bounds.size.y;
        float topY = centerY + (visibleGap / 2f) + (topHeight / 2f);
        float bottomY = centerY - (visibleGap / 2f) - (bottomHeight / 2f);
        Vector3 topPos = topTrunk.localPosition;
        Vector3 bottomPos = bottomTrunk.localPosition;
        topPos.y = topY;
        bottomPos.y = bottomY;
        topTrunk.localPosition = topPos;
        bottomTrunk.localPosition = bottomPos;
        float realGap = topRenderer.bounds.min.y - bottomRenderer.bounds.max.y;
        //Debug.Log($"REAL GAP VISIBLE: {realGap}");
    }
}