using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class CustomTrigger : MonoBehaviour
{
    public GameObject Door;
    private void Reset()
    {
        GetComponent<BoxCollider2D>().isTrigger = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Item")
        {
            Door.SetActive(true) ;
        }
    }
    //private void OnTriggerExit2D(Collider2D collision)
    //{
    //    if(collision.tag != "Item")
    //    {
    //        Door.SetActive(false);
    //    }
    //}
}
