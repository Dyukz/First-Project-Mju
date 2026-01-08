using Microsoft.Unity.VisualStudio.Editor;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class PanesButton : MonoBehaviour
{   
    private PanesMain main;
    private bool isOn = false;
    
    void SetUp()
    {
        float r = Random.Range(1, 4);
        if (r == 1)
        {
            gameObject.GetComponent<UnityEngine.UI.Image>().color = Color.green;
            isOn = true;
            main.Check(1);
        }
        else isOn = false;
        
    }

    public void Click()
    {
        isOn = !isOn;

        if (isOn)
        {
            gameObject.GetComponent<UnityEngine.UI.Image>().color = Color.green;
            main.Check(1);
        }
        else 
        {
            gameObject.GetComponent<UnityEngine.UI.Image>().color = Color.red;
            main.Check(-1);
        }
        
    }

    public void SetMain(PanesMain panesMain)
    {
        main = panesMain;
        SetUp();
    }
}
