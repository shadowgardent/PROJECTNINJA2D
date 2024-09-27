using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RestartButton : MonoBehaviour
{
    public Button restartButton; // กำหนดปุ่มรีสตาร์ทใน Inspector
   

    void Start()
    {
        // ตรวจสอบว่ามีการกำหนดปุ่มหรือไม่
        if (restartButton == null )
        {
            Debug.LogError("Restart button or Menu button is not assigned in the Inspector.");
            return; // หยุดการทำงานของ Start ถ้าปุ่มไม่ถูกกำหนด
        }

        // เพิ่ม Listener ให้กับปุ่ม
        restartButton.onClick.AddListener(OnRestartButtonClicked);
        
    }

    void OnRestartButtonClicked()
    {
        // โหลดซีนที่ชื่อ SampleScene
        SceneManager.LoadScene("SampleScene");
    }
}
