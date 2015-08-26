using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {

	public float moveSpeed;
	public float jumpStrength = 400.0f;

	private Animator anim;
	private bool kickPressed;
	private bool jumpPressed;
	private int playerState;
	private bool grounded;
	private Transform groundCheck;

	// Use this for initialization
	void Start () {
		anim = GetComponent <Animator>();
		playerState = Constants.PLAYER_RUNNING;
		groundCheck = transform.Find("GroundCheck");
	}
	
	// Update is called once per frame
	void Update () {

		// Keep moving right
		float moveDistance = moveSpeed * Time.deltaTime;
		transform.Translate(Vector3.right * moveDistance);

		kickPressed = Input.GetKeyDown(KeyCode.Z);
		jumpPressed = Input.GetKeyDown(KeyCode.X);

		grounded = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));

		switch (playerState) {
		
		case Constants.PLAYER_RUNNING:

			if (kickPressed) {
				doKick ();
			}
			
			if (jumpPressed && grounded)
			{
				doJump();
			}
			break;

		case Constants.PLAYER_KICKING:

			if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !anim.IsInTransition(0))
			{
				playerState = Constants.PLAYER_RUNNING;
				
				anim.StopPlayback();
				anim.Play("Run");
			}
			
			break;

		case Constants.PLAYER_JUMPING:

//			transform.position.x +=  moveSpeed * Time.deltaTime;
			
			if (grounded)
			{
				playerState = Constants.PLAYER_RUNNING;
				anim.Play("Run");
			}
			
			break;
		}
	}
	
	private void doKick()
	{
		anim.StopPlayback();	
		playerState = Constants.PLAYER_KICKING;
//		AudioSource.PlayClipAtPoint(attackSound, this.transform.position);
		
//		attackMove = Constants.ATTACK_KICK;
		anim.Play("Kick");
	}
	
	private void doJump()
	{
		anim.StopPlayback();	
		playerState = Constants.PLAYER_JUMPING;
		rigidbody2D.AddForce(new Vector2(0f, jumpStrength));
		anim.Play("Jump");
//		AudioSource.PlayClipAtPoint(jumpSound, this.transform.position);
	}
}
