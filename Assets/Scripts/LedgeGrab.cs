using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LedgeGrab : MonoBehaviour
{
    private Transform faceFrontCheck;
    private Transform headUpFrontCheck;

    public Rigidbody2D lg_rigidBody2d;

    public LayerMask isGround;
    private float startingGrav;

    private Collider2D c_FaceFront;
    private Collider2D c_HeadUpFront;

    const float faceFrontRadius = 0.2f;
    const float headUpFrontRadius = 0.2f;

    void Start()
    {
        lg_rigidBody2d = GetComponent<Rigidbody2D>();
        startingGrav = lg_rigidBody2d.gravityScale;
        
    }

    
    void Update()
    {       
        c_HeadUpFront = Physics2D.OverlapCircle(headUpFrontCheck.position, headUpFrontRadius, isGround);
        c_FaceFront = Physics2D.OverlapCircle(faceFrontCheck.position, faceFrontRadius, isGround);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(headUpFrontCheck.position, headUpFrontRadius);
        Gizmos.color = Color.green;
        Gizmos.DrawSphere(faceFrontCheck.position, faceFrontRadius);
    }
}
