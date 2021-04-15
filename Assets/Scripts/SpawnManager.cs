using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnManager : MonoBehaviour
{
    public GameObject placeHolderEnemy;
    
    //All locations are X,Y
    float[,] possibleSpawnLocations = new float[,] {{4.5f,3},{-4.5f,3},{7,3},{-7,3},{6,2},{-6,2},{3,2},{-3,2},{4,6.83f},{-4,6.83f}};
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(EnemySpawner());
    }
    
    IEnumerator EnemySpawner(){
        while(true)
        {
            int selectedPostion = Random.Range(0, (possibleSpawnLocations.Length-1)/2);
            Debug.Log(selectedPostion + " ," + possibleSpawnLocations.Length);
            Instantiate(placeHolderEnemy, new Vector3(possibleSpawnLocations[selectedPostion,0], possibleSpawnLocations[selectedPostion,1], 0), Quaternion.identity);
            yield return new WaitForSeconds(5);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
