using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trash : MonoBehaviour
{
    public int speed = 3;
    public GameObject HitSoundPrefab;

    void Update()
    {
        transform.position += Vector3.down * Time.deltaTime * speed;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            if (HitSoundPrefab != null)
            {
                Destroy(Instantiate(HitSoundPrefab, Vector3.zero, Quaternion.identity), 5);
            }            
            Destroy(gameObject);      
        }      
    }
    
}
