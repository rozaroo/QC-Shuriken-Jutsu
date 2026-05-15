using System.Collections.Generic;
using UnityEngine;

public class TrunkPool : MonoBehaviour
{
    public GameObject trunkPrefab;
    public int poolSize = 10;
    private List<GameObject> trunkPool = new List<GameObject>();
    private float heightRange = 1.5f;
    public float minSpawnTime = 3f;
    public float maxSpawnTime = 5f;
    private float currentSpawnTime;
    private float timer;
    public SpeedEnviroment speedEnviroment;
    public Score score;
    private int lastScoreThreshold = 0;
    public float speed;

    void Start()
    {
        speed = speedEnviroment.Speed[0];
        CreatePool();
        SetRandomSpawnTime();
        SpawnTrunk();
    }

    void Update()
    {
        int currentScore = score.GetCurrentScore(); 
        if (currentScore >= lastScoreThreshold + 10) 
        { 
            speed *= 1.5f; 
            lastScoreThreshold = currentScore; 
        }
        timer += Time.deltaTime;
        if (timer > currentSpawnTime)
        {
            SpawnTrunk();
            timer = 0;
            SetRandomSpawnTime();
        }
    }
    void SetRandomSpawnTime()
    {
        float speedMultiplier = speed;
        float adjustedMin = Mathf.Max(0.8f, minSpawnTime / speedMultiplier);
        float adjustedMax = Mathf.Max(1.5f, maxSpawnTime / speedMultiplier);
        currentSpawnTime = Random.Range(adjustedMin, adjustedMax);
    }
    void CreatePool()
    {
        for (int i = 0; i < poolSize; i++)
        {
            GameObject trunk = Instantiate(trunkPrefab);
            Trunk trunkScript = trunk.GetComponent<Trunk>();
            trunkScript.trunkpool = this;
            trunk.SetActive(false);
            trunkPool.Add(trunk);
        }
    }

    public void SpawnTrunk()
    {
        GameObject trunk = GetPooledTrunk();
        if (trunk == null) return;
        Vector3 spawnPosition = transform.position + new Vector3(0, Random.Range(-heightRange, heightRange));
        trunk.transform.position = spawnPosition;
        trunk.transform.rotation = Quaternion.identity;
        trunk.SetActive(true);
    }

    GameObject GetPooledTrunk()
    {
        foreach (GameObject trunk in trunkPool)
            if (!trunk.activeInHierarchy) return trunk;
        return null;
    }
}
