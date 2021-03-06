using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(CircleCollider2D))]
public class Item : MonoBehaviour
{
    public enum InteractionType { NONE, GrabDrop }
    public enum ItemType { Static, Consumables }
    [Header("Attributes")]
    public InteractionType interactType;
    public ItemType type;
    
    [Header("Custom Events")]
    public UnityEvent customEvent;
    public UnityEvent consumeEvent;

    private void Reset()
    {
        GetComponent<Collider2D>().isTrigger = true;
        gameObject.layer = 8;
    }

    public void Interact()
    {
        switch (interactType)
        {
            
            case InteractionType.GrabDrop:
                //Grab interaction
                FindObjectOfType<InteractionSystem>().GrabDrop();
                break;
            default:
                Debug.Log("NULL ITEM");
                break;
        }

        //Invoke (call) the custom event(s)
        customEvent.Invoke();
    }
}