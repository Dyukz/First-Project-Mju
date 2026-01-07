using UnityEngine;

public class enemie : MonoBehaviour
{
    private float coolDown = 1;
    void Start()
    {
        
    }

   
    void Update()
    {
    coolDown += Time.deltaTime;
    }

    void OnTriggerStay(Collider other)
    {
        if (other.tag == "player")
        {

            if (coolDown >= 2f)
            {
                other.GetComponent<PlayerMain>().playerHealth -= 10;
                coolDown = 0;
            }
            
           
        }
    }
}
