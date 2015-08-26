using UnityEngine;
using System.Collections;

public class EnemyScript : MonoBehaviour {

	public float moveSpeed;
	public float jumpStrength = 400.0f;
	public float knockBackForce;
	
	private Animator anim;
	private int enemyState;
	private bool grounded;
	private Transform groundCheck;
	private bool attacked;
	
	// Use this for initialization
	void Start () {
		anim = GetComponent <Animator>();
		enemyState = Constants.ENEMY_RUNNING;
		groundCheck = transform.Find("GroundCheck");
		attacked = false;
	}
	
	// Update is called once per frame
	void Update () {
		
		// Keep moving right
		float moveDistance = moveSpeed * Time.deltaTime;

		
		grounded = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));
		
		switch (enemyState) {
			
		case Constants.ENEMY_RUNNING:
			transform.Translate(-Vector3.right * moveDistance);

			if (!attacked)
			{
				checkPunch();
			}
			break;

		case Constants.ENEMY_ATTACKING:
			
			if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !anim.IsInTransition(0))
			{
				enemyState = Constants.ENEMY_RUNNING;
				attacked = true;
				
				anim.StopPlayback();
				anim.Play("Run");
			}
			
			break;
		}
	}

	private void checkPunch()
	{
		// Find player position
		GameObject player = GameObject.Find("Player");
		float xDistance = (this.transform.position.x - player.transform.position.x);
		float yDistance = Mathf.Abs(this.transform.position.y - player.transform.position.y);

		if (yDistance < 1.0)
		{
			if (xDistance > 0.0 && xDistance < Constants.ATTACK_DISTANCE)
			{
				anim.StopPlayback();
				anim.Play("Attack");
				enemyState = Constants.ENEMY_ATTACKING;
			}
		}
	}

	private void HandleCollision (string otherObjectTag) {

		if (otherObjectTag == "PlayerHitCollision") {

			enemyState = Constants.ENEMY_HIT;
			rigidbody2D.AddForce(new Vector2(knockBackForce, knockBackForce));
			anim.Play ("Falling", 0);
		}
	}

	private void HandleObjectOffScreen()
	{
		this.gameObject.SetActive (false);
	}

}
