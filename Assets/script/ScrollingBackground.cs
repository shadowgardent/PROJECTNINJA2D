using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class ScrollingBackground : MonoBehaviour
{
    public float scrollSpeed = 2f;  // ความเร็วในการเลื่อนของพื้นหลัง
    public float tileSizeX = 20f;   // ขนาดของพื้นหลังในแนวนอนที่ใช้ทำซ้ำ
    private Vector3 startPos;       // ตำแหน่งเริ่มต้นของพื้นหลัง

    void Start()
    {
        // เก็บตำแหน่งเริ่มต้นของพื้นหลัง
        startPos = transform.position;
    }

    void Update()
    {
        // คำนวณตำแหน่งใหม่ในการเลื่อนพื้นหลังไปทางซ้ายเรื่อยๆ
        float newPos = Mathf.Repeat(Time.time * scrollSpeed, tileSizeX);
        transform.position = startPos + Vector3.left * newPos;  // เลื่อนทางซ้าย
    }
}


