using System;
using UnityEngine;
using TMPro;
using NUnit.Framework;

public class OrderButtons : MonoBehaviour
{   
    private OrderMain main;
    private bool isOn = false;

    void Awake()
    {
        main = transform.parent.gameObject.GetComponentInParent<OrderMain>();
        gameObject.GetComponent<UnityEngine.UI.Image>().color = Color.red;
    }

    public void SetValue(int value)
    {
        TMP_Text text = gameObject.transform.GetChild(0).GetComponent<TMP_Text>();
        text.text = "" + value;
        gameObject.GetComponent<UnityEngine.UI.Image>().color = Color.red;
        isOn = false;
    }

    public void Click()
    {   
        int button = transform.GetSiblingIndex();
        isOn = main.Check(button);

        if  (isOn)
        {
            gameObject.GetComponent<UnityEngine.UI.Image>().color = Color.green;
        }
    }
}
