using UnityEngine;
using UnityEngine.UI;

public class Colors : MonoBehaviour
{   
    
    public Tasks manager;
    public Color[] colors = {Color.blue, Color.red, Color.green, Color.magenta, Color.yellow};
    public RawImage[] panels;

    private int[] currentState;

    void OnEnable()
    {   
        Cursor.lockState = CursorLockMode.None;
        GameSetup();
    }
    void GameSetup()
    {   
        currentState = new int [panels.Length];

        // Set random Colors / States
        for (int i = 0; i < panels.Length; i++)
        {
            currentState[i] = Random.Range(0, colors.Length);
            panels[i].color = colors[currentState[i]];
        }
    }

    // Uses CheckField();
    public void OnClick(int index)
    {   
        int direction;
        if (index < 0)
        {
            direction = -1;
            index *= -1;
        }
        else direction = 1;
        index -= 1;
        
        currentState[index] = (currentState[index] + direction + colors.Length) % colors.Length;
        panels[index].color = colors[currentState[index] % colors.Length];
        
        CheckField();
    }

    // using CloseGame();
    void CheckField()
    {   
        for (int i = 0; i < panels.Length; i++)
        {
            if (currentState[i] != currentState[0])
            {
                return;
            }
            
        }
        CloseGame();
    }

    void CloseGame()
    {
        Cursor.lockState = CursorLockMode.Locked;
        gameObject.SetActive(false);
        manager.TaskComplete();
    }
}
