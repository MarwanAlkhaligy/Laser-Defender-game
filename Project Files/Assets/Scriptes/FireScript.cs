using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireScript : MonoBehaviour
{
    [SerializeField] GameObject player;

    Vector2 posOfParticle;
    // Start is called before the first frame update
    void Start()
    {
        posOfParticle = transform.position - player.transform.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 newPos = new Vector2(player.transform.position.x, player.transform.position.y) ;
        transform.position = newPos + posOfParticle; 
    }
}
