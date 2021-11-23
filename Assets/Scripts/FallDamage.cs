using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class FallDamage : MonoBehaviour
{
    
    //public Transform teleportTarget;
    public GameObject Lifes;
    public GameObject Health;
    private void Reset()
    {
        GetComponent<BoxCollider2D>().isTrigger = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.tag == "Player")
        {
            Lifes.SetActive(false);
            Health.SetActive(false);
            FindObjectOfType<GameRestartScreen>().Revive();




        }
    }
}
