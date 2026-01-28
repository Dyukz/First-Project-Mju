using UnityEngine;

public class CreateScore : MonoBehaviour
{   
    public Score score;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void OnEnable()
    {
        score.TimeToScore();
    }
}
