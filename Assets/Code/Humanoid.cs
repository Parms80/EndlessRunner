using UnityEngine;
using System.Collections;

public class Humanoid : MonoBehaviour {

	public float moveSpeed;
	public float jumpStrength = 400.0f;
	public float knockBackForce;
	
	protected Animator anim;
	protected int state;
	private Transform groundCheck;
	protected bool grounded;
	
	public virtual void Start () {
		anim = GetComponent <Animator>();
		switchToState(Constants.RUNNING);
		groundCheck = transform.Find("GroundCheck");
	}

	void Update () {
		grounded = isCharacterOnGround();
		checkAndRunState();

	}

	bool isCharacterOnGround()
	{
		return Physics2D.Linecast(transform.position, 
		                          groundCheck.position, 
		                          1 << LayerMask.NameToLayer("Ground"));
	}

	public virtual void checkAndRunState()	{
	}

	void runForward() {
		float moveDistance = moveSpeed * Time.deltaTime;
		transform.Translate(Vector3.right * moveDistance);
	}

	protected void jump() {
		anim.StopPlayback();	
		switchToState(Constants.JUMPING);
		rigidbody2D.AddForce(new Vector2(0f, jumpStrength));
		anim.Play("Jump");
	}

	protected void takeHitAndFall() {
		switchToState(Constants.TAKE_HIT);
		rigidbody2D.AddForce(new Vector2(knockBackForce, knockBackForce));
		anim.Play ("Falling", 0);
	}

	protected void switchToState(int newState) {
		state = newState;
	}
	
	private void HandleObjectOffScreen()
	{
		this.gameObject.SetActive (false);
	}

	protected bool hasAnimationFinished()
	{
		return anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && 
			!anim.IsInTransition(0);
	}
}
