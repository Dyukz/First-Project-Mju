using JetBrains.Annotations;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{   
    public TMP_Text text;
    float score ;
    float time;

    public void TimeToScore()
    {   
        time = GetComponent<Timer>().time;
        Debug.Log(time);
        score = 110-(time/12); //140 --> 8min dannach score - min*60/12
        score = Mathf.Clamp(score, 0, 100);
        score = Mathf.Floor(score);
        text.text = "Score "+score;
        text.gameObject.SetActive(true);
    }
}
