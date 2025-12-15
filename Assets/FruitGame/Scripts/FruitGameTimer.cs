using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FruitGameTimer : MonoBehaviour
{
    public TMP_Text timerText;
    public GameObject gameOver;
    private float timer = 60;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;
        gameOver.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {        
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        else
        {
            timer = 0;
            gameOver.SetActive(true);
            Time.timeScale = 0f;
        }
        timerText.text = "" + Mathf.RoundToInt(timer);
    }
}
