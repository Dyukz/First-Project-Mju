using JetBrains.Annotations;
using UnityEngine;

public class Score : MonoBehaviour
{   
    float time;
    void Start()
    {
        time = GetComponent<Timer>().time;
    }

    void TimeToScore()
    {
        
    }
}
