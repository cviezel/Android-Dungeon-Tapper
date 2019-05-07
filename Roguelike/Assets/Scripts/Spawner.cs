using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    // Start is called before the first frame update
    public Player p;
    float spawnDelay = 1;
    public GameObject enemy;
    public GameObject rangedEnemy;
    public GameObject bomber;
    float nextSpawn = 0;
    int enemiesKilled = 0;
    int roundNum = 0;
    bool roundFlag = true;
    public static int enemiesAlive = 0;
    int enemyLimit = 10;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
      if(enemiesKilled > 10 + roundNum * 10)
      {
        roundFlag = false;
        //make button show up to choose next round
        //choose increased beam attacks, increased attack speed, or increased health
        spawnDelay -= 0.05f;
        enemyLimit += 2;
      }
      Debug.Log(enemiesAlive);
      if(Time.time > nextSpawn && roundFlag && enemiesAlive < enemyLimit)
      {
        nextSpawn = Time.time + spawnDelay;
        Vector2 spawnLocation = new Vector2(Random.Range(-80, 80), Random.Range(-50, 50));
        int x = Random.Range(0, 3);
        if(x == 0)
        {
          enemiesAlive++;
          enemiesKilled++;
          GameObject e = Instantiate(enemy, spawnLocation, Quaternion.identity) as GameObject;
        }
        else if(x == 1)
        {
          enemiesAlive++;
          enemiesKilled++;
          GameObject e = Instantiate(rangedEnemy, spawnLocation, Quaternion.identity) as GameObject;
        }
        else
        {
          enemiesAlive++;
          enemiesKilled++;
          GameObject e = Instantiate(bomber, spawnLocation, Quaternion.identity) as GameObject;
        }
      }
    }
}
