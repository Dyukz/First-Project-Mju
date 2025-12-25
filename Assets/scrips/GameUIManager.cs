using System;
using UnityEngine;

public class GameUIManager : MonoBehaviour

{
    public GameObject[] games; // alle games reinmachen wenn das game active wird wird das script(game) auf den ausgeführt.
    public int testGameOpen;

    void Update()
    {
        if (Input.GetKey(KeyCode.E))
        {
            games[testGameOpen].SetActive(true);
        }
    }
}