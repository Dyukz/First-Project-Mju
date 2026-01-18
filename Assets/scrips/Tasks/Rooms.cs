using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Rooms : MonoBehaviour
{   
    public Tasks taskMain;
    
    public GameObject tasksParent;

    private bool[] completedTasks;
    private int[] tasksOnTerminals;
    
    public int roomId = 0;

    void Start()
    {   
        int terminalCount = tasksParent.transform.childCount;
        
        //Setup the Arraylength based on the Terminalcount
        completedTasks = new bool[terminalCount];
        tasksOnTerminals = new int[terminalCount];

        //Setting the game for each terminal && Completion State
        for (int i=0; i <terminalCount; i++)
        {
            tasksOnTerminals[i] = Random.Range(0, taskMain.games.Length);
            completedTasks[i] = false;
        }

        roomId = transform.GetSiblingIndex();
    }

    public void OnRoomStart()
    {   
        Canvas canvasPrefab = Resources.Load<Canvas>("Prefabs/CodeNeeded/Canvas");
        GameObject terminalText = Resources.Load<GameObject>("Prefabs/CodeNeeded/TerminalText");

        int terminalCount = tasksParent.transform.childCount;

        for (int i=0; i < terminalCount; i++)
        {
            Transform currentTerminal = tasksParent.transform.GetChild(i);
            Canvas canvas = Instantiate(canvasPrefab, currentTerminal.position, currentTerminal.rotation, currentTerminal);
            
            Vector3 pos = new Vector3(currentTerminal.position.x, currentTerminal.position.y + 1.5f, currentTerminal.position.z);
            Instantiate(terminalText, pos, transform.rotation, canvas.transform);
        }
    }

    public bool TryOpenTask(int task)
    {
        if (!completedTasks[task])
        {   
            taskMain.games[tasksOnTerminals[task]].SetActive(true);
            return true;
        }
        return false;
    }

    public bool TaskCompleted(int task)
    {
        completedTasks[task] = true;

        Transform currentTerminal = tasksParent.transform.GetChild(task);
        TMP_Text text = currentTerminal.GetChild(0).transform.GetChild(0).GetComponent<TMP_Text>();
        text.text = "Active Terminal";
        text.color = Color.green;

        int terminalCount = tasksParent.transform.childCount;
        for (int i=0; i < terminalCount; i++)
        {
            if (!completedTasks[i])
            {
                return false;
            }
        }
        return true;
    }

    public void CloseGame(int task)
    {
        taskMain.games[tasksOnTerminals[task]].SetActive(false);
    }
}
