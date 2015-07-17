using UnityEngine;
using System.Collections;

public enum Direction { UP, DOWN, LEFT, RIGHT }

public class PacmanMovementManager : MonoBehaviour {

	//Here is a private reference only this class can access
	private static PacmanMovementManager _instance;

	public Direction MovementDirection = Direction.RIGHT;

	//This is the public reference that other classes will use
	public static PacmanMovementManager Instance
	{
		get
		{
			//If _instance hasn't been set yet, we grab it from the scene!
			//This will only happen the first time this reference is used.
			if(_instance == null)
				_instance = GameObject.FindObjectOfType<PacmanMovementManager>();
			return _instance;
		}
	}
}
