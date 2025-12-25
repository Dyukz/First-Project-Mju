using UnityEngine;
using UnityEngine.UI;

public class Panes: MonoBehaviour
{
    public Button[] buttons = new Button[18]; //max buttons --> 18 rn
    
    public void OnEnable()
    {   
        Cursor.lockState = CursorLockMode.None;
        ChooseGreen();
    }
    
    void ChooseGreen()
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            float r = Random.Range(1, 4);
            if (r == 1)
            {
                buttons[i].image.color = Color.green;
            }
            else 
            {
                buttons[i].image.color = Color.red;
            }
        }
    }

    public void Click(int index)
    {
        if(buttons[index].image.color == Color.red)
        {
            buttons[index].image.color = Color.green;
        }
        else buttons[index].image.color = Color.red;
        Check();
    }

    void Check()
    {   
        float buttonCheck = 0;
        for (int i = 0; i < buttons.Length; i++)
        {
            if (buttons[i].image.color == Color.green)
            {
                buttonCheck += 2;
            }
            else return;

            if (buttonCheck >= 36)
            {
                GameWin();
            }
        }
    }

    void GameWin()
    {
        Cursor.lockState = CursorLockMode.Locked;
        gameObject.SetActive(false);
    }
}
