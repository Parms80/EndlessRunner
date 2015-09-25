using UnityEngine;
using System.Collections;

public class GameLogic : MonoBehaviour {

	EnemySpawner enemySpawner;
	float spawnTimeLeft = 0.5f;
	int maxEnemies = 2;

	void Start () {
		enemySpawner = GetComponent<EnemySpawner>();
	}

	void Update () {
		spawnEnemyOnTimeout();

	}

	void spawnEnemyOnTimeout()
	{
		int numEnemiesActive = NewObjectPoolScript.current.countActiveObjectsOfType(
			Constants.POOLOBJECT_ENEMY);

		spawnTimeLeft -= Time.deltaTime;

		if (spawnTimeLeft < 0 && numEnemiesActive < maxEnemies) 
		{
			enemySpawner.spawnEnemy(Constants.POOLOBJECT_ENEMY);
			spawnTimeLeft = 0.5f;
		}	
	}

}
