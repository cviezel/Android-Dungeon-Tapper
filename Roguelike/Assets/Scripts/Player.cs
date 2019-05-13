using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Player : MonoBehaviour
{
  public GameObject friendlyBullet;
  public GameObject bigShuriken;
  //public GameObject friendlyLaser;
  float fireTime = 0;
  float chargeTime = 0;
  Vector2 lastAim;
  public static int health = 100;
  public static int maxHealth = 100;
  public static int charges = 2;
  public static int maxCharges = 2;
  public static float fireDelay = 0.5f;
  public static bool tookDamage = false;
  public static int perkCount = 0;

  public Text txtHealth;
  public Text txtCharges;

  public Animator anim;

  // Start is called before the first frame update
  void Start()
  {
    maxHealth = health;
    txtHealth.text = "Health: " + health.ToString();
    txtCharges.text = "Charged Shots: " + charges.ToString();
    anim = GetComponent<Animator>();
    //rb = GetComponent<Rigidbody2D>();
  }

  // Update is called once per frame
  void Move(Touch touch)
  {
    Vector2 pos, start;
    start = transform.position;
    pos = Camera.main.ScreenToWorldPoint(touch.position);
    if(Vector2.Distance(start, pos) < 50) //wasn't a slide
    {
      transform.position = new Vector2(pos.x, pos.y);
    }
    //transform.position = Vector2.MoveTowards(start, pos, speed * Time.deltaTime);
  }
  void Shoot(Vector2 aim, float speed, bool fullyCharged)
  {
    anim.SetTrigger("Throw");
    Vector2 dir = aim - (new Vector2(transform.position.x, transform.position.y));
    dir.Normalize();
    GameObject bullet = Instantiate (friendlyBullet, transform.position, Quaternion.identity) as GameObject;
    bullet.GetComponent<Rigidbody2D>().velocity = dir * speed;
    FriendlyBullet b = bullet.GetComponent<FriendlyBullet>();
    b.setSpeed(speed);
    if(fullyCharged && charges > 0)
    {
      charges--;
      txtCharges.text = "Charged Shots: " + charges.ToString();
      b.transform.localScale += new Vector3(1, 1, 0);
      bullet.GetComponent<CircleCollider2D>().isTrigger = true;
    }
  }
  /*
  void Laser(Vector2 aim, float speed)
  {
    Vector2 dir = aim - (new Vector2(transform.position.x, transform.position.y));
    dir.Normalize();
    GameObject laser = Instantiate (friendlyLaser, transform.position, Quaternion.identity) as GameObject;
    laser.GetComponent<Rigidbody2D>().velocity = dir * speed;
    FriendlyBullet b = bullet.GetComponent<FriendlyLaser>();
    b.setSpeed(speed);
  }
  */
  void Update()
  {
    if(health <= 0)
    {
      Spawner.enemiesKilled = 0;
      Spawner.roundNum = 1;
      Spawner.roundFlag = true;
      Spawner.enemiesAlive = 0;
      Spawner.enemiesThisRound = 10;
      Spawner.bossDeath = false;
      health = 100;
      maxHealth = 100;
      charges = 2;
      maxCharges = 2;
      fireDelay = 0.5f;
      tookDamage = false;
      perkCount = 0;
      SceneManager.LoadScene("MainMenu");
    }
    Touch[] touch = Input.touches;
    if(Input.touchCount == 1)
    {
      txtHealth.text = "Health: " + health.ToString();
      txtCharges.text = "Charged Shots: " + charges.ToString();
      Move(touch[0]);
      if(chargeTime > 0 && Time.time > fireTime)
      {
        //Debug.Log(chargeTime);
        fireTime = Time.time + fireDelay;
        Shoot(lastAim, (1 + chargeTime) * 150, false);
        chargeTime = 0;
      }
    }
    else if(Input.touchCount == 2)
    {
      //rb.velocity = new Vector2(0, 0);
      Move(touch[0]);
      chargeTime += touch[1].deltaTime;
      lastAim = Camera.main.ScreenToWorldPoint(touch[1].position);
      if(chargeTime >= 1)
      {
        Shoot(lastAim, 500, true);
        chargeTime = 0;
      }
    }
  }
  void OnCollisionEnter2D (Collision2D col)
  {
    if(col.gameObject.tag.Equals("HealthPack"))
    {
      if(health <= maxHealth - 10)
      {
        health += 10;
      }
      else
      {
        health = maxHealth;
      }
      txtHealth.text = "Health: " + health.ToString();
      Destroy(col.gameObject);
    }
    if(col.gameObject.tag.Equals("Enemy"))
    {
      Spawner.enemiesAlive--;
      Spawner.enemiesKilled++;
      //rb.velocity = new Vector2(0, 0);
      health -= 10;
      Destroy(col.gameObject);
      tookDamage = true;
    }
    if(col.gameObject.tag.Equals("EnemyBullet"))
    {
      health -= 5;
      Destroy(col.gameObject);
      tookDamage = true;
    }
    txtHealth.text = "Health: " + health.ToString();
  }
}
