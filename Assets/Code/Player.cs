using UnityEngine;
using System.Collections;

public class Player : Humanoid {

	private	PlayerInput playerInput;
 
	public override void Start () {
		base.Start ();
		playerInput = GetComponent <PlayerInput>();
	}
	
	public override void checkAndRunState () {
		
		bool kickPressed = playerInput.isKickPressed();
		bool jumpPressed = playerInput.isJumpPressed();


		base.checkAndRunState ();

		switch (state) 
		{
		case Constants.RUNNING:
			
			moveForward();

			if (kickPressed) {
				doKick ();
			}
			
			if (jumpPressed && grounded)
			{
				jump();
			}
			break;

		case Constants.ATTACKING:
			
			moveForward();

			if (hasAnimationFinished())
			{
				switchToState(Constants.RUNNING);
				
				anim.StopPlayback();
				anim.Play("Run");
			}
			
			break;

		case Constants.JUMPING:
			
			moveForward();

			if (grounded)
			{
				switchToState(Constants.RUNNING);
				anim.Play("Run");
			}
			
			break;
		}
	}

	private void moveForward()
	{
		float moveDistance = moveSpeed * Time.deltaTime;
		transform.Translate(Vector3.right * moveDistance);
	}

	private void doKick()
	{
		anim.StopPlayback();	
		switchToState(Constants.ATTACKING);
//		AudioSource.PlayClipAtPoint(attackSound, this.transform.position);
		anim.Play("Kick");
	}
	
	private void MakeHumanFall (string otherObjectTag) {
		
		if (otherObjectTag == "EnemyHitCollision") {
			base.takeHitAndFall();
		}
	}
}
