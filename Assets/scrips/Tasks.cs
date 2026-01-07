using UnityEngine;

public class Tasks : MonoBehaviour
{
    public PlayerMain player;
    public GameObject[] rooms;
    public GameObject[] games; // alle games reinmachen wenn das game active wird wird das script(game) auf den ausgeführt.

    private int[] currentRoomTasks;
    public void SetUpNewRoom(int room)
    {
        // termianls mussen als 0 child im raum object sein
        //min 4 terms, weil 4 tasks
        currentRoomTasks = new int[rooms[room].transform.GetChild(0).transform.childCount];

        for (int i = 0; i < currentRoomTasks.Length; i++)
        {
            currentRoomTasks[i] = Random.Range(0, games.Length);
        }
    }

    public void OpenTask(int task)
    {
        games[currentRoomTasks[task]].SetActive(true);
    }
}
