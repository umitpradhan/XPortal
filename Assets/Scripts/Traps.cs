using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class Traps : MonoBehaviour
{
    float decayAmnt = 20;
    private void Reset()
    {
        GetComponent<BoxCollider2D>().isTrigger = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            FindObjectOfType<Health>().LoseHealth(decayAmnt);
        }
    }
}