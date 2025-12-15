using UnityEngine;

public class OpenUI : MonoBehaviour

{
    Settings settings;
    public GameObject[] game; // alle games reinmachen wenn das game active wird wird das script(game) auf den ausgeführt.
    public bool inUI;
    private int nextUI = 0;     // beim schaffen vom game ++
    void Start()
    {
        settings = GetComponent<Settings>();
    }
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
            game[nextUI].SetActive(true); //menu1.SetActive(!menu1.activeSelf);
        }
    }
    }

    void ExitMenu()
    {
        inUI = false;
        game[nextUI].SetActive(false);
    }
    
}