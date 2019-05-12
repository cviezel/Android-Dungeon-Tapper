using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostKing : MonoBehaviour
{
  // Start is called before the first frame update
  float health = 200 + (Spawner.roundNum / 4) * 50;
  public float speed;
  public Rigidbody2D rb;
  Player p;
  public GameObject hp;
  public GameObject ghost;
  public AudioSource spooky;
  public AudioSource bg;


  float x, y;
  void Start()
  {
    p = GameObject.Find("Player").GetComponent<Player>();
    rb = GetComponent<Rigidbody2D>();
    x = Random.Range(-1f, 1f);
    y = Random.Range(-1f, 1f);
    if(this.name != ("GhostBoss"))
    {
      Vector2 dir = new Vector2(x, y);
      rb.velocity = dir * speed;
    }

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
      Spawner.enemiesAlive--;
      Spawner.enemiesKilled++;
      Spawner.roundFlag = true;
      Destroy(this.gameObject);
      Spawner.bossDeath = true;
      spooky.Stop();
      bg.Play();
    }
    if(this.name != ("GhostBoss"))
    {
      if(bg.isPlaying && !Spawner.bossDeath)
      {
        bg.Stop();
        spooky.Play();
      }
      moveTowardsPlayer(speed);
    }
  }
  void OnCollisionEnter2D (Collision2D col)
  {
    if(col.gameObject.tag.Equals("FriendlyBullet"))
    {
      for(int i = 0; i < 3; i++)
      {
        Vector2 spawnLocation = new Vector2(Random.Range(-80, 80), Random.Range(-50, 50));
        Spawner.enemiesAlive++;
        Spawner.enemiesThisRound++;
        GameObject e = Instantiate(ghost, spawnLocation, Quaternion.identity) as GameObject;
      }

      FriendlyBullet b = col.gameObject.GetComponent<FriendlyBullet>();
      //Debug.Log(col.gameObject.GetComponent<Rigidbody2D>().velocity);
      if(b != null)
      {
        health -= 20;
        //Debug.Log("lost " + dmg + " health");
        Destroy(col.gameObject);
      }
    }
  }
  void OnTriggerEnter2D(Collider2D col)
  {
    if(col.gameObject.tag.Equals("FriendlyBullet"))
    {
      Spawner.enemiesThisRound++;
      Spawner.enemiesAlive++;
      GameObject ghostSpawn = Instantiate (ghost, transform.position, Quaternion.identity) as GameObject;
      FriendlyBullet b = col.gameObject.GetComponent<FriendlyBullet>();
      //Debug.Log(col.gameObject.GetComponent<Rigidbody2D>().velocity);
      if(b != null)
      {
        health -= 50;
        //Debug.Log("lost " + dmg + " health");
      }
    }
  }
}
