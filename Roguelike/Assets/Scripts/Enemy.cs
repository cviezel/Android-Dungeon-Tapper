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
  void Start()
  {
    p = GameObject.Find("Player").GetComponent<Player>();
    rb = GetComponent<Rigidbody2D>();
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
    if(this.name != "Enemy")
    {
      moveTowardsPlayer(speed);
    }
    if(health <= 0)
    {
      Destroy(this.gameObject);
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
        Debug.Log("lost " + dmg + " health");
      }
    }
  }
}
