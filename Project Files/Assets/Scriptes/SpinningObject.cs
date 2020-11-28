using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinningObject : MonoBehaviour
{
    [SerializeField] float speedOfRotation = 1f;
    [SerializeField] float moveSpeed = 15f;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0 ,-moveSpeed );
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0,0,speedOfRotation*Time.deltaTime);
    }

   
  
}
