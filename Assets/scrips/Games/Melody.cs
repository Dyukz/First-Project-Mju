using UnityEngine;

public class Melody : MonoBehaviour
{
    
    public RectTransform slider;
    public RectTransform target;

    private float direction = 1f;
    private float limit = 500f;

    void Update()
    {
        SliderMove();
        if (Input.GetKeyDown("f"))
        {
            TestIfOn();
            float randomTarget = Random.Range(limit * -1 + 50, limit - 50);
            Vector3 setTarget = new Vector3(randomTarget, target.anchoredPosition.y, 0);
            target.anchoredPosition = setTarget;
        }
    }
    
    void Start()
    {   
        Cursor.lockState = CursorLockMode.None;
    }

    void TestIfOn()
    {
        
        if (slider.anchoredPosition.x >= target.anchoredPosition.x - (target.sizeDelta.x / 2) && slider.anchoredPosition.x <= target.anchoredPosition.x + (target.sizeDelta.x / 2))
        {
            print("JJAAA");
        }
        else print("NEIN");
    }
    
    void SliderMove()
    {
        float pos = slider.anchoredPosition.x;
        float b = pos + 1f * direction;
        Vector3 move = new Vector3(b, slider.anchoredPosition.y, 0);
        slider.anchoredPosition = move;
        if (pos > limit && direction == 1|| pos < -limit && direction == -1)
        {
            direction *= -1;
        }
    }
}
