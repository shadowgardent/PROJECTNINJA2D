using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; 
using UnityEditor; 


public class ExitGame : MonoBehaviour
{
    public Button ExitButton; // ประกาศตัวแปรปุ่ม ExitButton

    void Start()
    {
        // ตรวจสอบว่ามีการกำหนดปุ่มหรือไม่
        if (ExitButton == null)
        {
            Debug.LogError("Exit button is not assigned in the Inspector.");
            return; // หยุดการทำงานของ Start ถ้าปุ่มไม่ถูกกำหนด
        }

        // เพิ่ม Listener ให้กับปุ่ม
        ExitButton.onClick.AddListener(OnExitButtonClicked);
    }

    void OnExitButtonClicked()
    {
        // ถ้าอยู่ใน Unity Editor ให้ปิด Editor
        #if UNITY_EDITOR
            EditorApplication.isPlaying = false;  // หยุดการเล่นใน Unity Editor
        #else
            Application.Quit(); // ปิดโปรแกรมในไฟล์ build
        #endif

        Debug.Log("Game is exiting...");
    }
}
