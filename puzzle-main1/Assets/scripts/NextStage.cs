using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextStage : MonoBehaviour
{
  public void NextScene()
   {
     SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
   }
  
   public void BackScene()
   {
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + -1);
   }
   private void OnTriggerEnter2D(Collider2D collision) 
   {
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
   }
   
}
