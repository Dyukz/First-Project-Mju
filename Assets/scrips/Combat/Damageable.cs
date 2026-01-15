using UnityEngine;
using UnityEngine.UI;

public class Damageable : MonoBehaviour
{   
    public GameObject canvasPrefab;
    public Slider healthbar;
    public float life = 100;
    public GameObject loot;

    Slider healthSlider;
    GameObject canvas;
    private float killHealthbar = 0;

    void Start()
    {
       canvas = Instantiate(canvasPrefab, transform.position, transform.rotation, gameObject.transform);
    }

    void Update()
    {
        killHealthbar += Time.deltaTime;
        if (killHealthbar >= 3 && healthSlider != null)
        {
            Destroy(healthSlider.gameObject);
            healthSlider = null;
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
        }

        life -= damage;
        healthSlider.value = life;
        killHealthbar = 0;
    }
}
