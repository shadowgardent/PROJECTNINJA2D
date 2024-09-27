using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LineMap : MonoBehaviour
{
   private void OnTriggerEnter2D(Collider2D target)
    {
        if(target.gameObject.tag == "Player")
        {
            
           SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
