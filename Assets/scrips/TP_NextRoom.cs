using UnityEngine;

public class TP_NextRoom : MonoBehaviour
{
    public int x;
    public int y;
    public int z;

    void OnTriggerEnter(Collider other)
    {
        if (!(other.tag == "player"))
            return;

        Vector3 newPos = new Vector3(x, y, z);
        other.transform.position = newPos;
    }
}
