using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameLogic : MonoBehaviour {

	public Score score;
	public Text levelText;
	int level;

	void Start () {
		level = 0;
		setLevelText();
	}

	void Update () {

		if (score.getScore () >= 1000 && level == 0) {
			level++;
			setLevelText();
		}
	}
	
	void setLevelText()
	{
		levelText.text = "Level: " + level.ToString ();
	}

}
