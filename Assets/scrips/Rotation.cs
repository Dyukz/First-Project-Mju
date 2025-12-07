using UnityEngine;

public class Rotation : MonoBehaviour
{   
    Settings settings;
    void Start()
    {
        settings = GetComponent<Settings>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        
    }
}
