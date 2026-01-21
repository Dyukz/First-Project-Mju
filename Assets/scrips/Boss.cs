using UnityEngine;
 
public class Boss : MonoBehaviour
{  
    public GameObject waypointParent;
    public float speed = 0.5f;
    void Start()
    {
        int waypoints = waypointParent.transform.childCount;
 
        for (int i=0; i < waypoints; i++)
        {  
            GameObject currentPoint = waypointParent.transform.GetChild(i).gameObject;
            transform.LookAt(currentPoint.transform);
 
            while (difference(currentPoint))
            {
                transform.position = transform.forward * speed * Time.deltaTime;
            }
        }
    }
 
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "player")
        {
            PlayerMain player = other.GetComponent<PlayerMain>();
            if (player == null)
            {
                return;
            }
 
            player.playerHealth += -999999;
        }
    }
 
    
}