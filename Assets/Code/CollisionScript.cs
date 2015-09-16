using UnityEngine;
using System.Collections;

public class CollisionScript : MonoBehaviour {

	public string otherObjectTag;

	void Start () {
	
	}

	private void OnTriggerEnter2D(Collider2D coll) {
		
		if (coll.gameObject.tag == otherObjectTag)
		{
			this.SendMessage("MakeHumanFall", otherObjectTag);
		}	
	}
}
