using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [Header("Player")]
    [SerializeField] float moveSpeed = 10f;
    [SerializeField] float padX = 1f;
    [SerializeField] float padY = 0.2f;
    [SerializeField] int health = 500;
    [SerializeField] AudioClip laserAudio;
    [SerializeField] AudioClip death;
    [SerializeField] GameObject particles;
    [SerializeField] GameObject fireParticles;
    [SerializeField] float time = 2f;
    [SerializeField][Range(0,1f)] float volumeOfLaser = 0.5f;
    [SerializeField][Range(0,1f)] float volumeOfDeath = 2f;
    //[SerializeField]Level level;
    [Header("Projectile")]
    [SerializeField] GameObject LaserPerfab;
    [SerializeField] float projectileSpeed = 100f;
    [SerializeField] float projectilFiringPeriod = 0.2f;
    [SerializeField] private float waitTime = 1.5f;
   

    GameSession gameSession ;

     Vector3 posOfPlayer;  
     Coroutine firingContin;
     HealthText healthText;

    int LivePoints;
    float xMin , xMax;
    float yMin , yMax;
    bool canFire = true;

    void Start()
    {
        posOfPlayer = transform.position;
        healthText = FindObjectOfType<HealthText>();
        LivePoints = healthText.GetNumOfLives();
        gameSession =  FindObjectOfType<GameSession>();
        SetCameraBounbary();
    }
   

      private void SetCameraBounbary()
    {
        Camera gamecamera = Camera.main;

        xMin = gamecamera.ViewportToWorldPoint(new Vector3(0,0,0)).x + padX;
        xMax = gamecamera.ViewportToWorldPoint(new Vector3(1,0,0)).x - padX;

        yMin = gamecamera.ViewportToWorldPoint(new Vector3(0,0,0)).y + padY;
        yMax = gamecamera.ViewportToWorldPoint(new Vector3(0,1,0)).y - padY;

    }

    // Update is called once per frame
    void Update()
    {
      
        Move();
        Fire();
    }


    private void Move()
    {
        var deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed ;
        var deltaY = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed ;

        var newxPos = Mathf.Clamp(transform.position.x + deltaX , xMin, xMax);
        var newyPos = Mathf.Clamp(transform.position.y + deltaY, yMin, yMax);

        transform.position = new Vector2(newxPos, newyPos);
    }



  private void Fire()
  {
      if(Input.GetButtonDown("Fire1") && canFire )
      {
         
        firingContin = StartCoroutine(FireContinouosly());
        
      }
      if(Input.GetButtonUp("Fire1"))
      {
            StopCoroutine(firingContin );
      }

  }


  private void OnTriggerEnter2D(Collider2D other) {
    Damge damage = other.gameObject.GetComponent<Damge>();
    if(!damage){ return;}
    TakeDamage(damage);
  }


  private void TakeDamage(Damge damage)
  {
    health -=damage.GetDamage();
    gameSession.SubHealthScore(damage.GetDamage());
   
    damage.Hit();
    if(health <=0)
    {
      AudioSource.PlayClipAtPoint(death,Camera.main.transform.position, volumeOfDeath);
      GameObject sparkes = Instantiate(particles,transform.position,transform.rotation);
      Destroy(sparkes , time);
      Death();
     
    }

  }

  private void Death()
  {
    LivePoints--;
    gameObject.GetComponent<SpriteRenderer>().enabled = false;
    fireParticles.SetActive(false);
    canFire = false;

    if(LivePoints < 0)
    {
      gameObject.GetComponent<SpriteRenderer>().enabled = false;
      Destroy(gameObject);
      FindObjectOfType<Level>().LoadGameOver();
    }
    else {
      StartCoroutine(DelayLive());
      transform.position = posOfPlayer;
      health = 500;
      healthText.SetText(LivePoints);
      gameSession.SetHealthScore(health);
      
      
    } 
  }


 public int GetHealthScore()
  {
        return health;
  }
    
  
  IEnumerator DelayLive()
  {
    yield return new WaitForSeconds(waitTime);
    gameObject.GetComponent<SpriteRenderer>().enabled = true;
    fireParticles.SetActive(true);
    canFire = true;
  }
IEnumerator FireContinouosly()
  {
     
      while(canFire == true)
      {
      
        AudioSource.PlayClipAtPoint(laserAudio, Camera.main.transform.position, volumeOfLaser);
        GameObject laser = Instantiate(LaserPerfab, transform.position, Quaternion.identity) as GameObject;  
        laser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, projectileSpeed); 
        yield return new WaitForSeconds(projectilFiringPeriod);       
      }
  }
  
}
