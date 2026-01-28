using JetBrains.Annotations;
using UnityEngine;

public class Score : MonoBehaviour
{   
    float score ;
    float time;
    void Start()
    {
        time = GetComponent<Timer>().time;
    }

    public void TimeToScore()
    {
     score = 140-(time/12);
       score = Mathf.Floor(score);
    }
}
