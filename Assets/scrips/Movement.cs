using TMPro;
using UnityEditor;
using UnityEngine;

public class Movement : MonoBehaviour
{    
    Settings settings;
    OpenUI ui;
    public GameObject kamera;
    public float speed = 12f;
    public float gravity = 0f;
    void Start()
    {
       settings = GetComponent<Settings>();
       Cursor.lockState = CursorLockMode.Locked;
    }
    
    void Update()
    {
        Move(); 
        
    }
    void Move()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y") * -1;
 
        Vector3 xRotation = new Vector3(0, mouseX, 0) * settings.mouseSensitivity * Time.deltaTime;
        transform.Rotate(xRotation);
 
        Vector3 yRotation = new Vector3(mouseY, 0, 0) * settings.mouseSensitivity * Time.deltaTime;
        kamera.transform.Rotate(yRotation);
 
        Vector3 move = transform.forward * y + transform.right * x + Vector3.up * gravity;
        move = move * speed * Time.deltaTime;
        GetComponent<CharacterController>().Move(move);
    }
}   