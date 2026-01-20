using UnityEngine;
using UnityEngine.UI;

public class Damageable : MonoBehaviour
{   
    
    public float life = 100;
    public GameObject loot;

    private Slider healthbar;
    private Slider healthSlider;
    private GameObject canvas;
    private float killHealthbar = 0;
    private float maxLife = 100;

    void Start()
    {   
        GameObject canvasPrefab = Resources.Load<GameObject>("Prefabs/CodeNeeded/Canvas");
        canvas = Instantiate(canvasPrefab, transform.position, transform.rotation, gameObject.transform);

        healthbar = Resources.Load<Slider>("Prefabs/CodeNeeded/Healthbar");
        maxLife = life;
    }

    void Update()
    {
        killHealthbar += Time.deltaTime;
        if (killHealthbar >= 3 && healthSlider != null)
        {
            Destroy(healthSlider.gameObject);
            healthSlider = null;
        }
        else if (healthSlider != null)
        {
            healthSlider.transform.LookAt(Camera.main.transform);
        }
        
    }

    // when hit
    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "bullet")
        {
            TakeDamage(collision.GetComponent<Bullet>().damage);

            Destroy(collision.gameObject);
            
            if (life <= 0)
            {
                Die();
            }
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }
   
   void TakeDamage(float damage)
    {   
        if (healthSlider == null)
        {   
            Vector3 pos = new Vector3(transform.position.x, transform.position.y + 1.5f, transform.position.z);
            healthSlider = Instantiate(healthbar, pos, transform.rotation, canvas.transform);
            healthSlider.maxValue = maxLife;
        }

        life -= damage;
        healthSlider.value = life;
        killHealthbar = 0;
    }
}
