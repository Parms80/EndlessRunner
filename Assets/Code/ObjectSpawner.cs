using UnityEngine;
using System.Collections;

public class ObjectSpawner : MonoBehaviour {

	public Camera cam;
	public int objectType;
	public float spawnWaitTime;
	public int maxObjects;
	float spawnTimeLeft;


	void Start()
	{
		spawnTimeLeft = spawnWaitTime;
	}

	void Update()
	{
		spawnObjectOnTimeout ();
	}

	public void spawnObject()
	{
		try
		{
			GameObject obj = getObjectFromPool();
			placeObjectOffScreen(obj);
			putObjectOnGround(obj);
			
			obj.SetActive(true);
			obj.SendMessage ("reset");
		}
		catch (UnityException e)
		{
			Debug.Log("Error spawning object: "+e);
		}
	}

	public void setObjectType(int type)
	{
		objectType = type;
	}
	
	public int getObjectType()
	{
		return objectType;
	}
	
	GameObject getObjectFromPool()
	{
		GameObject obj = NewObjectPoolScript.current.GetPooledObject(objectType);
		return obj;
	}
	
	void placeObjectOffScreen(GameObject obj)
	{
		Vector3 spawnPosition;
		
		spawnPosition = cam.ScreenToWorldPoint (new Vector3 (getScreenXOfSpriteOffScreen(obj), 0, 0));
		spawnPosition.z = 0;
		spawnPosition.y += 5.0f;
		obj.transform.position = spawnPosition;
	}

	float getScreenXOfSpriteOffScreen(GameObject obj)
	{
		float spriteWidth = obj.renderer.bounds.size.x;
		float pixelsPerUnit = 100;
		return Screen.width + (spriteWidth / 2)*pixelsPerUnit;
	}
	
	void putObjectOnGround(GameObject obj)
	{
		Vector2 linecastStartPos = new Vector2 (obj.transform.position.x, 0);
		Vector2 linecastEndPos = new Vector2 (obj.transform.position.x, -50);
		RaycastHit2D groundPos = Physics2D.Linecast (linecastStartPos, 
		                                             linecastEndPos, 1 << LayerMask.NameToLayer ("Ground"));
		
		Vector3 spawnPosition = obj.transform.position;
		spawnPosition.y = groundPos.transform.position.y;
		obj.transform.position = spawnPosition;
	}

	
	void spawnObjectOnTimeout()
	{
		int numObjectsActive = NewObjectPoolScript.current.countActiveObjectsOfType(
			objectType);
		
		spawnTimeLeft -= Time.deltaTime;
		
		if (spawnTimeLeft < 0 && numObjectsActive < maxObjects) 
		{
			spawnObject();
			spawnTimeLeft = spawnWaitTime;
		}	
	}

	public int getMaxObjects()
	{
		return maxObjects;
	}

	public void setMaxObjects(int max)
	{
		maxObjects = max;
	}
}
