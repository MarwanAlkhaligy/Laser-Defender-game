using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{

 [SerializeField] float delayTime = 2f;

  public void LoadStartMenu()
  {
    SceneManager.LoadScene(0);
  }

  public void LoadGame()
  {
        SceneManager.LoadScene("Game");
        FindObjectOfType<GameSession>().Reset();
  }
  public void LoadGameOver()
  {
       StartCoroutine(DelayGameOver());
       //
      
  }
  IEnumerator DelayGameOver()
  {
      
      yield return new WaitForSeconds(delayTime);
      SceneManager.LoadScene("Game Over");
  }

  public void QuitGame()
  {
      Application.Quit();
  }
}
