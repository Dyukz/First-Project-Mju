using UnityEngine;
using TMPro;

public class Melody : MonoBehaviour
{
    public RectTransform slider;
    public RectTransform target;
    public TMP_Text scoreText;
    public KeyCode keyCode = KeyCode.F;
    public float speed = 700;
    public float maxScore = 5;
    
    private float direction = 1;
    private float limit = 500;
    private float score = 0;
    private float targetSize = 100;

    void OnEnable()
    {   
        score = 0;
        scoreText.text = "" + score + " / " + maxScore;
        NewTarget();
        Cursor.lockState = CursorLockMode.None;
    }

    void Update()
    {
        SliderMove();
        
        if (Input.GetKeyDown(keyCode))
        {
            HandleScore();
        }
        
    }

    void NewTarget()
    {   
        //Vector2 setSize = new Vector2(size, 50);
        //target.sizeDelta = setSize;
        float randomTarget = Random.Range(limit * -1 + targetSize, limit - targetSize);
    
        Vector3 newTargetPos = new Vector3(randomTarget, target.anchoredPosition.y, 0);
        target.anchoredPosition = newTargetPos;
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

    void HandleScore()
    {
        if (TestIfOn())
        {
            score++;
            NewTarget();
        }
        else
        {
            score = 0;
        }

        scoreText.text = "" + score + " / " + maxScore;
            
        if (score >= maxScore)
        {
            CloseGame();
        }
    }

    void CloseGame()
    {
        gameObject.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
    }
}
