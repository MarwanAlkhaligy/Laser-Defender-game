using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealthDisplay : MonoBehaviour
{
    // Start is called before the first frame update
   Text text ;
   GameSession game;
    void Start()
    {
        text = GetComponent<Text>();
        game = FindObjectOfType<GameSession>();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = game.GetHealthScore().ToString();
    }
}
