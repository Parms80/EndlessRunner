using UnityEngine;
using System.Collections;

public class CollisionScript : MonoBehaviour {

	public string otherObjectTag;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	private void OnTriggerEnter2D(Collider2D coll) {
		
		if (coll.gameObject.tag == otherObjectTag)
		{
			this.SendMessage("HandleCollision", otherObjectTag);
		}	
	}
}
