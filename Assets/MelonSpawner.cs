using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MelonSpawner : MonoBehaviour
{
    public GameObject melonPrefab; 
    public int minMelons = 5;
    public int maxMelons = 10;
    public BoxCollider2D spawnZone; 
    public LayerMask obstacleLayer;
    public int maxSpawnAttempts = 10; 

    void Start()
    {
        SpawnMelons();
    }

    void SpawnMelons()
    {
        int melonCount = Random.Range(minMelons, maxMelons + 1);

        for (int i = 0; i < melonCount; i++)
        {
            Vector2 spawnPosition;
            int attempts = 0;
            
            do
            {
                spawnPosition = GetRandomPointInZone();
                attempts++;
            } 
            while (Physics2D.OverlapCircle(spawnPosition, 0.5f, obstacleLayer) && attempts < maxSpawnAttempts);
            
            if (attempts < maxSpawnAttempts)
            {
                Instantiate(melonPrefab, spawnPosition, Quaternion.identity);
            }
        }
    }

    Vector2 GetRandomPointInZone()
    {
        if (spawnZone == null)
        {
            Debug.LogError("SpawnZone is not assigned!");
            return Vector2.zero;
        }

        Bounds bounds = spawnZone.bounds;
        float x = Random.Range(bounds.min.x, bounds.max.x);
        float y = Random.Range(bounds.min.y, bounds.max.y);
        return new Vector2(x, y);
    }
}
