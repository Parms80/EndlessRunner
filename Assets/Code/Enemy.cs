using UnityEngine;
using System.Collections;

public class Enemy : Humanoid {

	private bool attacked;

	public override void Start () {
		base.Start ();
		reset();
	}
	public override void reset(){
		switchToState(Constants.RUNNING);
		attacked = false;
	}

	public override void checkAndRunState () {

		base.checkAndRunState ();

		switch (state) 
		{
			case Constants.RUNNING:
				moveForward();

				if (!attacked)
				{
					checkPunch();
				}
				break;

			case Constants.ATTACKING:
				
				if (hasAnimationFinished())
				{
					switchToState(Constants.RUNNING);
					attacked = true;
					
					anim.StopPlayback();
					anim.Play("Run");
				}
				
				break;
		}
	}
	
	private void moveForward()
	{
		float moveDistance = moveSpeed * Time.deltaTime;
		transform.Translate(-Vector3.right * moveDistance);
	}

	private void checkPunch()
	{
		GameObject player = GameObject.Find("Player");
		float xDistance = (this.transform.position.x - player.transform.position.x);
		float yDistance = Mathf.Abs(this.transform.position.y - player.transform.position.y);

		if (yDistance < 1.0)
		{
			if (xDistance > 0.0 && xDistance < Constants.ATTACK_DISTANCE)
			{
				anim.StopPlayback();
				anim.Play("Attack");
				switchToState(Constants.ATTACKING);
			}
		}
	}

	private void MakeHumanFall (string otherObjectTag) {

		if (otherObjectTag == "PlayerHitCollision") {
			base.takeHitAndFall();
		}
	}


}
