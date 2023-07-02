using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SpawnManager : MonoBehaviour {

    // Spawn location vars
    public Vector3 center;
    public Vector3 size;


    // PickUp Vars
    public GameObject pickUpPrefab;
    public float puSpawnTime = 3f;
    public int initPickUps = 0;
    public float puLifeTime = 20f;

    // Enemy Vars
    public GameObject enemyPrefab;
    public float enSpawnTime = 10f;
    public int initEnemies = 0;
    public int enAlive;
    public bool enIsSpawning;
    

    // Access Scripts
    public PlayerHealth playerHealth;
    
    

    // Use this for initialization
    void Start ()
    {
        for (initPickUps = 0; initPickUps < 3; initPickUps++)
            SpawnPickUp();
        InvokeRepeating("SpawnPickUp", puSpawnTime, puSpawnTime);

        enAlive = 0;
        enIsSpawning = false;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (ScoreManager.score < 50)
        {
            return;
        }

        if (ScoreManager.score >= 50 && enAlive <= 0)
        {
            for (initEnemies = 0; initEnemies < 5; initEnemies++)
                SpawnEnemies();
            
        }
        
    }

    public void SpawnPickUp()
    {
        if(playerHealth.currentHealth <= 0f)
        {
            return;
        }

        Vector3 pos = center + new Vector3(Random.Range(-size.x / 2 , size.x / 2), Random.Range(-size.y / 2, size.y / 2), Random.Range(-size.z / 2, size.z / 2));

        //Instantiate(pickUpPrefab, pos, Quaternion.identity);
        
    }

    public void SpawnEnemies()
    {
        if (playerHealth.currentHealth <= 0f)
        {
            return;
        }

        Vector3 pos = center + new Vector3(Random.Range(-size.x / 2, size.x / 2), Random.Range(-size.y / 2, size.y / 2), Random.Range(-size.z / 2, size.z / 2));

        Instantiate(enemyPrefab, pos, Quaternion.identity);
        
        enAlive = enAlive + 1;
        

        
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(0, 1, 0, 0.1f);
        Gizmos.DrawCube(transform.localPosition + center, size);
    }
}
