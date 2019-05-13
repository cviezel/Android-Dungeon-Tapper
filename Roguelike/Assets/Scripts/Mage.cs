using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mage : MonoBehaviour
{
    // Start is called before the first frame update
    float health = 50;
    public GameObject enemyBullets;
    public float speed;
    public Rigidbody2D rb;
    Player p;
    void Start()
    {
      p = GameObject.Find("Player").GetComponent<Player>();
      rb = GetComponent<Rigidbody2D>();
    }
    void move(float speed)
    {
      Vector2 dir = (new Vector2(Random.Range(-100, 100), Random.Range(-100, 100)));
      dir.Normalize();
      rb.velocity = dir * speed;
    }
    void moveTowardsPlayer(float speed)
    {
      Vector2 dir = new Vector2(p.transform.position.x, p.transform.position.y) - (new Vector2(transform.position.x, transform.position.y));
      dir.Normalize();
      rb.velocity = dir * speed;
      /*
      Vector2 target = new Vector2(p.transform.position.x, p.transform.position.y);
      float step = speed * Time.deltaTime;
      transform.position = Vector2.MoveTowards(transform.position, target, step);
      */

    }
    // Update is called once per frame
    void Update()
    {
      if(health <= 0)
      {
        Destroy(this.gameObject);
        Spawner.enemiesAlive--;
        Spawner.enemiesKilled++;
      }
      if(this.name != "Mage")
      {
        if(transform.position.x > 100 || transform.position.x < -100 || transform.position.y > 60 || transform.position.y < -60)
        {
          Destroy(this.gameObject);
          Spawner.enemiesAlive--;
          Spawner.enemiesKilled++;
        }
        //move(speed);
        int r = Random.Range(-20, 20);
        if(r == 0)
        {
          //Debug.Log(r);
          move(3);
        }
        r = Random.Range(-50, 50);
        if(r == 0)
        {
          //Debug.Log(r);
          fire();
        }
      }
    }
    void fire()
    {
      GameObject enemyBullet = Instantiate (enemyBullets, new Vector2(Random.Range(-80f, 80f), 80f), Quaternion.identity) as GameObject;
    }
    void OnCollisionEnter2D (Collision2D col)
    {
      if(col.gameObject.tag.Equals("FriendlyBullet"))
      {
        FriendlyBullet b = col.gameObject.GetComponent<FriendlyBullet>();
        //Debug.Log(col.gameObject.GetComponent<Rigidbody2D>().velocity);
        if(b != null)
        {
          float dmg = b.getSpeed() / 5;
          health -= dmg;
          //Debug.Log("lost " + dmg + " health");
          Destroy(col.gameObject);
        }
      }
      else if(col.gameObject.tag.Equals("Player"))
      {
        Spawner.enemiesAlive--;
        Spawner.enemiesKilled++;
        Destroy(this.gameObject);
      }
    }
    void OnTriggerEnter2D(Collider2D col)
    {
      if(col.gameObject.tag.Equals("FriendlyBullet"))
      {
        FriendlyBullet b = col.gameObject.GetComponent<FriendlyBullet>();
        //Debug.Log(col.gameObject.GetComponent<Rigidbody2D>().velocity);
        if(b != null)
        {
          float dmg = b.getSpeed() / 5;
          health -= dmg;
          Debug.Log("lost " + dmg + " health");
        }
      }
    }
}
