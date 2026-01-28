using JetBrains.Annotations;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{   
    public TMP_Text text;
    float score ;
    float time;
    void Start()
    {
        time = GetComponent<Timer>().time;
    }

    public void TimeToScore()
    {
        score = 140-(time/12);
        score = Mathf.Clamp(score, 0, 100);
        score = Mathf.Floor(score);
        text.text = ""+score;
        text.gameObject.SetActive(true);
    }
}
