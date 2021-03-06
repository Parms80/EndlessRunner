﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameLogic : MonoBehaviour {

	public Score score;
	public Text levelText;
	public ObjectSpawner enemySpawner;
	public ObjectSpawner boxSpawner;
	public ObjectSpawner highBoxSpawner;

	int level;
	int scoreLastUpdate;

	void Start () {
		level = 0;
		setLevelText();
//		enemySpawner.setMaxObjects (2);
		boxSpawner.setMaxObjects (1);
		highBoxSpawner.setMaxObjects (1);
		scoreLastUpdate = 0;
	}

	void Update () {

		if (qualifiedForNextLevel()) 
		{
			setNextLevel();
			setLevelText();
		}
		scoreLastUpdate = score.getScore();
	}

	bool qualifiedForNextLevel()
	{
		bool qualified = false;
		int currentScore = score.getScore();

		if (scoreLastUpdate < (level+1)*Constants.SCORE_FOR_NEXT_LEVEL &&
		    currentScore >= (level+1)*Constants.SCORE_FOR_NEXT_LEVEL) 
		{
			qualified = true;
		}

		return qualified;
	}

	void setNextLevel()
	{
		int maxEnemies;
		maxEnemies = enemySpawner.getMaxObjects();
		level++;
		
		if (maxEnemies < NewObjectPoolScript.current.pooledAmount)
		{
			enemySpawner.setMaxObjects(maxEnemies+1);
		}
	}
	
	void setLevelText()
	{
		levelText.text = Constants.STRING_LEVEL + "" + level.ToString ();
	}
}
