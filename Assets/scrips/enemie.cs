using UnityEngine;

public class enemie : MonoBehaviour
{
    private float coolDown = 0;
    void Start()
    {
        
    }

   
    void Update()
    {
        
 
coolDown -= Time.deltaTime;
        
            if (coolDown <= 0f)
            {
                other.GetComponent <PlayerMain>().playerHealth -= 10;
            }
        
    }
    void OnTriggerStay(Collider other)
    {
        if (other.tag == "player")
        {
           other.GetComponent <PlayerMain>().playerHealth -= 10;
           coolDown = 1;
        }
    }
}
