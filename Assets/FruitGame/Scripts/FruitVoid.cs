using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitVoid : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D col)
    {
        Destroy(col.gameObject);
    }
}
