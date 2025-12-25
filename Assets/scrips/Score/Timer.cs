using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public TMP_Text timer;
    public float time = 0;

    private float timeSek = 0;
    private float timeMin = 0;

    void Update()
    {
        timeSek += Time.deltaTime;
        time += Time.deltaTime;
        if (timeSek >= 60) 
        {
            timeSek -= 60;
            timeMin++;
        }
        if (Mathf.Floor(timeSek) < 10)
        {
            timer.text = timeMin + " : 0" + Mathf.Floor(timeSek);
        }
        else timer.text = timeMin + " : " + Mathf.Floor(timeSek);
    }
}
