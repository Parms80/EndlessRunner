using UnityEngine;
using System.Collections;

public class ObjectOffScreenScript : MonoBehaviour {

	BoxCollider2D coll;

	// Use this for initialization
	void Start () {
		coll = gameObject.collider2D as BoxCollider2D;
	}
	
	// Update is called once per frame
	void Update () {

		Vector3 objectRightEdge = transform.position;
		objectRightEdge.x += coll.size.x;

		if (Camera.main.WorldToScreenPoint(objectRightEdge).x < 0) 
		{
			SendMessage("HandleObjectOffScreen");
		}

	}
}
