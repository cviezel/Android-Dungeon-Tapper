using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    // Start is called before the first frame update
    public Player p;
    public float spawnDelay;
    public GameObject enemy;
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
        Vector2 spawnLocation = new Vector2(Random.Range(-100, 100), Random.Range(-100, 100));
        GameObject e = Instantiate(enemy, spawnLocation, Quaternion.identity) as GameObject;
      }
    }
}
