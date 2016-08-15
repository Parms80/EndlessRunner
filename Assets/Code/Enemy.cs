using UnityEngine;
using System.Collections;

public class Enemy : Humanoid {

	private bool attacked;
//	private Collider2D collisionBox;

	public override void Start () {
		base.Start ();
		reset();
		//		collider2D.enabled = false;
//		collisionBox = gameObject.GetComponent<Collider2D>();
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
					anim.Play(Constants.STRING_RUN);
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
		GameObject player = GameObject.Find(Constants.STRING_PLAYER);
		float xDistance = (this.transform.position.x - player.transform.position.x);
		float yDistance = Mathf.Abs(this.transform.position.y - player.transform.position.y);

		if (yDistance < Constants.INITIATE_PUNCH_DISTANCE)
		{
			if (xDistance > 0.0 && xDistance < Constants.ATTACK_DISTANCE)
			{
				anim.StopPlayback();
				anim.Play(Constants.STRING_ATTACK);
				switchToState(Constants.ATTACKING);
			}
		}
	}

	private void MakeHumanFall (string otherObjectTag) {

		if (otherObjectTag == Constants.STRING_PLAYERHITCOLLISION) {
			
//			this.collider2D.enabled = false;
//			collisionBox.enabled = false;
			base.takeHitAndFall();
		}
	}
}
