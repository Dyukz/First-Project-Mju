using Microsoft.Unity.VisualStudio.Editor;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class PanesButton : MonoBehaviour
{   
    private PanesMain main;
    private bool isOn = false;

    void Awake()
    {
        main = transform.parent.gameObject.GetComponentInParent<PanesMain>();
    }
    public void Init()
    {
        if (Random.Range(1, 4) == 1)
        {
            gameObject.GetComponent<UnityEngine.UI.Image>().color = Color.green;
            isOn = true;
            main.Check(1);
        }
        else
        { 
            isOn = false;
            gameObject.GetComponent<UnityEngine.UI.Image>().color = Color.red;
        }
        
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
}
