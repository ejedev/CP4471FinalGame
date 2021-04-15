using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class SpawnManager : MonoBehaviour
{
    public GameObject placeHolderEnemy;
    public Text levelValue;
    private int currentLevel = 1;
    private int spawnAmount = 1;
    private int spawnedEnemies = 0;
    
    //All locations are X,Y
    float[,] possibleSpawnLocations = new float[,] {{4.5f,3},{-4.5f,3},{7,3},{-7,3},{6,2},{-6,2},{3,2},{-3,2},{4,6.83f},{-4,6.83f}};
    
    // Start is called before the first frame update
    void Start()
    {
        levelValue.text = currentLevel.ToString();
        StartCoroutine(EnemySpawner());
    }
    
    IEnumerator EnemySpawner(){
        while(true)
        {
            if (spawnedEnemies < spawnAmount)
            {
                Debug.Log("Enemy spawned.");
                int selectedPostion = Random.Range(0, (possibleSpawnLocations.Length - 1) / 2);
                Debug.Log(selectedPostion + " ," + possibleSpawnLocations.Length);
                Instantiate(placeHolderEnemy,
                    new Vector3(possibleSpawnLocations[selectedPostion, 0], possibleSpawnLocations[selectedPostion, 1],
                        0), Quaternion.identity);
                spawnedEnemies += 1;
            }
            else
            {
                Debug.Log("Enemy not spawned.");
            }
            yield return new WaitForSeconds(5);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (spawnedEnemies == spawnAmount && GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
        {
            Debug.Log("Conditions met for new level.");
            currentLevel += 1;
            spawnedEnemies = 0;
            spawnAmount = currentLevel;
            levelValue.text = currentLevel.ToString();
        }
        else
        {
            Debug.Log("Conditions not met for new level.");
        }
    }
}
