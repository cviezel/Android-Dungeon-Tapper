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
    if(this.name != "FriendlyBullet")
    {
      if(rb.velocity.x == 0)
      {
        Destroy(this.gameObject);
      }
      else if(this.transform.position.x >= 100)
      {
        Destroy(this.gameObject);
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
