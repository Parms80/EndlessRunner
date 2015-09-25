using UnityEngine;
using System.Collections;

public class LevelObjectScript : MonoBehaviour {

	void HandleObjectOffScreen()
	{
		Vector3 spawnPosition = Camera.main.ScreenToWorldPoint (
			new Vector3 (Screen.width, 0, 
		                 Camera.main.WorldToScreenPoint (transform.position).z));
		
		spawnPosition.y = transform.position.y;
		//			spawnPosition.z = transform.position.z;
		transform.position = spawnPosition;
	}
}
