using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
  // Start is called before the first frame update
  float health = 100;
  public float speed = 500f;
  public Rigidbody2D rb;
  Player p;
  bool recentlyHit;
  float moveTimer = 0;
  void Start()
  {
    p = GameObject.Find("Player").GetComponent<Player>();
    rb = GetComponent<Rigidbody2D>();
    recentlyHit = false;
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
    }
    if(this.name != "Enemy" && !recentlyHit)
    {
      moveTowardsPlayer(speed);
    }
    if(recentlyHit)
    {
      moveTimer += Time.deltaTime;
      Debug.Log(moveTimer);
      if(moveTimer >= 0.05)
      {
        moveTimer = 0;
        recentlyHit = false;
      }
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
        recentlyHit = true;
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
        recentlyHit = true;
        float dmg = b.getSpeed() / 5;
        health -= dmg;
        Debug.Log("lost " + dmg + " health");
      }
    }
  }
}
