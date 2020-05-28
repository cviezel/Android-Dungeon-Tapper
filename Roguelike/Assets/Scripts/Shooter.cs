using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : RangedEnemy
{
    public GameObject enemyBullets;
    public override void fire()
    {
      Vector2 dir = new Vector2(p.transform.position.x, p.transform.position.y) - (new Vector2(transform.position.x, transform.position.y));
      dir.Normalize();
      GameObject enemyBullet = Instantiate (enemyBullets, transform.position, Quaternion.identity) as GameObject;
      enemyBullet.GetComponent<Rigidbody2D>().velocity = dir * 50;
    }
}
