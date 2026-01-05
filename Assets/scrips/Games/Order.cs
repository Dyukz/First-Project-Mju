using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Order : MonoBehaviour
{   
    public Button[] buttons = new Button[14]; // max buttons --> 14 rn
    
    private TMP_Text[] texts = new TMP_Text[14];
    private int[] pattern = new int [14];
    private int patternLeft;
    private int currentNum = 1;

    void OnEnable()
    {   
        Cursor.lockState = CursorLockMode.None;
        for (int i = 0; i < buttons.Length; i++)
        {
            texts[i] = buttons[i].GetComponentInChildren<TMP_Text>();
        }
        NewPattern();
    }

    public void Click(int button)
    {   
        int index = pattern[button];
        
        if (index == currentNum)
        {   
            buttons[button].image.color = Color.green;
            currentNum++;
            if (currentNum == 15)
            {
                CloseGame();
            }
        }
        else if (index < currentNum)
        { 
            return;
        }
        else
        {
            NewPattern();
            return;
        }
        
    }

   
    public void NewPattern()
    {   
        currentNum = 1;
        patternLeft = buttons.Length;
        for (int i = 0; i < buttons.Length; i++)
        {
            pattern[i] = -1;
            buttons[i].image.color = Color.red;
        }

        while (true)
        {
            int check = CheckFree(UnityEngine.Random.Range(0, buttons.Length));
            if (check != -1)
            {
                pattern[check] = patternLeft;
                patternLeft--;
            }
            else break;
        }

        for (int i = 0; i < buttons.Length; i++)
        {
            texts[i].text = "" + pattern[i];
        }
    }
    int CheckFree(int index)
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            if (pattern[index] == -1)
            return index;

            index = (index + 1) % buttons.Length;
        }
        return -1;
    }
    void CloseGame()
    {
        Cursor.lockState = CursorLockMode.Locked;
        gameObject.SetActive(false);
    }
}
