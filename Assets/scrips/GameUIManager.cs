using System;
using UnityEngine;

public class GameUIManager : MonoBehaviour

{
    public GameObject[] games; // alle games reinmachen wenn das game active wird wird das script(game) auf den ausgeführt.
    public bool inGame;
    private int currentGame = 1;
    void Start()
    {
        for (int i = 0; i < games.Length; i++)
        {
            games[i].SetActive(false);
        }
    }
    void Update()
    {   
        if (!inGame)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                OpenGame(currentGame);
            }
        }
        else if (Input.GetKeyDown(KeyCode.Escape))
            {
                ExitGame(currentGame);
                Cursor.lockState = CursorLockMode.Locked;
            }
    }

    public void ExitGame(int index)
    {
        inGame = false;
        games[index].SetActive(false);
    }

    void OpenGame(int index)
    {   
        inGame = true;
        games[index].SetActive(true);
        //games[index].GetComponent<Melody>().Reset();
        games[index].GetComponent<Numbers>().Reset();
    }
    
}