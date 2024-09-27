using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject SnowPrefab;
    public float delay = 0.8f;
    public float nextTime;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (nextTime <= Time.time)
        {   
            SpawnSnow();
            nextTime = Time.time + delay;
        }
        
    }

    void SpawnSnow()
    {
        Instantiate(SnowPrefab,transform.position,transform.rotation); 
    }
}
