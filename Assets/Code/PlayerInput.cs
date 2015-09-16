using UnityEngine;
using System.Collections;

public class PlayerInput : MonoBehaviour {

	public KeyCode kickButton;
	public KeyCode jumpButton;
	
	public PlayerInput()
	{
	}
	
	public bool isKickPressed()
	{
		return Input.GetKeyDown(kickButton);
	}
	
	
	public bool isJumpPressed()
	{
		return Input.GetKeyDown(jumpButton);
	}
}
