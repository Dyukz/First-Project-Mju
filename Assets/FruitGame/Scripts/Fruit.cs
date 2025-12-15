using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour
{
    public int score = 1;
    public float speed = 3;
    public GameObject FruitSoundPrefab;

    void Update()
    {
        transform.position += Vector3.down * Time.deltaTime * speed;
    }   

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            if (FruitSoundPrefab != null)
            {
                Destroy(Instantiate(FruitSoundPrefab, Vector3.zero, Quaternion.identity), 5);
            }            
            Destroy(gameObject);      
        }        
    }
}
