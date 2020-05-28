using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class RangedEnemy : MonoBehaviour
{
    // Start is called before the first frame update
    protected float health = 50;
    protected float speed;
    protected Rigidbody2D rb;
    protected Player p;

    protected void Start()
    {
      p = GameObject.Find("Player").GetComponent<Player>();
      rb = GetComponent<Rigidbody2D>();
    }
    protected void move(float speed)
    {
      Vector2 dir = (new Vector2(Random.Range(-100, 100), Random.Range(-100, 100)));
      dir.Normalize();
      rb.velocity = dir * speed;
    }
    // Update is called once per frame
    protected void Update()
    {
      if(health <= 0)
      {
        Destroy(this.gameObject);
        Spawner.enemiesAlive--;
        Spawner.enemiesKilled++;
      }
      if(this.name.Contains("(Clone)"))
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
          move(speed);
        }
        r = Random.Range(-50, 50);
        if(r == 0)
        {
          //Debug.Log(r);
          fire();
        }
      }
    }
    public abstract void fire();

    protected void OnCollisionEnter2D (Collision2D col)
    {
      if(col.gameObject.tag.Equals("FriendlyBullet"))
      {
        FriendlyBullet b = col.gameObject.GetComponent<FriendlyBullet>();
        //Debug.Log(col.gameObject.GetComponent<Rigidbody2D>().velocity);
        if(b != null)
        {
          takeDamage(b);
          Destroy(col.gameObject);
        }
      }
      else if(col.gameObject.tag.Equals("Player"))
      {
        die();
      }
    }
    protected void OnTriggerEnter2D(Collider2D col)
    {
      if(col.gameObject.tag.Equals("FriendlyBullet"))
      {
        FriendlyBullet b = col.gameObject.GetComponent<FriendlyBullet>();
        //Debug.Log(col.gameObject.GetComponent<Rigidbody2D>().velocity);
        if(b != null)
        {
          takeDamage(b);
        }
      }
    }
    private void die() {
      Spawner.enemiesAlive--;
      Spawner.enemiesKilled++;
      Destroy(this.gameObject);
    }
    private void takeDamage(FriendlyBullet b) {
      if(b.isSuper()) {
        die();
      }
      else {
        health -= 25;
      }
    }
}
