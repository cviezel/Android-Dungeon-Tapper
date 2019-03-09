using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
  public GameObject friendlyBullet;
  float fireRate = 1;
  float fireDelay = 0;

  float chargeTime = 0;
  Vector2 lastAim;

  // Start is called before the first frame update
  void Start()
  {
  }

  // Update is called once per frame
  void Move(Touch touch)
  {
    Vector2 pos, start;
    start = transform.position;
    pos = Camera.main.ScreenToWorldPoint(touch.position);
    transform.position = new Vector2(pos.x, pos.y);
    //transform.position = Vector2.MoveTowards(start, pos, speed * Time.deltaTime);
  }
  void Shoot(Vector2 aim, float speed)
  {
    //Vector2 pos;
    //pos = Camera.main.ScreenToWorldPoint(touch.position);
    Vector2 dir = aim - (new Vector2(transform.position.x, transform.position.y));
    dir.Normalize();
    GameObject bullet = Instantiate (friendlyBullet, transform.position, Quaternion.identity) as GameObject;
    bullet.GetComponent<Rigidbody2D> ().velocity = dir * speed;
  }
  void Update()
  {
    Touch[] touch = Input.touches;
    if(Input.touchCount == 1)
    {
      Move(touch[0]);
      if(chargeTime > 0 && Time.time > fireDelay)
      {
        //Debug.Log(chargeTime);
        fireDelay = Time.time + fireRate;
        Shoot(lastAim, (fireRate + chargeTime) * 100);
        chargeTime = 0;
      }
    }
    else if(Input.touchCount == 2)
    {
      Move(touch[0]);
      chargeTime += touch[1].deltaTime;
      lastAim = Camera.main.ScreenToWorldPoint(touch[1].position);
      if(chargeTime >= 5)
      {
        Shoot(lastAim, 500);
        chargeTime = 0;
      }
      /*
      if(Time.time > fireDelay)
      {
        fireDelay = Time.time + fireRate;
        Shoot(touch[1], 100);
      }
      */
    }
  }
}
