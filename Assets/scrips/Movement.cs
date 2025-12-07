using UnityEngine;

public class Movement : MonoBehaviour
{   
    //Movement default settings; Können in evtl. Settings geändert werden dann
    
    Settings settings;
    private float sprint_spd;
    public float basespeed = 12f;
    public float speed;
    void Start()
    {
       settings = GetComponent<Settings>(); 
    }
    
    void Update()
    {
        speed = basespeed * sprint_spd;
        Move();
    }
    void Move()
    {
        if (Input.GetKey(settings.set_forward))
        {
            //movement nach vorne
            transform.position = transform.position + transform.forward * Time.deltaTime * speed;
        }

        if (Input.GetKey(settings.set_backwards))
        {
            //movement nach hinten
            transform.position = transform.position - transform.forward * Time.deltaTime * speed;
        }

        if (Input.GetKey(settings.set_left))
        {
            //movement nach links
            transform.position = transform.position - transform.right * Time.deltaTime * speed;
        }

        if (Input.GetKey(settings.set_right))
        {
            //movement nach rechts
            transform.position = transform.position + transform.right * Time.deltaTime * speed;
        }

        if (Input.GetKey(settings.set_sprint))
        {   //sprint
            sprint_spd = 2f;  //1.3f; //2f = 2x min 1.0f sonst langsamer
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