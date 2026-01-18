using UnityEngine;

public class PauseMenu : MonoBehaviour
{   
    public GameObject mainMenu;
    public bool inPause = false;
    void Update()
    {
        if(!GetComponent<Tasks>().inTask && Input.GetKeyDown(KeyCode.T))
        {
            inPause = !inPause;
            UpdatePause(inPause);
        }
    }

    void UpdatePause(bool state)
    {
        mainMenu.SetActive(state);
        
        if (state)
        {
            Time.timeScale = 0;
        }
        else Time.timeScale = 1;
    }
}