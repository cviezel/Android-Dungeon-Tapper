using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mage : RangedEnemy
{
    public GameObject enemyBullets;
    // Start is called before the first frame update
    public override void fire()
    {
      GameObject enemyBullet = Instantiate (enemyBullets, new Vector2(Random.Range(-80f, 80f), 80f), Quaternion.identity) as GameObject;
    }
    
}
