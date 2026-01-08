using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Order : MonoBehaviour
{
    public Button[] buttons;
    public Tasks manager;

    private TMP_Text[] texts;
    private int[] pattern;
    private int patternLeft;
    private int currentNum = 1;

    void OnEnable()
    {   
        pattern = new int [buttons.Length];
        texts = new TMP_Text[buttons.Length];
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
            if (currentNum == buttons.Length +1)
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
        manager.TaskComplete();
    }
}
