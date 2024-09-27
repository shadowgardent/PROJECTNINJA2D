using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowControl : MonoBehaviour
{
   
    private Rigidbody2D rb;
    public float speed = 1f ; 
    public float Minspeed = 8f;
    public float Maxspeed = 20f; 

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    void Start()
    {
        speed = Random.Range(Minspeed,Maxspeed);
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 forward = new Vector2  (transform.right.x,transform.right.y);
        rb.MovePosition(rb.position +forward * Time.deltaTime*speed);
    }
}
