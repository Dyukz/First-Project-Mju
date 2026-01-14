using UnityEngine;

public class Rooms : MonoBehaviour
{   
    public Tasks taskMain;
    public GameObject tasks;
    public bool[] completedTasks;
    public int[] tasksOnTerminals;
    public int roomId = 0;

    void Start()
    {   
        int terminalCount = tasks.transform.childCount;
        
        //Setup the Arraylength based on on the Terminalcount
        completedTasks = new bool[terminalCount];
        tasksOnTerminals = new int[terminalCount];

        //Setting the game for each terminal && Completion State
        for (int i=0; i<terminalCount; i++)
        {
            tasksOnTerminals[i] = Random.Range(0, taskMain.games.Length);
            //tasksOnTerminals[i] = 2;
            completedTasks[i] = false;
        }
    }



}
