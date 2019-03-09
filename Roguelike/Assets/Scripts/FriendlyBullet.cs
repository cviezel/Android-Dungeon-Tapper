using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriendlyBullet : MonoBehaviour
{
  public Rigidbody2D rb;
  public float speed;
  // Start is called before the first frame update
  void Start()
  {
    rb = GetComponent<Rigidbody2D>();
  }
  // Update is called once per frame
  void Update()
  {
    /*
    if(rb.velocity.magnitude < 0.1)
    {
      Destroy(this);
    }
    */
    if(this.name != "FriendlyBullet")
    {
      if(this.transform.position.x >= 100)
      {
        Destroy(this);
      }
    }
  }
  public float getSpeed()
  {
    return speed;
  }
  public void setSpeed(float s)
  {
    speed = s;
  }
}
