using UnityEngine;

public class Damageable : MonoBehaviour
{
    
    public float life = 100;
    public GameObject loot;

    // when hit
    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "bullet")
        {
            life-=10;
            Destroy(collision.gameObject);
            if (life <= 0)
            {
                Die();
            }
        }
    }
    void Die()
    {
        // Instantiate(loot, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
   
}
