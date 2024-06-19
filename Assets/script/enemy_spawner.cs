using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_spawner : MonoBehaviour
{
    public Transform[] spawnPoint;
    public GameObject enemy;
    public float spwanTime = 3f;
    public float curTime;
    Vector3 spwan_pos;

    private void Awake()
    {
        
    }


    private void Update()
    {
        if(curTime >= spwanTime)
        {
            int x = Random.Range(0, spawnPoint.Length);
            SpawnEnemy(x);
        }
        curTime += Time.deltaTime;
    }

    public void SpawnEnemy(int a)
    {
        curTime = 0;
        Instantiate(enemy, spawnPoint[a]);

        
    }
}
