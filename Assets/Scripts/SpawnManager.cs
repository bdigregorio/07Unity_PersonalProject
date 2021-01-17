using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour{
    public GameObject powerupPrefab;
    public GameObject ringPrefab;

    public float spawnDelayRing;
    public float spawnIntervalRing;
    public float spawnDelayPowerup;
    public float spawnIntervalPowerup;
    
    private float xBounds = 3.25f;
    private float yMinBounds = -1.25f;
    private float yMaxBounds = 2.25f;
    private float zSpawnPos = 50.0f;


    private void Start() {
        InvokeRepeating(nameof(SpawnRandomRing), spawnDelayRing, spawnIntervalRing);
        InvokeRepeating(nameof(SpawnRandomPowerup), spawnDelayPowerup, spawnIntervalPowerup);
    }

    private void Update() {
        
    }

    private void SpawnRandomRing() {
        float randomXPos = Random.Range(-xBounds, xBounds);
        float randomYPos = Random.Range(yMinBounds, yMaxBounds);
        Vector3 randomSpawnPosition = new Vector3(randomXPos, randomYPos, zSpawnPos);
        Quaternion spawnRotation = powerupPrefab.transform.rotation;
        Instantiate(ringPrefab, randomSpawnPosition, spawnRotation);
    }

    private void SpawnRandomPowerup() {
        float randomXPos = Random.Range(-xBounds, xBounds);
        float randomYPos = Random.Range(yMinBounds, yMaxBounds);
        Vector3 randomSpawnPosition = new Vector3(randomXPos, randomYPos, zSpawnPos);
        Quaternion spawnRotation = powerupPrefab.transform.rotation;
        Instantiate(powerupPrefab, randomSpawnPosition, spawnRotation);
    }
}
