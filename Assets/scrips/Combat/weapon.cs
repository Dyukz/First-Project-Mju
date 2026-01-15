using UnityEngine;

public class weapon : MonoBehaviour
{
    public GameObject kamera;
    public GameObject bullet;
    public GameObject player;
    
    void Update()
    {
        if (!player.GetComponent<Tasks>().inTask && Input.GetMouseButtonDown(0))
        {
            shoot();
        }
    }
    void shoot()
    {
        GameObject obj = Instantiate(bullet, kamera.transform.position, kamera.transform.rotation);
    }
}
