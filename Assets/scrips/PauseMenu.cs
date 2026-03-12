using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{   
    public GameObject mainMenu;
    public bool inPause = false;
   
    public void DEAD()
    {
        inPause = true;
        UpdatePause(inPause);
    }

    void UpdatePause(bool state)
    {
        mainMenu.SetActive(state);
        
        if (state)
        {   
            Cursor.lockState = CursorLockMode.None;
            Time.timeScale = 0;
        }
        else 
        {
            Time.timeScale = 1;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
    }
}
