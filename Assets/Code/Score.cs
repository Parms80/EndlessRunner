using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Score : MonoBehaviour {

	int score;
	public Text scoreText;

	void Start () {
		score = 0;
		setScoreText ();
	}

	public void addToScore(int points)
	{
		score += points;
		setScoreText ();
	}

	public int getScore()
	{
		return score;
	}

	void setScoreText()
	{
		scoreText.text = "Score: " + score.ToString ();
	}
}
