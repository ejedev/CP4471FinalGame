using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    //public GameObject[] enemyPrefabs; //array of prefabs you can spawn
    public GameObject enemyPrefab; //debug single prefab
    //public GameObject powerupPrefab; //powerup
    public GameObject player;
    public int enemyCount;
    public int waveNumber = 1;
    public float chickenCost = 0.5f;
    public float gunmanCost = 2.0f;
    //TODO add budget & pick of prefabs



    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemyWave(waveNumber);
        //powerup:          Instantiate(powerupPrefab, GenerateSpawnPosition(), powerupPrefab.transform.rotation);
    }

    void SpawnEnemyWave(int enemiesToSpawn)
    {
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation);
        }
    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;
        //enemyProjectileCount = GameObject.FindGameObjectsWithTag("EnemyProjectile").Length;

        if (enemyCount == 0)
        {
            //powerup:          Instantiate(powerupPrefab, GenerateSpawnPosition(), powerupPrefab.transform.rotation);
            waveNumber++;
            SpawnEnemyWave(waveNumber);
        }
    }

    //must only be called AFTER platforms are created
    //gets list of platforms and generates a spawn location (+0.5 y) above a platform, away from the player
    private Vector3 GenerateSpawnPosition()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        GameObject[] platformArray = GameObject.FindGameObjectsWithTag("Platform");
        Vector3 playerPosition = player.transform.position;
        bool spawnPositionValid = false;
        Vector3 generatedSpawnPosition = new Vector3(0, 0, 0); //default

        while (spawnPositionValid == false)
        {
            GameObject platform = platformArray[Random.Range(0, platformArray.Length)]; //get random platform
            Vector3 boxSize = platform.GetComponent<BoxCollider>().bounds.size; //get box collider
            float platformLeftEdgePosX =  platform.transform.position.x - (0.5f * boxSize.x);
            float platformRightEdgePosX = platform.transform.position.x + (0.5f * boxSize.x);
            float platformUpperEdgePosY = platform.transform.position.y + boxSize.y;

            float spawnPosX = Random.Range(platformLeftEdgePosX, platformRightEdgePosX);

            if (!(player.transform.position.x - spawnPosX <= 1.5) && !(player.transform.position.y - platformUpperEdgePosY <= 1.5)) //if not within 1.5 in either direction
            {
                generatedSpawnPosition = new Vector3(spawnPosX, platformUpperEdgePosY + 0.2f, 0);
                spawnPositionValid = true;

            } else {
                spawnPositionValid = false;
            }
        }

        return generatedSpawnPosition;
    }
}
