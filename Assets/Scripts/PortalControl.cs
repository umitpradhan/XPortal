using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalControl : MonoBehaviour
{
    public static PortalControl portalControlInstance;
       
    [SerializeField] private GameObject portalOn;
    [SerializeField] private GameObject portalOff;
        
    [SerializeField] private Transform portalOnSpawnPoint;
    [SerializeField] private Transform portalOffSpawnPoint;
        
     private Collider2D portalOnCollider;
     private Collider2D portalOffCollider;
       
    [SerializeField] private GameObject clone;
   

    void Start()
    {
        portalControlInstance = this;
        portalOnCollider = portalOn.GetComponent<Collider2D>();
        portalOffCollider = portalOff.GetComponent<Collider2D>();        
    }

    public void CreateClone(string whereToCreate)
    {
        if (whereToCreate == "atPortalOn")
        {
            var instantiatedClone = Instantiate(clone, portalOnSpawnPoint.position, Quaternion.identity);
            instantiatedClone.gameObject.name = "Clone";
            
        }
        else if(whereToCreate == "atPortalOff")
        {
            var instantiatedClone = Instantiate(clone, portalOffSpawnPoint.position, Quaternion.identity);
            instantiatedClone.gameObject.name = "Clone";
            
        }
    }

    public void DisableCollider(string colliderToDisable)
    {
        if (colliderToDisable == "PortalOn")
        {
            portalOnCollider.enabled = false;
        }
        else if (colliderToDisable == "PortalOff")
        {
            portalOffCollider.enabled = false;
        }
    }

    public void EnableColliders()
    {
        portalOnCollider.enabled = true;
        portalOffCollider.enabled = true;
    }
}
