using UnityEngine;
using System.Collections.Generic;
public class Bild : MonoBehaviour
{
    public List<Sprite> jeffrey;
    public GameObject bild;

    void Update () {
        int health = GetComponent<Damageable>().life;
        health = Mathf.FloorToInt(health / 10);

        bild.Image = jeffrey[health];
}
}