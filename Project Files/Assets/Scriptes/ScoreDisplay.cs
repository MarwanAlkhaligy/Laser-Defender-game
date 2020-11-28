using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour
{
    Text text;
    GameSession game;

     
    void Start()
    {
        text = GetComponent<Text>();
        game = FindObjectOfType<GameSession>();
    }

    void Update()
    {
        text.text = game.GetScore().ToString();
    }
}
