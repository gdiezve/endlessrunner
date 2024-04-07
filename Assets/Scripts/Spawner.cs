using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject enemy;
    [SerializeField] GameObject trash;
    [SerializeField] GameObject wave;
    [SerializeField] float spawnRate = 2; // every 2 seconds an object will be spawned
    private const float screenOffLimit = 2f;
    private GameObject enemyClone;
    private GameObject trashClone;
    private GameObject waveClone;
    public ScoreManager scoreManager;
    private int changeSpeedScore = 10;
    void Start()
    {
        InvokeRepeating(nameof(SpawnEnemy), 0f, spawnRate);
        InvokeRepeating(nameof(SpawnTrash), 1f, spawnRate);
        InvokeRepeating(nameof(SpawnWave), 0.5f, spawnRate - 1);
    }

    private void SpawnObject(GameObject obj) {
        GameObject clone;
        clone = Instantiate(obj, transform.position, Quaternion.identity);
        clone.transform.position = GetNewPosition();
        if (scoreManager.GetScore() == changeSpeedScore) {
            spawnRate += .5f;
            changeSpeedScore += 10;
        }
    }
    private Vector3 GetNewPosition() {
        Vector3 newPosition = transform.position;
        newPosition.x += Random.Range(-screenOffLimit, +screenOffLimit);
        return newPosition;
    }

    void SpawnEnemy() {
        SpawnObject(enemy);
    }

    void SpawnTrash() {
        SpawnObject(trash);
    }

    void SpawnWave() {
       SpawnObject(wave);
    }

    
}
