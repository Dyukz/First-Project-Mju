using System.Collections;
using System.Data.Common;
using Mono.Cecil.Cil;
using UnityEngine;

public class PlayerMain : MonoBehaviour
{
    public float playerSpeed = 5f;
    public float playerHealth = 100f;
    public GameObject crosshair;

    // Das script ist ein Test script zum Testen der Games. Einige Funktionen können und werden später übernommen allerdings nicht alle!
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    
}
