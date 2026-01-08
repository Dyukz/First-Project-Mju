using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class PanesMain: MonoBehaviour
{   
    public GameObject buttonParent;
    public Tasks manager;
    public GameObject buttonPrefab;

    private int maxButtons = 0;
    private int currentOn = 0;

    void OnEnable()
    {   
        Cursor.lockState = CursorLockMode.None;
        CreateButtons();
        maxButtons = buttonParent.transform.childCount;
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
        int columns = 7;
        int rows = 3;

        for (int y = 0; y < rows; y++)
        {
            for (int x = 0; x < columns; x++)
            {
                GameObject obj = Instantiate(buttonPrefab, buttonParent.transform);

                PanesButton pb = obj.GetComponent<PanesButton>();
                pb.SetMain(this);
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
