using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class floorSnow : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D target)
    {
        if(target.gameObject.tag == "snow")
        {
            Destroy(target.gameObject);
        }
    }
}
