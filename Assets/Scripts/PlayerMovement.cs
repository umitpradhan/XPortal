using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{

	public CharacterController2D controller;
	public Animator playerAnimator;
	

	public float runSpeed = 40f;
	public float horizontalMove = 0f;
	public bool jump = false;
	
    
	  
    
    void Update()
	{
		horizontalMove = CrossPlatformInputManager.GetAxis("Horizontal") * runSpeed;

		playerAnimator.SetFloat("Speed", Mathf.Abs(horizontalMove));

		if (CrossPlatformInputManager.GetButtonDown("Jump"))
		{
			jump = true;
			playerAnimator.SetBool("IsJumping", true);
		}		
		//controller.WallCheck(horizontalMove);
	}	

	public void OnLand()
    {
		playerAnimator.SetBool("IsJumping", false);
    }
	

	void FixedUpdate()
	{
		// Move our character
		controller.Move(horizontalMove * Time.fixedDeltaTime, jump);
		jump = false;
	}	
}