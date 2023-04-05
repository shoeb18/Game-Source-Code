using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] enemy;
    public float respawnTime = 2f;
    public int enemySpawnCount = 10;
    public GameController gameController;
    private bool isLastEnemySpawned = false;

    void Start()
    {
        StartCoroutine(EnemySpawner());
    }

    void Update()
    {
        // if all enemy are spawned and no gameobject is remening in the scene with EnemyScript then level complete
        if (isLastEnemySpawned && FindObjectOfType<EnemyScript>() == null){
            StartCoroutine(gameController.LevelComplete());
        }
    }

    // method that randomly spawn enemy at random x position
    void SpawnEnemy()
    {
        int randomEnemy = Random.Range(0, enemy.Length);
        int randomXpos = Random.Range(-2, 2);
        Instantiate(enemy[randomEnemy], new Vector2(randomXpos, transform.position.y), Quaternion.identity);
    }

    // coroutine with the limited enemy spawner with the help of for loop
    IEnumerator EnemySpawner(){

        for (int i = 0; i < enemySpawnCount;i++)
        {
            yield return new WaitForSeconds(respawnTime);
            SpawnEnemy();
        }

        // it conforms the all enemies are spawned
        isLastEnemySpawned = true;
    }
}