using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{    
    public GameObject kamera;
    public float gravity = 0f;
    public float mouseSensitivity = 200f;

    private float xRotation = 0;
    void Start()
    {
    }
    
    void Update()
    {
        if (!GetComponent<Tasks>().inTask)
        {
            Move();
        }
    }

    void Move()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
        transform.Rotate(Vector3.up * mouseX);
        
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -45f, 45f);

        kamera.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        Vector3 move = transform.forward * y + transform.right * x + Vector3.up * gravity;
        move *= GetComponent<PlayerMain>().playerSpeed * Time.deltaTime;

        GetComponent<CharacterController>().Move(move);
    }
}   