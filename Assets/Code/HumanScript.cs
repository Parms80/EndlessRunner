using UnityEngine;
using System.Collections;

public class HumanScript : MonoBehaviour {

	public float moveSpeed;
	public float jumpStrength = 400.0f;
	
	private Animator anim;
	private int state;
	private Transform groundCheck;
	private bool grounded;
	
	void Start () {
		anim = GetComponent <Animator>();
		state = Constants.RUNNING;
		groundCheck = transform.Find("GroundCheck");
	}

	void Update () {
		grounded = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));

	}

	void runForward() {
		float moveDistance = moveSpeed * Time.deltaTime;
		transform.Translate(Vector3.right * moveDistance);
	}

	void jump() {
		anim.StopPlayback();	
		state = Constants.JUMPING;
		rigidbody2D.AddForce(new Vector2(0f, jumpStrength));
		anim.Play("Jump");
	}

	void takeHit() {
	}

	void fall() {
	}
}
