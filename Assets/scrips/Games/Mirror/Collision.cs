using UnityEngine;

public class Collision : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "PreassurePlate")
        {
            col.gameObject.GetComponent<SpriteRenderer>().color = Color.green;
            Transform childtransform = col.gameObject.transform.GetChild(0);
            childtransform.gameObject.SetActive(false);
        }
        if (col.gameObject.tag == "END")
        {
            print("GAME END");
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "PreassurePlate")
        {
            col.gameObject.GetComponent<SpriteRenderer>().color = Color.gray;
            Transform childtransform = col.gameObject.transform.GetChild(0);
            childtransform.gameObject.SetActive(true);
        }
    }
}