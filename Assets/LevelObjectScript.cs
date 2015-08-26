using UnityEngine;
using System.Collections;

public class LevelObjectScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void HandleObjectOffScreen()
	{
		Vector3 spawnPosition = Camera.main.ScreenToWorldPoint (
			new Vector3 (Screen.width, 
		               	 0, 
		                 Camera.main.WorldToScreenPoint (transform.position).z)
			);
		
		spawnPosition.y = transform.position.y;
		//			spawnPosition.z = transform.position.z;
		transform.position = spawnPosition;
	}
}
