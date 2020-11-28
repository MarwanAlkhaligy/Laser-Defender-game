using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    [SerializeField] float backgroundScrollSpeed = 0.2f;
    Material mymaterial;
    Vector2 Offset;
    // Start is called before the first frame update
    void Start()
    {
        mymaterial = GetComponent<Renderer>().material;
        Offset = new Vector2(0 , backgroundScrollSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        mymaterial.mainTextureOffset +=Offset * Time.deltaTime;
    }
}
