using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeBall : MonoBehaviour
{
  // Start is called before the first frame update
  float health = 50;
  public float speed;
  public Rigidbody2D rb;
  Player p;
  public GameObject hp;

  float x, y;
  void Start()
  {
    p = GameObject.Find("Player").GetComponent<Player>();
    rb = GetComponent<Rigidbody2D>();
    x = Random.Range(-1f, 1f);
    y = Random.Range(-1f, 1f);
    if(this.name != ("SpikeBall"))
    {
      Vector2 dir = new Vector2(x, y);
      rb.velocity = dir * speed;
    }

    Debug.Log("x is " + x + " y is " + y);
  }
  void moveTowardsPlayer(float speed)
  {
    if(transform.position.x > 85 || transform.position.x < -85)
    {
      x = -x;
      Vector2 dir = new Vector2(x, y);
      speed += 5;
      rb.velocity = dir * speed;
    }
    else if(transform.position.y > 55 || transform.position.y < -55)
    {
      y = -y;
      Vector2 dir = new Vector2(x, y);
      speed += 5;
      rb.velocity = dir * speed;
    }
  }
  // Update is called once per frame
  void Update()
  {
    if(health <= 0)
    {
      int x = Random.Range(0, 2);
      if(x == 0)
      {
        GameObject healthPack = Instantiate (hp, transform.position, Quaternion.identity) as GameObject;
      }
      Spawner.enemiesAlive--;
      Spawner.enemiesKilled++;
      Destroy(this.gameObject);
    }
    if(this.name != ("SpikeBall"))
    {
      transform.Rotate(0, 0, 15);
      if(transform.position.x > 150 || transform.position.x < -150 || transform.position.y > 80 || transform.position.y < -80)
      {
        Destroy(this.gameObject);
        Spawner.enemiesAlive--;
        Spawner.enemiesKilled++;
      }
      moveTowardsPlayer(speed);
    }
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
        //Debug.Log("lost " + dmg + " health");
      }
    }
  }
}
