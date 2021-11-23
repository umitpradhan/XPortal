using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.UI;

public class InteractionSystem : MonoBehaviour
{
    
    public Transform detectionPoint;    
    private const float detectionRadius = 0.2f;    
    public LayerMask detectionLayer;    
    public GameObject detectedObject;
    
    
    
    public GameObject grabbedObject;
    public float grabbedObjectYValue;
    public Transform grabPoint;   
    public bool isGrabbing;

    

    
    void Update()
    {
        
        if (DetectObject())
        {
            if (InteractInput())
            {                
                if (isGrabbing)
                {
                    GrabDrop();
                    return;
                }
                detectedObject.GetComponent<Item>().Interact();
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawSphere(detectionPoint.position, detectionRadius);
    }

    bool InteractInput()
    {
        return  CrossPlatformInputManager.GetButtonDown("Grab");
    }

    bool DetectObject()
    {
        Collider2D obj = Physics2D.OverlapCircle(detectionPoint.position, detectionRadius, detectionLayer);

        if (obj == null)
        {
            detectedObject = null;
            return false;
        }
        else
        {
            detectedObject = obj.gameObject;
            return true;
        }
    }

    

    public void GrabDrop()
    {
        
        if (isGrabbing)
        {           
            isGrabbing = false;            
            grabbedObject.transform.parent = null;            
            grabbedObject.transform.position = new Vector3(grabbedObject.transform.position.x, grabbedObjectYValue, grabbedObject.transform.position.z);            
            grabbedObject = null;
        }        
        else
        {            
            isGrabbing = true;            
            grabbedObject = detectedObject;            
            grabbedObject.transform.parent = transform;            
            grabbedObjectYValue = grabbedObject.transform.position.y;                                    
            grabbedObject.transform.localPosition = grabPoint.localPosition;
        }
    }
}