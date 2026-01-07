using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{    
    PlayerMain player;
    public GameObject kamera;
    public float gravity = 0f;
    public float mouseSensitivity = 200f;
    void Start()
    {
       player = GetComponent<PlayerMain>();
    }
    
    void Update()
    {
        if (!player.inGame)
        {
            Move();
        }
    }

    void Move()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y") * -1;
 
        Vector3 xRotation = new Vector3(0, mouseX, 0) * mouseSensitivity * Time.deltaTime;
        transform.Rotate(xRotation);

        
        Vector3 yRotation = new Vector3(mouseY, 0, 0) * mouseSensitivity * Time.deltaTime;
        kamera.transform.Rotate(yRotation);
 
        Vector3 move = transform.forward * y + transform.right * x + Vector3.up * gravity;
        move = move * player.playerSpeed * Time.deltaTime;
        GetComponent<CharacterController>().Move(move);
    }
}   