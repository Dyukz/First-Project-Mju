using UnityEngine;

public class OpenUI : MonoBehaviour

{
    Settings settings;
    public GameObject menu1; //test Menu
    public bool inUI;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        settings = GetComponent<Settings>();
        menu1.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {   
        if (inUI)
        {
            if (Input.GetKeyDown(settings.set_exit))
        {
            ExitMenu();
        }
        }
    else
    {
        if (Input.GetKeyDown(settings.set_interact))
        {
            inUI = true;
            menu1.SetActive(true); //menu1.SetActive(!menu1.activeSelf);
        }
    }
    }

    void ExitMenu()
    {
        inUI = false;
        menu1.SetActive(false);
    }
    
}