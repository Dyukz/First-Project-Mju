using UnityEngine;

public class Bullet : MonoBehaviour
{   
    public int speed = 20;
    public int lifetime = 5;
    public int damage = 10;
    
    void Start()
    {
        Destroy(gameObject, lifetime);
    }

    void Update()
    {
        transform.position +=  transform.forward * Time.deltaTime * speed;
    }
}
