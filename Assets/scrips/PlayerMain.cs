using System.Collections;
using System.Data.Common;
using Mono.Cecil.Cil;
using UnityEngine;

public class PlayerMain : MonoBehaviour
{
    public bool inGame = false;
    public GameObject[] games; // alle games reinmachen wenn das game active wird wird das script(game) auf den ausgeführt.
    public int currentRoom = 0;
    public int currentTask = 0;

    public float playerSpeed = 5f;
    public float playerHealth = 100f;

    // Das script ist ein Test script zum Testen der Games. Einige Funktionen können und werden später übernommen allerdings nicht alle!
    void Start()
    {
        
    }
    void Update()
    {
        Debug.Log(currentRoom);
        Debug.Log(currentTask);
        if (Input.GetKey(KeyCode.E))
        {
            if (currentTask != -1)
            {
                GetComponent<Tasks>().OpenTask(currentTask);
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        TriggerValue trigger = other.GetComponent<TriggerValue>();

        if (trigger != null && trigger.type == "room")
        {
            if (trigger.id > currentRoom)
            {
                currentRoom = trigger.id;
                GetComponent<Tasks>().SetUpNewRoom(currentRoom);
            }
        }

        if (trigger != null && trigger.type == "task")
        {
           currentTask = trigger.id;
        }
    }

        private void OnTriggerExit(Collider other)
    {
        TriggerValue trigger = other.GetComponent<TriggerValue>();
        if (trigger != null && trigger.id == currentTask)
        {
            currentTask = -1;
        }
    }
}
