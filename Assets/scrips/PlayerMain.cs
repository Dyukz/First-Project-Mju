using System.Collections;
using System.Data.Common;
using Mono.Cecil.Cil;
using UnityEngine;

public class PlayerMain : MonoBehaviour
{
    public bool inGame = false;
    public GameObject[] games; // alle games reinmachen wenn das game active wird wird das script(game) auf den ausgeführt.
    public int currentRoom = 0;
    public int currentTask;


    void Update()
    {
        if (Input.GetKey(KeyCode.E))
        {
            if (currentTask != -1)
            {
                
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        TriggerValue trigger = other.GetComponent<TriggerValue>();

        if (trigger != null && trigger.type == "room")
        {
            currentRoom = trigger.id;
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
