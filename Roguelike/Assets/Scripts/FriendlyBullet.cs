using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriendlyBullet : MonoBehaviour
{
  public Rigidbody2D rb;
  private float speed;
  private bool super = false;

  public GameObject perk1;
  public GameObject perk2;
  public GameObject perk3;
  public GameObject perk4;
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
      transform.Rotate(0, 0, 30);
      if(rb.velocity.x == 0)
      {
        Destroy(this.gameObject);
      }
      if(transform.position.x > 100 || transform.position.x < -100 || transform.position.y > 60 || transform.position.y < -60)
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
  public void setSuper() {
    super = true;
  }
  public bool isSuper() {
    return super;
  }
  void OnCollisionEnter2D (Collision2D col)
  {
    if(col.gameObject.tag.Equals("FullHeal"))
    {
      Player.health = Player.maxHealth;
      Player.charges = Player.maxCharges;
      Destroy(this.gameObject);
      Player.perkCount++;
      if((Player.perkCount == 1 && Player.tookDamage) || (Player.perkCount >= 2 && !Player.tookDamage))
      {
        Player.perkCount = 0;
        Player.tookDamage = false;
        GameObject p1 = GameObject.Find("Perk1(Clone)");
        GameObject p2 = GameObject.Find("Perk2(Clone)");
        GameObject p3 = GameObject.Find("Perk3(Clone)");
        GameObject p4 = GameObject.Find("Perk4(Clone)");
        Destroy(p1.gameObject);
        Destroy(p2.gameObject);
        Destroy(p3.gameObject);
        Destroy(p4.gameObject);
        Spawner.roundFlag = true;
      }
    }
    else if(col.gameObject.tag.Equals("ChargeCapacity"))
    {
      Player.maxCharges += 2;
      Player.charges += 2;
      Destroy(this.gameObject);
      Player.perkCount++;
      if((Player.perkCount == 1 && Player.tookDamage) || (Player.perkCount >= 2 && !Player.tookDamage))
      {
        Player.perkCount = 0;
        Player.tookDamage = false;
        GameObject p1 = GameObject.Find("Perk1(Clone)");
        GameObject p2 = GameObject.Find("Perk2(Clone)");
        GameObject p3 = GameObject.Find("Perk3(Clone)");
        GameObject p4 = GameObject.Find("Perk4(Clone)");
        Destroy(p1.gameObject);
        Destroy(p2.gameObject);
        Destroy(p3.gameObject);
        Destroy(p4.gameObject);
        Spawner.roundFlag = true;
      }
    }
    else if(col.gameObject.tag.Equals("AttackSpeed"))
    {
      Player.fireDelay -= 0.1f;
      if(Player.fireDelay < 0f)
      {
        Player.fireDelay = 0f;
      }
      Destroy(this.gameObject);
      Player.perkCount++;
      if((Player.perkCount == 1 && Player.tookDamage) || (Player.perkCount >= 2 && !Player.tookDamage))
      {
        Player.perkCount = 0;
        Player.tookDamage = false;
        GameObject p1 = GameObject.Find("Perk1(Clone)");
        GameObject p2 = GameObject.Find("Perk2(Clone)");
        GameObject p3 = GameObject.Find("Perk3(Clone)");
        GameObject p4 = GameObject.Find("Perk4(Clone)");
        Destroy(p1.gameObject);
        Destroy(p2.gameObject);
        Destroy(p3.gameObject);
        Destroy(p4.gameObject);
        Spawner.roundFlag = true;
      }
    }
    else if(col.gameObject.tag.Equals("MaxHealth"))
    {
      Player.maxHealth += 20;
      Player.health += 20;
      Destroy(this.gameObject);
      Player.perkCount++;
      if((Player.perkCount == 1 && Player.tookDamage) || (Player.perkCount >= 2 && !Player.tookDamage))
      {
        Player.perkCount = 0;
        Player.tookDamage = false;
        GameObject p1 = GameObject.Find("Perk1(Clone)");
        GameObject p2 = GameObject.Find("Perk2(Clone)");
        GameObject p3 = GameObject.Find("Perk3(Clone)");
        GameObject p4 = GameObject.Find("Perk4(Clone)");
        Destroy(p1.gameObject);
        Destroy(p2.gameObject);
        Destroy(p3.gameObject);
        Destroy(p4.gameObject);
        Spawner.roundFlag = true;
      }
    }
  }
}
