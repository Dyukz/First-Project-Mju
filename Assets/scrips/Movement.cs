using UnityEngine;

public class Movement : MonoBehaviour
{   
    //Movement default settings; Können in evtl. Settings geändert werden dann
    public string set_forward = "w";
    public string set_left = "a";
    public string set_right = "d";
    public string set_backwards = "s";
    public string set_jump = "space";


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //movement muss ausgeführt werden
        Forward();
    }

    public void Forward()
    {
        bool move_forward = Input.GetKey(set_forward);
        //Debug.Log(move_forward);
        if (move_forward)
        {
            //movement nach vorne
        }
    }
    public void Backwards()
    {
        bool move_backwards = Input.GetKey(set_backwards);
        //Debug.Log(move_backwards);
        if (move_backwards)
        {
            //movement nach hinten
        }
    }
    public void Left()
    {
        bool move_left = Input.GetKey(set_left);
        //Debug.Log(move_left);
        if (move_left)
        {
            //movement nach links
        }
    }
    public void Right()
    
    {
        bool move_right = Input.GetKey(set_right);
        //Debug.Log(move_right);
        if (move_right)
        {
            //movement nach rechts
        }
    }
    public void Jump()
        {
            bool move_jump = Input.GetKey(set_jump);
            //Debug.Log(move_jump);
            if (move_jump)
            {
                //movement springen
            }
        }
}   
