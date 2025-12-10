using UnityEngine;

public class Minigame : MonoBehaviour

{
    Settings settings;
    public GameObject Keypad1;
    public KeyCode set_interact = KeyCode.E;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        settings = GetComponent<Settings>();
        Keypad1.SetActive(false);
    Debug.Log("start");
    
    }

    // Update is called once per frame
    void Update()
    {
        epressed();
        Debug.Log("update");
    }

    void epressed()
    {
        Debug.Log("epressed");
        if (Input.GetKeyDown(set_interact))
        
        {
            Keypad1.SetActive(!Keypad1.activeSelf);
            Debug.Log("Geht");
        }
    }
    
}
