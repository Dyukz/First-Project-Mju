using UnityEngine;
using TMPro;

public class Melody : MonoBehaviour
{
    
    public RectTransform slider;
    public RectTransform target;
    public TMP_Text scoreText;
    public Canvas canvas;
    public float speed = 700f;
    public float maxScore = 5f;
    
    private float direction = 1f;
    private float limit = 500f;
    private float score = 0;
    private float size = 50;


    public void Reset()
    {   
        score = 0;
        scoreText.text = "" + score + " / " + maxScore;
        NewTarget();
    }
    void Update()
    {
        SliderMove();
        if (Input.GetKeyDown("f"))
        {
            if (TestIfOn())
            {
                score++;
            }
            else
            {
                score = 0;
            }

            scoreText.text = "" + score + " / " + maxScore;
            NewTarget();
            
            if (score >= maxScore)
        {
            GameWin();
        }
        }
        
    }
    void NewTarget()
    {   
        switch (score)
        {
            case 0:
                size = 200;
                break;
            case 1:
                size = 100;
                break;
            case >= 3:
                size = 50;
                break;
        }

        Vector2 setSize = new Vector2(size, 50);
        target.sizeDelta = setSize;
        float randomTarget = Random.Range(limit * -1 + 50, limit - 50);
        Vector3 setTarget = new Vector3(randomTarget, target.anchoredPosition.y, 0);
        target.anchoredPosition = setTarget;
    }
    
    bool TestIfOn()
    {
        
        if (slider.anchoredPosition.x >= target.anchoredPosition.x - (target.sizeDelta.x / 2) && slider.anchoredPosition.x <= target.anchoredPosition.x + (target.sizeDelta.x / 2))
        {
            return true;
        }
        else return false;
    }
    void SliderMove()
    {
        float pos = slider.anchoredPosition.x;
        float b = pos + speed * direction * Time.deltaTime;
        Vector3 move = new Vector3(b, slider.anchoredPosition.y, 0);
        slider.anchoredPosition = move;
        if (pos > limit && direction == 1|| pos < -limit && direction == -1)
        {
            direction *= -1;
        }
    }
    void GameWin()
    {
        Cursor.lockState = CursorLockMode.Locked;
        canvas.GetComponent<GameUIManager>().ExitGame(0);
    }
}
