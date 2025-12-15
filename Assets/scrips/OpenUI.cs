using UnityEngine;

public class OpenUI : MonoBehaviour

{
    Settings settings;
    public GameObject[] game; // alle games reinmachen wenn das game active wird wird das script(game) auf den ausgeführt.
    public bool inUI;
    private int currentGame = 0;     // beim schaffen vom game ++
    public string uiOpen;
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
            ExitGame();
        }
        }
    else
    {
        if (Input.GetKeyDown(settings.set_interact))
        {
            inUI = true;
            game[currentGame].SetActive(true); //.SetActive(!menu1.activeSelf);
        }
    }
    }

    void ExitGame()
    {
        inUI = false;
        game[currentGame].SetActive(false);
    }
    
}