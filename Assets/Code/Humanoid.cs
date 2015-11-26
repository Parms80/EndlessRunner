using UnityEngine;
using System.Collections;

public class Humanoid : MonoBehaviour {

	public float moveSpeed;
	public float jumpStrength;
	public float knockBackForce;
	public AudioClip hitSound;
	
	protected Animator anim;
	protected int state;
	private Transform groundCheck;
	protected bool grounded;
	
	public virtual void Start () {
		anim = GetComponent <Animator>();
		groundCheck = transform.Find(Constants.STRING_GROUNDCHECK);
	}

	public virtual void reset()
	{
		switchToState(Constants.RUNNING);
	}

	void Update () {
		grounded = isCharacterOnGround();
		checkAndRunState();

	}

	bool isCharacterOnGround()
	{
		return Physics2D.Linecast(transform.position, 
		                          groundCheck.position, 
		                          1 << LayerMask.NameToLayer(Constants.STRING_GROUND));
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
		rigidbody2D.AddForce(new Vector2(Constants.HORIZONTAL_JUMP_STRENGTH, 
		                                 jumpStrength));
		anim.Play(Constants.STRING_JUMP);
	}

	protected void takeHitAndFall() {
		switchToState(Constants.TAKE_HIT);
		rigidbody2D.AddForce(new Vector2(knockBackForce, knockBackForce));
		anim.Play (Constants.STRING_FALLING, 0);
		AudioSource.PlayClipAtPoint(hitSound, transform.position);
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

	public int getState()
	{
		return state;
	}
}
