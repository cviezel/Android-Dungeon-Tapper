using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    // Start is called before the first frame update
    public Player p;
    public float spawnDelay;
    public GameObject enemy;
    public GameObject rangedEnemy;
    public GameObject bomber;
    float nextSpawn = 0;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
      if(Time.time > nextSpawn)
      {
        nextSpawn = Time.time + spawnDelay;
        Vector2 spawnLocation = new Vector2(Random.Range(-80, 80), Random.Range(-50, 50));
        int x = Random.Range(0, 3);
        if(x == 0)
        {
          GameObject e = Instantiate(enemy, spawnLocation, Quaternion.identity) as GameObject;
        }
        else if(x == 1)
        {
          GameObject e = Instantiate(rangedEnemy, spawnLocation, Quaternion.identity) as GameObject;
        }
        else
        {
          GameObject e = Instantiate(bomber, spawnLocation, Quaternion.identity) as GameObject;
        }
      }
    }
}
