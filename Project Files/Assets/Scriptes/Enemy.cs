using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] AudioClip laserAudio;
    [SerializeField] AudioClip death;
    [SerializeField] int Health = 100;
    [SerializeField] float ShotCounter;
    [SerializeField] float minTimeBetweenShots = 0.2f;
    [SerializeField] float maxTimeBetweenShots = 1f;
    [SerializeField] float projectileSpeed = 100f;
    [SerializeField] GameObject laser;
    [SerializeField] GameObject particles;
    [SerializeField] float time = 2f;
    [SerializeField][Range(0,1f)] float volumeOfLaser = 0.5f;
    [SerializeField][Range(0,1f)] float volumeOfDeath = 2f;
    [SerializeField] int Score =200;
    
    
    void Start()
    {
        ShotCounter = Random.Range(minTimeBetweenShots, maxTimeBetweenShots );
        
    }

    // Update is called once per frame
    void Update()
    {
        CountShot();
    }

    private void CountShot()
    {
        ShotCounter -= Time.deltaTime;
        if(ShotCounter <=0)
        {
            Fire();
            ShotCounter = Random.Range(minTimeBetweenShots, maxTimeBetweenShots );
        }

    }

    private void Fire()
    {
      AudioSource.PlayClipAtPoint(laserAudio,Camera.main.transform.position ,volumeOfLaser);
      GameObject laserBeam  = Instantiate(laser , transform.position, Quaternion.identity) as GameObject;
      laserBeam.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -projectileSpeed);
       
    }

   


    private void OnTriggerEnter2D(Collider2D other) {
         Damge damage = other.gameObject.GetComponent<Damge>();
         if(!damage){ 
          FindObjectOfType<GameSession>().AddScore(Score);
          AudioSource.PlayClipAtPoint(death,Camera.main.transform.position, volumeOfDeath);
          GameObject sparkes = Instantiate(particles,transform.position,transform.rotation);
          Destroy(sparkes , time);
          Destroy(gameObject);
             
             }
         TakeDamage(damage);
    }
    private void TakeDamage(Damge damage)
    {
        Health -=damage.GetDamage();
        damage.Hit();
        if(Health <= 0)
        {
          FindObjectOfType<GameSession>().AddScore(Score);
          AudioSource.PlayClipAtPoint(death,Camera.main.transform.position, volumeOfDeath);
          GameObject sparkes = Instantiate(particles,transform.position,transform.rotation);
          Destroy(sparkes , time);
          Destroy(gameObject);
         }
  }
}
