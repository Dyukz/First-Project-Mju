using UnityEngine;
 
public class Boss : MonoBehaviour
{  
    public GameObject waypointParent;
    public float speed = 0.5f;

    private int waypoints = 0;
    private int temp = 0;
    private GameObject currentPoint;
    void Start()
    {
        waypoints = waypointParent.transform.childCount;
        currentPoint = waypointParent.transform.GetChild(0).gameObject;
        transform.LookAt(currentPoint.transform);
        temp = 0;
    }

    void Update()
    {   
        if (difference(currentPoint) >= 0.2f)
        {
            transform.position += transform.forward * speed * Time.deltaTime;
        }
        else NewTarget(temp);
    }

    void NewTarget(int oldPos)
    {   
        if (oldPos == waypoints)
        {
            return;
        }
        currentPoint = waypointParent.transform.GetChild(oldPos +1).gameObject;
        transform.LookAt(currentPoint.transform);
        temp = oldPos +1;
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
 
            player.playerHealth -= 999999;
        }
    }
    
    float difference(GameObject waypoint)
    {
        Vector3 pos = transform.position;
        Vector3 wptPos = waypoint.transform.position;

        float diff = (pos - wptPos).magnitude;
        return diff;
    }
    
}