using TMPro;
using Unity.Mathematics;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public TMP_Text timer;
    public float time = 0;

    private float timeSek = 0;
    private float timeMin = 0;

    void Update()
    {
        time += Time.deltaTime;

        timeMin = Mathf.Floor(time / 60);
        timeSek = Mathf.Floor((time / 60 - timeMin) * 60);

        if (timeSek < 10)
        {
            timer.text = timeMin + " : 0" + Mathf.Floor(timeSek);
        }
        else timer.text = timeMin + " : " + Mathf.Floor(timeSek);
    }
}
