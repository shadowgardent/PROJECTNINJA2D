using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
using System.Collections.Specialized;
using UnityEngine.SceneManagement;


public class NinControl : MonoBehaviour
{
    public float SPEED;
    public float jumpForce = 5f;
    public LayerMask groundLayer;  // Layer ของพื้นดินสำหรับตรวจสอบการชน
    private float x;
    private Vector3 characterScale;
    private Animator animator;
    private Rigidbody2D rb;
    private int jumpCount = 0;
    private bool isGrounded = false;

    // ระยะเช็คการชนกับพื้น
    public Transform groundCheck;
    public float groundCheckRadius = 0.2f;

    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        characterScale = new Vector3(0.237264f, 0.237264f, 1f);
    }

    void Update()
    {
        // รับค่า Input แกนแนวนอน
        x = Input.GetAxis("Horizontal");
        animator.SetFloat("SPEED", Mathf.Abs(x)); // ส่งค่าไปที่ Animator

        // กำหนดความเร็วการเคลื่อนที่ตามแกน X
        rb.velocity = new Vector2(x * SPEED, rb.velocity.y);

        // ตรวจสอบการหันหน้าของตัวละคร
        if (x > 0)
        {
            transform.localScale = characterScale; // หันหน้าขวา
        }
        else if (x < 0)
        {
            transform.localScale = new Vector3(-characterScale.x, characterScale.y, characterScale.z); // หันหน้าซ้าย
        }

        // ตรวจสอบว่าตัวละครอยู่บนพื้นหรือไม่
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        
        // หากตัวละครอยู่บนพื้น ให้รีเซ็ตจำนวนครั้งที่กระโดด
        if (isGrounded)
        {
            jumpCount = 0;
            animator.SetBool("jump", false);
        }

        // การกระโดดครั้งแรกและครั้งที่สอง
        if (Input.GetButtonDown("jump") && (isGrounded || jumpCount < 2))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            jumpCount++;
            animator.SetBool("jump", true);
        }
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        // ป้องกันการเกาะกำแพง
        if (coll.contacts[0].normal.x != 0) // ถ้าชนด้านข้างของกำแพง
        {
            rb.velocity = new Vector2(0, rb.velocity.y); // รีเซ็ตความเร็วแนวนอนเพื่อป้องกันการเกาะกำแพง
        }

        // ตรวจสอบการชนกับวัตถุที่ทำให้ตาย (ถ้าจำเป็น)
        if (coll.gameObject.CompareTag("Enemy")) // ถ้าวัตถุที่ชนมีแท็ก "DeathObject"
        {
            Die();
        }
    }

    void Die()
    {
        // การจัดการเมื่อ Character ตาย
        Debug.Log("Character has died!");
        rb.velocity = Vector2.zero; // หยุดการเคลื่อนไหว
        // สามารถเพิ่มโค้ดอื่นๆ ที่จำเป็น เช่น รีเซ็ตตำแหน่ง หรือการหยุดการควบคุม
    }

    private void OnTriggerEnter2D(Collider2D target)
    {
        if(target.gameObject.tag == "snow")
        {
            
           SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}


