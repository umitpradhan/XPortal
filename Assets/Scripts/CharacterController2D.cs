using UnityEngine;
using UnityEngine.Events;
using UnityStandardAssets.CrossPlatformInput;

public class CharacterController2D : MonoBehaviour
{
	[SerializeField] private float jumpForce = 400f;                          
             
    [Range(0, .3f)] [SerializeField] private float movementSmoothing = 0.05f;	
	[SerializeField] private bool airControl = false;							
	[SerializeField] private LayerMask whatIsGround;                          
	//[SerializeField] private LayerMask whatIsLedge;
	[SerializeField] private Transform groundCheck;							
	[SerializeField] private Transform ceilingCheck;                          
	//[SerializeField] private Transform faceFrontCheck;
	//[SerializeField] private Transform headUpFrontCheck;

	//public GameObject detectedWall;
	//public GameObject grabbedWall;

	//public Transform wallGrabPoint;
	//public float grabbedWallXValue;

	//const float faceFrontRadius = 0.2f;
	//const float headUpFrontRadius = 0.2f;
	const float groundedRadius = 0.2f; 
	private bool grounded;            
    const float ceilingRadius = 0.2f; 
    private Rigidbody2D _rigidbody2D;
	private bool facingRight = true;  
	private Vector3 velocity = Vector3.zero;
	//private bool isWallGrabbing = false;
	

	[Header("Events")]
	[Space]

	public UnityEvent OnLandEvent;





	private void Awake()
	{
		_rigidbody2D = GetComponent<Rigidbody2D>();

		if (OnLandEvent == null)
			OnLandEvent = new UnityEvent();
	}

 //   void Update()
 //   {
	//	if (DetectWall())
	//	{
	//		if (CrossPlatformInputManager.GetButtonDown("LedgeGrab"))
	//		{
	//			if (isWallGrabbing)
	//			{
	//				GrabWall();
	//				return;
	//			}
	//			detectedWall.GetComponent<Item>().Interact();
	//		}
	//	}
	//}

    private void FixedUpdate()
	{
		bool wasGrounded = grounded;
		grounded = false;
				
		Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheck.position, groundedRadius, whatIsGround);
		for (int i = 0; i < colliders.Length; i++)
		{
			if (colliders[i].gameObject != gameObject)
			{
				grounded = true;
				if (!wasGrounded)
					OnLandEvent.Invoke();
			}
		}
	}

	public void Move(float move, bool jump)	
	{ 		       
        if (grounded || airControl)
		{		
            Vector3 targetVelocity = new Vector2(move * 10f, _rigidbody2D.velocity.y);			
			_rigidbody2D.velocity = Vector3.SmoothDamp(_rigidbody2D.velocity, targetVelocity, ref velocity, movementSmoothing);
                        
            if (move > 0 && !facingRight)
			{
				
				Flip();
			}			
			else if (move < 0 && facingRight)
			{
				
				Flip();
			}
		}		
		if (grounded && jump)
		{
			grounded = false;
			_rigidbody2D.AddForce(new Vector2(0f, jumpForce));
		}
	}

   

    private void Flip()
	{		
		facingRight = !facingRight;
				
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}

	//private void OnDrawGizmosSelected()
	//{
	//	Gizmos.color = Color.red;
	//	Gizmos.DrawSphere(headUpFrontCheck.position, headUpFrontRadius);
	//	Gizmos.color = Color.green;
	//	Gizmos.DrawSphere(faceFrontCheck.position, faceFrontRadius);
	//}

	//bool DetectWall()
	//{
	//	Collider2D obj;
 //       if (Physics2D.OverlapCircle(faceFrontCheck.position, faceFrontRadius, whatIsLedge) && !Physics2D.OverlapCircle(headUpFrontCheck.position, headUpFrontRadius, whatIsLedge));
 //       {
	//		obj = Physics2D.OverlapCircle(faceFrontCheck.position, faceFrontRadius, whatIsLedge);

	//		if (obj == null)
	//		{
	//			detectedWall = null;
	//			return false;
	//		}
	//		else
	//		{
	//			detectedWall = obj.gameObject;
	//			return true;
	//		}
	//	}
		
	}

    //	public void GrabWall()
    //	{

    //		if (isWallGrabbing)
    //		{
    //			isWallGrabbing = false;
    //			grabbedWall.transform.parent = null;

    //			grabbedWall = null;
    //		}
    //		else
    //		{
    //			isWallGrabbing = true;
    //			grabbedWall = detectedWall;
    //			grabbedWall.transform.parent = transform;
    //			grabbedWallXValue = faceFrontCheck.transform.position.x;
    //			grabbedWall.transform.localPosition = wallGrabPoint.localPosition;

    //			Move(FindObjectOfType<PlayerMovement>().horizontalMove * Time.fixedDeltaTime, FindObjectOfType<PlayerMovement>().jump);

    //		}
    //	}


