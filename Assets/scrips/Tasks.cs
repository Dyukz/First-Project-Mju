using UnityEngine;

public class Tasks : MonoBehaviour
{
    public PlayerMain player;
    public GameObject[] rooms;

    public int[] currentRoomTasks;
    public void SetUpNewRoom(int room)
    {
        currentRoomTasks = new int[rooms[room].transform.GetChild(0).transform.childCount];

        for (int i = 0; i < currentRoomTasks.Length; i++)
        {
            currentRoomTasks[i] = Random.Range(0, player.GetComponent<PlayerMain>().games.Length);
        }
    }
}
