using UnityEngine;
using System.Collections;

public class CollisionScript : MonoBehaviour {

	public string otherObjectTag;
	private GameObject scoreObject;
	private Score score;

	void Start()
	{
		scoreObject = GameObject.Find("Score");
		score = scoreObject.GetComponent<Score> ();
	}

	private void OnTriggerEnter2D(Collider2D coll) {
		
		if (coll.gameObject.tag == otherObjectTag)
		{
			this.SendMessage("MakeHumanFall", otherObjectTag);

			if (otherObjectTag == "PlayerHitCollision")
			{
				score.addToScore(Constants.POINTS_FOR_ENEMY);
			}
		}	
	}
}
