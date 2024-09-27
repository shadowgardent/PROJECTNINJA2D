using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BACKMENU : MonoBehaviour
{
    
    public Button menuButton;     // กำหนดปุ่มเมนูใน Inspector

    void Start()
    {
        // ตรวจสอบว่ามีการกำหนดปุ่มหรือไม่
        if ( menuButton == null)
        {
            Debug.LogError("Restart button or Menu button is not assigned in the Inspector.");
            return; // หยุดการทำงานของ Start ถ้าปุ่มไม่ถูกกำหนด
        }

        // เพิ่ม Listener ให้กับปุ่ม
        
        menuButton.onClick.AddListener(OnMenuButtonClicked);
    }

    

    void OnMenuButtonClicked()
    {
        // โหลดซีนที่ชื่อ MENU
        SceneManager.LoadScene("MENU");
    }
}
