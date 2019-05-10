using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spawner : MonoBehaviour
{
    // Start is called before the first frame update
    public Player p;
    float spawnDelay = 1;
    public GameObject enemy;
    public GameObject rangedEnemy;
    public GameObject bomber;
    float nextSpawn = 0;
    public static int enemiesKilled = 0;
    int roundNum = 1;
    public static bool roundFlag = true;
    public static int enemiesAlive = 0;
    int enemyLimit = 10;
    public Text txtRoundNum;
    public Text txtEnemiesLeft;
    int enemiesThisRound = 10;

    public GameObject perk1;
    public GameObject perk2;
    public GameObject perk3;
    public GameObject perk4;


    void Start()
    {
      txtRoundNum.text = "Round: " + roundNum.ToString();
      txtEnemiesLeft.text = "Enemies Left: " + enemiesThisRound.ToString();
    }

    // Update is called once per frame
    void Update()
    {
      txtEnemiesLeft.text = "Enemies Left: " + (enemiesThisRound - enemiesKilled).ToString();
      if(enemiesKilled >= enemiesThisRound && roundFlag) //newRound
      {
        roundFlag = false;
        //make button show up to choose next round
        //choose increased beam attacks, increased attack speed, or increased health
        spawnDelay -= 0.05f;
        enemyLimit += 2;

        roundNum++;
        enemiesThisRound = (roundNum * 10);

        txtRoundNum.text = "Round: " + roundNum.ToString();
        txtEnemiesLeft.text = "Enemies Left: " + enemiesThisRound.ToString();
        enemiesKilled = 0;

        for(int i = 0; i < 100000000; i++);

        GameObject p1 = Instantiate (perk1, new Vector3(-60, 0, 0), Quaternion.identity) as GameObject;
        GameObject p2 = Instantiate (perk2, new Vector3(-20, 0, 0), Quaternion.identity) as GameObject;
        GameObject p3 = Instantiate (perk3, new Vector3(20, 0, 0), Quaternion.identity) as GameObject;
        GameObject p4 = Instantiate (perk4, new Vector3(60, 0, 0), Quaternion.identity) as GameObject;

        //Debug.Log(enemiesThisRound);
      }
      //Debug.Log(enemiesAlive);
      if(Time.time > nextSpawn && roundFlag && (enemiesAlive < enemyLimit) && ((enemiesThisRound - enemiesKilled - enemiesAlive) > 0))
      {
        nextSpawn = Time.time + spawnDelay;
        Vector2 spawnLocation = new Vector2(Random.Range(-80, 80), Random.Range(-50, 50));
        int x = Random.Range(0, 3);
        if(x == 0)
        {
          enemiesAlive++;
          GameObject e = Instantiate(enemy, spawnLocation, Quaternion.identity) as GameObject;
        }
        else if(x == 1)
        {
          enemiesAlive++;
          GameObject e = Instantiate(rangedEnemy, spawnLocation, Quaternion.identity) as GameObject;
        }
        else
        {
          enemiesAlive++;
          GameObject e = Instantiate(bomber, spawnLocation, Quaternion.identity) as GameObject;
        }
      }
    }
}
