using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {

	public Camera cam;

	public void spawnEnemy(int enemyType)
	{
		try
		{
			GameObject enemy = getEnemyFromPool(enemyType);
			placeEnemyOffScreen(enemy);
//			putEnemyOnGround(enemy);
			
			enemy.SetActive(true);
			enemy.SendMessage ("reset");
		}
		catch (UnityException e)
		{
			Debug.Log("Error spawning enemy: "+e);
		}
	}
	
	GameObject getEnemyFromPool(int enemyType)
	{
		GameObject enemy = NewObjectPoolScript.current.GetPooledObject(enemyType);
		return enemy;
	}
	
	void placeEnemyOffScreen(GameObject enemy)
	{
		float spriteWidth = enemy.renderer.bounds.size.x;
		float pixelsPerUnit = 100;
		Vector3 spawnPosition;
		
		spawnPosition = cam.ScreenToWorldPoint (new Vector3 (Screen.width + (spriteWidth / 2)*pixelsPerUnit, 0, 0));
		spawnPosition.z = 0;
		spawnPosition.y += 5.0f;
		enemy.transform.position = spawnPosition;
	}
	
	void putEnemyOnGround(GameObject enemy)
	{
		Vector2 linecastStartPos = new Vector2 (enemy.transform.position.x, 0);
		Vector2 linecastEndPos = new Vector2 (enemy.transform.position.x, -50);
		RaycastHit2D groundPos = Physics2D.Linecast (linecastStartPos, linecastEndPos, 1 << LayerMask.NameToLayer ("Ground"));
		
		Vector3 spawnPosition = enemy.transform.position;
		spawnPosition.y = groundPos.transform.position.y;
		enemy.transform.position = spawnPosition;
	}
}
