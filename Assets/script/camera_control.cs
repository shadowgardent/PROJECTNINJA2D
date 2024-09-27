using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class camera_control : MonoBehaviour
{
    public Transform obj;  // ตัวละครที่กล้องจะติดตาม
    public float minX;      // ขอบเขต X ต่ำสุดที่กล้องจะไม่เลื่อนไปเกิน
    public float maxX;      // ขอบเขต X สูงสุดที่กล้องจะไม่เลื่อนไปเกิน

    void Update()
    {
        // รับตำแหน่งของตัวละครที่กล้องต้องตาม
        float targetX = obj.position.x;

        // จำกัดตำแหน่ง X ของกล้องให้อยู่ในขอบเขต minX และ maxX
        float clampedX = Mathf.Clamp(targetX, minX, maxX);

        // อัปเดตตำแหน่งของกล้อง
        transform.position = new Vector3(clampedX, transform.position.y, transform.position.z);
    }
}
