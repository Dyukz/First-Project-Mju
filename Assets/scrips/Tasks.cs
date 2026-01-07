using UnityEngine;

public class Tasks : MonoBehaviour
{
    public PlayerMain player;
    public GameObject[] rooms;
    public GameObject[] games; // alle games reinmachen
    
    public bool inTask = false;
    public bool[] completedRooms;
    public bool[] completedTasks;

    private int currentRoom;
    private int currentTask = -1;
    private int[] currentRoomTasks;

    void Start()
    {
        completedRooms = new bool [rooms.Length];
        SetUpNewRoom(0);
    }

    void Update()
    {   
        Debug.Log(currentRoom);
        if (currentTask != -1 && !inTask)
        {
            if (Input.GetKey(KeyCode.E))
            {
                OpenTask(currentTask);
            }
        }
        else if (inTask && Input.GetKey(KeyCode.Escape))
            {   
                inTask = false;
                games[currentRoomTasks[currentTask]].SetActive(false);
            }
    }

    public void SetUpNewRoom(int room)
    {   
        int currentRoomTaskCount = rooms[room].GetComponent<RoomValue>().terminals.transform.childCount;
        currentRoomTasks = new int[currentRoomTaskCount];
        for (int i = 0; i < currentRoomTasks.Length; i++)
        {
            currentRoomTasks[i] = Random.Range(0, games.Length);
        }

        completedTasks = new bool [currentRoomTaskCount];
        for (int i = 0; i < currentRoomTasks.Length; i++)
        {
            completedTasks[i] = false;
        }
    }

    void OpenTask(int term)
    {   
        if (!completedTasks[term])
        {
            inTask = true;
            games[currentRoomTasks[term]].SetActive(true);
        }
        else return;
    }

    public void TaskComplete()
    {   
        inTask = false;
        completedTasks[currentTask] = true;
        for (int i = 0; i < completedTasks.Length; i++)
        {
            if (!completedTasks[i])
            {
                return;
            }
        }

        
        HandleRoomCompletion(currentRoom);
    }

    void HandleRoomCompletion(int room)
    {
        print("ALL TASKS COMPLETED!!! in Room: "+ room);
        completedRooms[room] = true;
    }

    void OnTriggerEnter(Collider other)
    {
        TriggerValue trigger = other.GetComponent<TriggerValue>();

        if (trigger != null && trigger.type == "room")
        {  
            if (trigger.id == 0 || completedRooms[trigger.id - 1])
        {
            currentRoom = trigger.id;
            SetUpNewRoom(currentRoom);
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
        if (trigger != null && trigger.type == "task" && trigger.id == currentTask)
        {
            currentTask = -1;
        }
    }
}
