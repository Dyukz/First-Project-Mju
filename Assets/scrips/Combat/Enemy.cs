using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float coolDown = 0;
    void Update()
    {
        coolDown -= Time.deltaTime;
    }

    void OnTriggerStay(Collider other)
    {
        if (other.tag == "player")
        {
            if (coolDown <= 0f)
            {
                other.GetComponent<PlayerMain>().TakeDamage(10);
                coolDown = 1;
            }
        }
    }
}
