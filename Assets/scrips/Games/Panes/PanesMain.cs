using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class PanesMain: MonoBehaviour
{   
    public GameObject buttonParent;
    public Tasks manager;
    public GameObject buttonPrefab;
    public int rows = 3;

    private int columns = 0;
    private int maxButtons = 0;
    private int currentOn = 0;

    void Awake()
    {
        CreateButtons();
        columns = buttonParent.GetComponent<GridLayoutGroup>().constraintCount;
    }

    void OnEnable()
    {   
        currentOn = 0;
        Cursor.lockState = CursorLockMode.None;
        maxButtons = buttonParent.transform.childCount;
        for (int i = 0; i < maxButtons; i++)
        {
            buttonParent.transform.GetChild(i).GetComponent<PanesButton>().Init();
        }
    }

    public void Check(int points)
    {   
        currentOn += points;
        if (currentOn == maxButtons)
        {
            CloseGame();
        }
        else return;
    }

    void CreateButtons()
    {
        for (int y = 0; y < rows; y++)
        {
            for (int x = 0; x < columns; x++)
            {
                Instantiate(buttonPrefab, buttonParent.transform);
            }
        }
    }

    void CloseGame()
    {   
        Cursor.lockState = CursorLockMode.Locked;
        gameObject.SetActive(false);
        manager.TaskComplete();
    }
}
