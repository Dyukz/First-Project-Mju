using System;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class OrderMain : MonoBehaviour
{
    private int[] pattern;
    private int currentNum = 1;

    public Tasks manager;
    public GameObject buttonParent;
    public GameObject buttonPrefab;
    public int rows = 2;
    public int columns = 7;

    private int maxButtons = 0;

    void Awake()
    {   
        
        CreateButtons();
        maxButtons = buttonParent.transform.childCount;
        pattern = new int [maxButtons];
    }

    void OnEnable()
    {   
        Cursor.lockState = CursorLockMode.None;
        currentNum = 1;
        SetButtonValue();
    }

    public bool Check(int button)
    { 
        if (pattern[button] == currentNum)
        {
            currentNum++;
            if (currentNum  == maxButtons +1)
            {
                CloseGame();
            }
            return true;
        }
        else return false;
    }

    void SetButtonValue()
    {   
        for (int i=0; i<maxButtons ;i++)
        {
            pattern[i] = -1;
        }

        int patternLeft = maxButtons;
        for (int i=0; i<maxButtons ;i++)
        {   
            int slot = GetFreeSlot(UnityEngine.Random.Range(0, maxButtons-1));
            if (slot != -1)
            {
                pattern[slot] = patternLeft;
                patternLeft--;
            }      
        }

        for (int i=0; i<maxButtons; i++)
        {
            buttonParent.transform.GetChild(i).GetComponent<OrderButtons>().SetValue(pattern[i]);
        }
    }

    int GetFreeSlot(int start)
    {
        for (int i = 0; i < maxButtons; i++)
        {
            if (pattern[start] == -1)
            return start;

            start = (start + 1) % maxButtons;
        }
        return -1;   
    }

    void CreateButtons()
    { 
        for (int y = 0; y < rows; y++)
        {
            for (int x = 0; x < columns; x++)
            {
                Instantiate(buttonPrefab, buttonParent.transform);
            }
        }
    }

    void CloseGame()
    {
        Cursor.lockState = CursorLockMode.Locked;
        gameObject.SetActive(false);
        manager.TaskComplete();
    }
}
