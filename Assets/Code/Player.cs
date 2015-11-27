using UnityEngine;
using System.Collections;

public class Player : Humanoid {

	private	PlayerInput playerInput;
 
	public override void Start () {
		base.Start ();
		base.reset ();
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
				anim.Play(Constants.STRING_RUN);
			}
			
			break;

		case Constants.JUMPING:
			
			moveForward();

			if (grounded)
			{
				switchToState(Constants.RUNNING);
				anim.StopPlayback();
				anim.Play(Constants.STRING_RUN);
			}
			
			break;
		}
	}

	private void moveForward()
	{
		float moveDistance = moveSpeed * Time.deltaTime;
		transform.Translate(Vector3.right * moveDistance);;
	}

	private void doKick()
	{
		anim.StopPlayback();	
		switchToState(Constants.ATTACKING);
		anim.Play(Constants.STRING_KICK);
	}
	
	private void MakeHumanFall (string otherObjectTag) {
		
		if (otherObjectTag == Constants.STRING_ENEMYHITCOLLISION) {
			base.takeHitAndFall();
		}
	}
}
