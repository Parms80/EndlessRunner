using UnityEngine;
using System.Collections;

public class CollisionScript : MonoBehaviour {

	public string otherObjectTag;
	private GameObject scoreObject;
	private Score score;

	void Start()
	{
		scoreObject = GameObject.Find(Constants.STRING_SCORE);
		score = scoreObject.GetComponent<Score> ();
	}

	private void OnTriggerEnter2D(Collider2D other) {


		if (other.gameObject.tag == otherObjectTag)
		{
			this.SendMessage(Constants.STRING_MAKEHUMANFALL, otherObjectTag);

			if (otherObjectTag == Constants.STRING_PLAYERHITCOLLISION)
			{
				score.addToScore(Constants.POINTS_FOR_ENEMY_KILL);
			}
		}	
	}

	bool doesColliderBelongToPlayer(Collider2D coll)
	{
		bool isPlayer = false;

		if (coll.transform.parent.tag == Constants.STRING_PLAYER) {
			isPlayer = true;
		}

		return isPlayer;
	}

	bool hasPlayerHitEnemy(Collider2D other)
	{
//		other.collider2D.enabled = false;
		return other.gameObject.tag == Constants.STRING_ENEMY;
	}

	int checkEnemyState(Collider2D other)
	{
		Enemy enemyScript = other.gameObject.GetComponent<Enemy> ();
		int state = enemyScript.getState ();

		return state;
	}

	bool isPlayingFallenAnimation(Collider2D other)
	{
		bool fallingAnimationPlaying = false;
		Enemy enemyScript = other.gameObject.GetComponent<Enemy> ();
		Animation anim = enemyScript.GetComponent<Animation> ();

		if (anim.IsPlaying (Constants.STRING_FALLING)) 
		{
			fallingAnimationPlaying = true;
		}

		return fallingAnimationPlaying;
	}
}
