using UnityEngine;
using System.Collections;

public class GameLogic : MonoBehaviour {

	EnemySpawner enemySpawner;
	EnemySpawner boxSpawner;
	float spawnTimeLeft = 0.5f;
	int maxEnemies = 2;

	void Start () {
//		enemySpawner = initialiseSpawner(Constants.POOLOBJECT_ENEMY);
//		boxSpawner = initialiseSpawner(Constants.POOLOBJECT_BOX);
	}

	void Update () {
//		spawnEnemyOnTimeout(enemySpawner);
//		spawnEnemyOnTimeout(boxSpawner);
	}
//
//	EnemySpawner initialiseSpawner(int objectType)
//	{
//		EnemySpawner spawner;
//		spawner.setObjectType(objectType);
//		return spawner;
//	}
//
//	void spawnEnemyOnTimeout(EnemySpawner spawner)
//	{
//		int numEnemiesActive = NewObjectPoolScript.current.countActiveObjectsOfType(
//			spawner.getObjectType());
//
//		spawnTimeLeft -= Time.deltaTime;
//
//		if (spawnTimeLeft < 0 && numEnemiesActive < maxEnemies) 
//		{
//			spawner.spawnEnemy();
//			spawnTimeLeft = 0.5f;
//		}	
//	}

}
