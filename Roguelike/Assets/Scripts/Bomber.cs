using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomber : MonoBehaviour
{
  public float speed;
  public Rigidbody2D rb;
  Player p;
  public GameObject hp;
  void Start()
  {
    p = GameObject.Find("Player").GetComponent<Player>();
    rb = GetComponent<Rigidbody2D>();
    if(this.name != "Bomber")
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
    if(this.name != "Bomber")
    {
      if(transform.position.x > 100 || transform.position.x < -100 || transform.position.y > 60 || transform.position.y < -60)
      {
        Destroy(this.gameObject);
        Spawner.enemiesAlive--;
        Spawner.enemiesKilled++;
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
        //GameObject healthPack = Instantiate (hp, transform.position, Quaternion.identity) as GameObject;
        Spawner.enemiesAlive--;
        Spawner.enemiesKilled++;
        float dmg = b.getSpeed() / 5;
        Destroy(this.gameObject);
        Destroy(col.gameObject);
      }
    }
  }
}
