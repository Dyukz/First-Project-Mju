using UnityEngine;

public class bullet : MonoBehaviour
{
    public int lifetime = 5;
    void Start()
    {
        Destroy(gameObject, lifetime);
    }

    
    void Update()
    {
        transform.position +=  transform.forward * Time.deltaTime * 5;
    }
}
