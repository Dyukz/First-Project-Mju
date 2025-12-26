using Unity.VisualScripting;
using UnityEngine;

public class Mirror : MonoBehaviour
{
    public GameObject[] player;
    public GameObject mirror;
    
    private int mirrorOn = 0;
    private float speed = 2f;
    void Update()
    {
        Movement();
        if (Input.GetKeyDown("f"))
        {
            SwitchMirror();
        }
    }
    void Movement()
    {
        if (Input.GetKey("w")) 
        {
            player[mirrorOn].transform.position += new Vector3(0, 1, 0) * speed * Time.deltaTime;
        }
        if (Input.GetKey("s")) 
        {
            player[mirrorOn].transform.position += new Vector3(0, -1, 0) * speed * Time.deltaTime;
        }
        if (Input.GetKey("a")) 
        {
            player[mirrorOn].transform.position += new Vector3(-1, 0, 0) * speed * Time.deltaTime;
        }
        if (Input.GetKey("d")) 
        {
            player[mirrorOn].transform.position += new Vector3(1, 0, 0) * speed * Time.deltaTime;
        }
    }

    void SwitchMirror()
    {   
        if (mirrorOn == 0)
            {
                mirrorOn = 1;
                mirror.GetComponent<SpriteRenderer>().color = new Color32(165, 65, 65, 255); //rot
            }
            else
            {
                mirrorOn = 0;
                mirror.GetComponent<SpriteRenderer>().color = new Color32(150, 193, 90, 255); //gruen
            }
            
    }
}
