using UnityEngine;
using System.Collections;

public class EnemyWave : MonoBehaviour {

	public static EnemyWave enemyWaveGenerator;
	private int[] enemySpacing;
	private int numEnemies;
	public Camera cam;

	void Awake()
	{
		enemyWaveGenerator = this;
	}

	void Start()
	{
		enemySpacing = new int[10];
		createNewWave ();
	}

	public void createNewWave()
	{
		numEnemies = 4;

		try
		{
			createFormation();
			Vector3 lastPosition = new Vector3(0,0,0);

			for (int currentEnemyIndex = 0; currentEnemyIndex < numEnemies; currentEnemyIndex++)
			{
				GameObject obj = getObjectFromPool ();

				placeObjectOffScreen(obj);
				if (currentEnemyIndex > 0)
				{
					adjustSpacing(obj, currentEnemyIndex, lastPosition);
				}
				putObjectOnGround(obj);
				obj.SetActive(true);
				obj.SendMessage (Constants.STRING_RESET);
				lastPosition = obj.transform.position;
			}
		}
		catch (UnityException e)
		{
			Debug.Log(Constants.STRING_ERRORSPAWNINGOBJECT+""+e);
		}
	}

	GameObject getObjectFromPool()
	{
		GameObject obj = NewObjectPoolScript.current.GetPooledObject(Constants.POOLOBJECT_ENEMY);
		return obj;
	}

	void createFormation()
	{
		for (int i = 0; i < numEnemies; i++) {
			enemySpacing [i] = Random.Range(1,3);
		}
	}

	
	void placeObjectOffScreen(GameObject obj)
	{
		Vector3 spawnPosition;
		
		spawnPosition = cam.ScreenToWorldPoint (new Vector3 (getScreenXOfSpriteOffScreen(obj), 0, 0));
		spawnPosition.z = 0;
		spawnPosition.y += Constants.SPAWN_Y_POSITION;
		obj.transform.position = spawnPosition;
	}
	
	float getScreenXOfSpriteOffScreen(GameObject obj)
	{
		float spriteWidth = obj.renderer.bounds.size.x;
		float pixelsPerUnit = Constants.PIXELS_PER_UNIT;
		return Screen.width + (spriteWidth / 2)*pixelsPerUnit;
	}

	void adjustSpacing(GameObject obj, int positionInFormation, Vector3 lastEnemyPosition)
	{
		float spriteWidth = obj.renderer.bounds.size.x;
		Vector3 position = lastEnemyPosition;
		position.x += spriteWidth * enemySpacing[positionInFormation];
		obj.transform.position = position;
	}

	
	void putObjectOnGround(GameObject obj)
	{
		Vector2 linecastStartPos = new Vector2 (obj.transform.position.x, 0);
		Vector2 linecastEndPos = new Vector2 (obj.transform.position.x, 
		                                      Constants.LINECAST_END_Y);
		RaycastHit2D groundPos = Physics2D.Linecast (linecastStartPos, 
		                                             linecastEndPos, 
		                                             1 << LayerMask.NameToLayer(Constants.STRING_GROUND));
		
		Vector3 spawnPosition = obj.transform.position;
		spawnPosition.y = groundPos.transform.position.y;
		obj.transform.position = spawnPosition;
	}
}
