using UnityEngine;
using System.Collections;

public class ObjectOffScreenScript : MonoBehaviour {

	BoxCollider2D collider;

	// Use this for initialization
	void Start () {
		collider = gameObject.collider2D as BoxCollider2D;
	}
	
	// Update is called once per frame
	void Update () {

		Vector3 objectRightEdge = transform.position;
		objectRightEdge.x += collider.size.x;

		if (Camera.main.WorldToScreenPoint(objectRightEdge).x < 0) 
		{
			SendMessage("HandleObjectOffScreen");
		}

	}
}
