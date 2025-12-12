using UnityEditor;
using UnityEngine;

public class Movement : MonoBehaviour
{    
    Settings settings;
    OpenUI ui;
    private float sprint_spd;
    public float speed;
    void Start()
    {
       settings = GetComponent<Settings>();
       ui = GetComponent<OpenUI>();
    }
    
    void Update()
    {
        speed = 12f * sprint_spd;
        if (!ui.inUI)
        {
           Move(); 
        }
    }
    void Move()
    {
        if (Input.GetKey(settings.set_forward))
        {
            transform.position = transform.position + transform.forward * Time.deltaTime * speed;
        }

        if (Input.GetKey(settings.set_backwards))
        {
            transform.position = transform.position - transform.forward * Time.deltaTime * speed;
        }

        if (Input.GetKey(settings.set_left))
        {
            transform.position = transform.position - transform.right * Time.deltaTime * speed;
        }

        if (Input.GetKey(settings.set_right))
        {
            transform.position = transform.position + transform.right * Time.deltaTime * speed;
        }

        if (Input.GetKey(settings.set_sprint))
        {
            sprint_spd = 1.3f;  //2f = 2x min 1.0f sonst langsamer
        }   
        else 
        {
            sprint_spd = 1f; 
        }

        if (Input.GetKey(settings.set_jump))
        {
            //movement springen

        }
    }
}   