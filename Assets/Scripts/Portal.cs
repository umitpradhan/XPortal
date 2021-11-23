using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    private Rigidbody2D enteredRigidbody;
    
    private float enterVelocity;
    private float exitVelocity;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        enteredRigidbody = collision.gameObject.GetComponent<Rigidbody2D>();        
        enterVelocity = enteredRigidbody.velocity.x;
        
        if (gameObject.name == "PortalOnCont")
        {
            PortalControl.portalControlInstance.DisableCollider("PortalOff");
            PortalControl.portalControlInstance.CreateClone("atPortalOff");
        }
        else if (gameObject.name == "PortalOffCont")
        {
            PortalControl.portalControlInstance.DisableCollider("PortalOn");
            PortalControl.portalControlInstance.CreateClone("atPortalOn");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        exitVelocity = enteredRigidbody.velocity.x;
        
        if (enterVelocity != exitVelocity)
        {
            Destroy(GameObject.Find("Clone"));
            
        }
        else if (gameObject.name != "Clone" )
        {
            Destroy(collision.gameObject);
            PortalControl.portalControlInstance.EnableColliders();
            GameObject.Find("Clone").name = "Player";
            
        }
    }
}
