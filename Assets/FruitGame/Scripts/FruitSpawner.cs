using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitSpawner : MonoBehaviour
{

    public GameObject[] spawnables;
    public float spawnTime = 1.5f;
    public float range = 8;
    private float counter = 0;

    void Update()
    {
        counter += Time.deltaTime;
        if (counter > spawnTime)
        {
            counter = 0;
            float x = Random.Range(range * -1, range);
            int r = Random.Range(0,spawnables.Length);
            Instantiate(spawnables[r], new Vector3(x, transform.position.y, 0), Quaternion.identity);
        }
    }
}
