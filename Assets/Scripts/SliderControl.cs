using UnityEngine;
using System.Collections;

public class SliderControl : MonoBehaviour {

	public float moveSpeed = 10;
	public float jumpHeight = 10;
	public KeyCode fire;
	private bool grounded = false;			// Whether or not the player is grounded.
	public bool jump = false;	
	public float jumpForce = 1000f;			// Amount of force added when the player jumps.

	private float distToGround;

	void Start()
	{
		distToGround = 0f;
	}
	// Update is called once per frame
	void Update () {
		Vector3 newpos = transform.position;
		newpos.x += moveSpeed * Time.deltaTime;

		if (newpos.x > 24.7f) 
		{
			int nextLevel = Application.loadedLevel;
			nextLevel++;
			Application.LoadLevel(nextLevel);
		}
		// The player is grounded if a linecast to the groundcheck position hits anything on the ground layer.
		grounded = IsGrounded ();
		
		// If the jump button is pressed and the player is grounded then the player should jump.
		if ((Input.GetButtonDown ("Jump") || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)) && grounded) {
				Debug.Log("Jump Pressed");
			Debug.Log(distToGround);
						jump = true;
				}
		transform.position = newpos  ;

	}

	void FixedUpdate ()
	{
		if(jump)
		{			
			// Add a vertical force to the player.
			rigidbody2D.AddForce(new Vector2(0f, jumpForce));
			
			// Make sure the player can't jump again until the jump conditions from Update are satisfied.
			jump = false;
		}
	}

	bool IsGrounded() {
		return Physics2D.Raycast(new Vector2(transform.position.x,transform.position.y), -Vector2.up, 0.5f,1<<LayerMask.NameToLayer("Ground"));
	}
}
