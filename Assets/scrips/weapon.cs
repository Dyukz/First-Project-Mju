using UnityEngine;

public class weapon : MonoBehaviour
{
    public GameObject kamera;
    public GameObject bullet;
    public GameObject player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
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
