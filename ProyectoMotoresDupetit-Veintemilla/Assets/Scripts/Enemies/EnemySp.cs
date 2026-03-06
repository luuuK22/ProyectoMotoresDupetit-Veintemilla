using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//TP FINAL - MATEO DUPETIT
public class EnemySp : MonoBehaviour
{
    [SerializeField] private List<GameObject> enemyPrefabs;

    [SerializeField] private int maxEnemies = 50;

    [SerializeField] private float spawnRate = 2f;

    private float timer;

    public int MaxEnemies
    {
        get { return maxEnemies; }
        set { maxEnemies = Mathf.Clamp(value, 1, 200); }
    }

    void Update()
    {
        timer += Time.deltaTime;

        int enemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;

        if (timer >= spawnRate && enemyCount < MaxEnemies)
        {
            SpawnEnemy();
            timer = 0;
        }
    }

    void SpawnEnemy()
    {
        int random = Random.Range(0, enemyPrefabs.Count);

        Instantiate(enemyPrefabs[random], transform.position, Quaternion.identity);
    }
}
