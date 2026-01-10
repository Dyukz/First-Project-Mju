using UnityEngine;
using UnityEngine.UI;

public class Tasks : MonoBehaviour
{
    public GameObject[] games; // alle games reinmachen
    
    public int roomCount;
    public bool inTask = false;
    public bool[] completedRooms;

    private Rooms currentRoom;
    private int currentTerminal = -1;

    void Start()
    {
        completedRooms = new bool [roomCount];
    }

    void Update()
    {
        if (currentTerminal != -1 && !inTask)
        {
            if (Input.GetKey(KeyCode.E) && !currentRoom.completedTasks[currentTerminal])
            {
                HandleState(true);
            }
        }
        else if (inTask && Input.GetKey(KeyCode.Escape))
        {
            HandleState(false);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        TriggerValue trigger = other.GetComponent<TriggerValue>();

        switch (trigger.type)
        {
            case "room":
                if (trigger.id == 0 || completedRooms[trigger.id - 1])
                {
                    currentRoom = trigger.GetComponentInParent<Rooms>();
                    currentRoom.roomId = trigger.id;
                }
                break;
            case "task":
                currentTerminal = trigger.id;
                break;
        }
    }

    void OnTriggerExit(Collider other)
    {
        TriggerValue trigger = other.GetComponent<TriggerValue>();
        if (trigger != null && trigger.type == "task" && trigger.id == currentRoom.roomId)
        {
            currentTerminal = -1;
        }
    }

    void HandleState(bool state)
    {
        inTask = state;
        games[currentRoom.tasksOnTerminals[currentTerminal]].SetActive(true);
    }

    public void TaskComplete()
    {   
        inTask = false;
        currentRoom.completedTasks[currentTerminal] = true;
        
        for (int i = 0; i < currentRoom.completedTasks.Length; i++)
        {
            if (!currentRoom.completedTasks[i])
            {
                return;
            }
        }

        HandleRoomCompletion(currentRoom.roomId);
    }

    void HandleRoomCompletion(int room)
    {
        print("ALL TASKS COMPLETED!!! in Room: "+ room);
        completedRooms[room] = true;
    }

    
}
