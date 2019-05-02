using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomber : MonoBehaviour
{
  float health = 100;
  public float speed;
  public Rigidbody2D rb;
  Player p;
  bool recentlyHit;
  float moveTimer = 0;
  void Start()
  {
    p = GameObject.Find("Player").GetComponent<Player>();
    rb = GetComponent<Rigidbody2D>();
    recentlyHit = false;
    if(this.name != "Bomber" && !recentlyHit)
    {
      moveTowardsPlayer(speed);
    }
  }
  void moveTowardsPlayer(float speed)
  {
    Vector2 dir = new Vector2(p.transform.position.x, p.transform.position.y) - (new Vector2(transform.position.x, transform.position.y));
    dir.Normalize();
    rb.velocity = dir * speed;
  }
  // Update is called once per frame
  void Update()
  {

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
        Destroy(this.gameObject);
        Destroy(col.gameObject);
      }
    }
  }
}
