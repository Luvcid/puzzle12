using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Sebelum : MonoBehaviour
{
    private int Sebelumscene;

    private void Start() 
    {
      Sebelumscene =  SceneManager.GetActiveScene().buildIndex + - 1;
    }
   private void OnTriggerEnter2D(Collider2D collision) 
   {
    SceneManager. LoadScene(Sebelumscene);
   }
   
}
