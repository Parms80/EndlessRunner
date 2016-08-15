using UnityEngine;
using System.Collections;

public class Constants : MonoBehaviour {

	public const int RUNNING = 0;
	public const int JUMPING = 1;
	public const int TAKE_HIT = 2;
	public const int ATTACKING = 3;

	public const float ATTACK_DISTANCE = 0.8f;

	public const int POOLOBJECT_ENEMY = 0;
	public const int POOLOBJECT_BOX = 1;
	public const int POOLOBJECT_HIGHBOX = 2;

	public const int MAX_OBJECTS_PER_TYPE = 10;
	public const int POINTS_FOR_ENEMY_KILL = 100;
	public const int PIXELS_PER_UNIT = 100;
	public const float INITIATE_PUNCH_DISTANCE = 1.0f;
	public const int LINECAST_END_Y = -50;
	public const int SCORE_FOR_NEXT_LEVEL = 1000;
	public const float SPAWN_Y_POSITION = 5.0f;
	public const float HORIZONTAL_JUMP_STRENGTH = 0.0f;
	
	public const string STRING_ATTACK = "Attack";
	public const string STRING_ENEMY = "Enemy";
	public const string STRING_ENEMYHITCOLLISION = "EnemyHitCollision";
	public const string STRING_ERRORSPAWNINGOBJECT = "Error spawing object: ";
	public const string STRING_FALLING = "Falling";
	public const string STRING_GROUND = "Ground";
	public const string STRING_GROUNDCHECK = "GroundCheck";
	public const string STRING_HANDLEOBJECTOFFSCREEN = "HandleObjectOffScreen";
	public const string STRING_KICK = "Kick";
	public const string STRING_JUMP = "Jump";
	public const string STRING_MAKEHUMANFALL = "MakeHumanFall";
	public const string STRING_LEVEL = "Level: ";
	public const string STRING_PLAYER = "Player";
	public const string STRING_PLAYERHITCOLLISION = "PlayerHitCollision";
	public const string STRING_RUN = "Run";
	public const string STRING_RESET = "reset";
	public const string STRING_SCORE = "Score";
	public const string STRING_HUD_SCORE = "Score: ";
}
