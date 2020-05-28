using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterBullet : MonoBehaviour
{
  public Rigidbody2D rb;
  // Start is called before the first frame update
  void Start()
  {
    rb = GetComponent<Rigidbody2D>();
  }
  // Update is called once per frame
  void Update()
  {
    if(this.name != "ShooterBullet")
    {
      if(rb.velocity.x == 0)
      {
        Destroy(this.gameObject);
      }
      if(transform.position.x > 80 || transform.position.x > 80 || transform.position.y > 50 || transform.position.y < -50)
      {
        Destroy(this.gameObject);
      }
    }
  }
}
