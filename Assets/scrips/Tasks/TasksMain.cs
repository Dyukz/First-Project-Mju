using UnityEngine;
using UnityEngine.UI;

public class Tasks : MonoBehaviour
{
    public GameObject[] games;
    public bool inTask = false;
    public GameObject roomParent;
    
    public int currentTerminal = -1;

    public int counter = 0;
    
    private bool[] completedRooms;
    private Rooms currentRoom;
    

    void Start()
    {
        completedRooms = new bool [roomParent.transform.childCount + 1];
        completedRooms[0] = true;
    }

    void Update()
    {
        if (inTask && Input.GetKeyDown(KeyCode.Escape))
        {
            CloseTask();
            return;
        }

        if (currentTerminal != -1 && !inTask && Input.GetKeyDown(KeyCode.E))
        {
            OpenTask();
        }
    }

    void OpenTask()
    {
        inTask = currentRoom.TryOpenTask(currentTerminal);
    }

    void CloseTask()
    {
        currentRoom.CloseGame(currentTerminal);
        inTask = false;
    }

    void OnTriggerEnter(Collider other)
    {
        TriggerValue trigger = other.GetComponent<TriggerValue>();
        if (trigger == null)
        {
            return;
        }
        switch (trigger.type)
        {
            case "room":
                if (trigger.id == counter && completedRooms[trigger.id])    
                {                    
                    currentRoom = trigger.GetComponentInParent<Rooms>();
                    currentRoom.OnRoomStart();
                    counter++; 
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
        if (trigger != null && trigger.type == "task" && trigger.id == currentTerminal)
        {
            currentTerminal = -1;
        }
    }

    public void TaskComplete()
    {   
        inTask = false;
        // Check if all tasks in the room have been completed
        if (currentRoom.TaskCompleted(currentTerminal))
        {
            HandleRoomCompletion(currentRoom.roomId);
        }
    }

    void HandleRoomCompletion(int room)
    {
        print("ALL TASKS COMPLETED!!! in Room: "+ room);
        completedRooms[room +1] = true;
    }
    void nothing()
    {
        
    }
}
