using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    float health = 100;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnCollisionEnter2D (Collision2D col)
    {
      if(col.gameObject.tag.Equals("FriendlyBullet"))
      {
        float dmg = col.gameObject.GetComponent<Rigidbody2D>().velocity.magnitude;
        health -= dmg;
        Debug.Log("lost " + dmg + " health");
        Destroy(col.gameObject);
      }
    }
}
