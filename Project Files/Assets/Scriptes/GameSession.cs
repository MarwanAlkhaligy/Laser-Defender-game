using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSession : MonoBehaviour
{
  private int Score = 0;
  private int healthScore = 500;

  private void Awake() {
    load();
  }

  private void load()
  {
    if(FindObjectsOfType(GetType()).Length > 1)
    {
      gameObject.SetActive(false);
      Destroy(gameObject);
    } else {
      DontDestroyOnLoad(gameObject);
    }
  }

  public void AddScore(int Score)
  {
    this.Score += Score;
  }

  public int GetScore()
  {
    return this.Score;
  }

  public void Reset()
  {
    Destroy(gameObject);
  }
  
  public int GetHealthScore()
  {
    return healthScore;
  }

  public void SubHealthScore(int Score)
  {
    if(healthScore - Score >= 0)
    {
      this.healthScore -= Score;
    } else {
      this.healthScore = 0;
    }
  }

  public void SetHealthScore(int Score)
  {
    healthScore = Score;
  }

}
