using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {

	public Camera cam;
	public int objectType;

	public float spawnWaitTime;
	float spawnTimeLeft;
	int maxEnemies = 2;

	void Start()
	{
		spawnTimeLeft = spawnWaitTime;
	}

	void Update()
	{
		spawnEnemyOnTimeout ();
	}

	public void spawnEnemy()
	{
		try
		{
			GameObject enemy = getEnemyFromPool();
			placeEnemyOffScreen(enemy);
			putEnemyOnGround(enemy);
			
			enemy.SetActive(true);
			enemy.SendMessage ("reset");
		}
		catch (UnityException e)
		{
			Debug.Log("Error spawning enemy: "+e);
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
	
	GameObject getEnemyFromPool()
	{
		GameObject enemy = NewObjectPoolScript.current.GetPooledObject(objectType);
		return enemy;
	}
	
	void placeEnemyOffScreen(GameObject enemy)
	{
		Vector3 spawnPosition;
		
		spawnPosition = cam.ScreenToWorldPoint (new Vector3 (getScreenXOfSpriteOffScreen(enemy), 0, 0));
		spawnPosition.z = 0;
		spawnPosition.y += 5.0f;
		enemy.transform.position = spawnPosition;
	}

	float getScreenXOfSpriteOffScreen(GameObject enemy)
	{
		float spriteWidth = enemy.renderer.bounds.size.x;
		float pixelsPerUnit = 100;
		return Screen.width + (spriteWidth / 2)*pixelsPerUnit;
	}
	
	void putEnemyOnGround(GameObject enemy)
	{
		Vector2 linecastStartPos = new Vector2 (enemy.transform.position.x, 0);
		Vector2 linecastEndPos = new Vector2 (enemy.transform.position.x, -50);
		RaycastHit2D groundPos = Physics2D.Linecast (linecastStartPos, 
		                                             linecastEndPos, 1 << LayerMask.NameToLayer ("Ground"));
		
		Vector3 spawnPosition = enemy.transform.position;
		spawnPosition.y = groundPos.transform.position.y;
		enemy.transform.position = spawnPosition;
	}

	
	void spawnEnemyOnTimeout()
	{
		int numEnemiesActive = NewObjectPoolScript.current.countActiveObjectsOfType(
			objectType);
		
		spawnTimeLeft -= Time.deltaTime;
		
		if (spawnTimeLeft < 0 && numEnemiesActive < maxEnemies) 
		{
			Debug.Log(gameObject);
			spawnEnemy();
			spawnTimeLeft = spawnWaitTime;
		}	
	}
}
