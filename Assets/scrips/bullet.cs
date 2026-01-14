using UnityEngine;

public class bullet : MonoBehaviour
{   
    public int speed = 20;
    public int lifetime = 5;
    void Start()
    {
        Destroy(gameObject, lifetime);
    }

    
    void Update()
    {
        transform.position +=  transform.forward * Time.deltaTime * speed;
    }
}
