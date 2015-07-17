using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	[SerializeField]
	private GameObject pacman;

	private Vector3 offset;

	// Use this for initialization
	void Start () {
		offset = transform.position - pacman.transform.position;
//		InputHandler.OnInputEvent += rotateCamera;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	// Update is called once per frame
	void LateUpdate () {
		transform.position = pacman.transform.position + offset;

//		switch (PacmanMovementManager.Instance.MovementDirection)
//		{
//		case Direction.UP:
//			transform.Rotate(new Vector3 (0.0f, 0.0f, 0.0f) * Time.deltaTime);
//			break;
//		case Direction.DOWN:
//			transform.Rotate(new Vector3 (0.0f, 180.0f, 0.0f) * Time.deltaTime);
////			rb.velocity = new Vector3 (0.0f, 0.0f, -1.0f) * Speed;
//			break;
//		case Direction.LEFT:
//			transform.Rotate(new Vector3 (0.0f, -90.0f, 0.0f) * Time.deltaTime);
////			rb.velocity = new Vector3 (-1.0f, 0.0f, 0.0f) * Speed;
//			break;
//		case Direction.RIGHT:
//			transform.Rotate(new Vector3 (0.0f, 90.0f, 0.0f) * Time.deltaTime);
////			rb.velocity = new Vector3 (1.0f, 0.0f, 0.0f) * Speed;
//			break;
//		}
	}

//	void rotateCamera(Direction d) {
//		switch (d) {
//		case Direction.UP:
//			transform.Rotate(new Vector3 (0.0f, 0.0f, 0.0f));
//			break;
//		case Direction.DOWN:
//			transform.Rotate(new Vector3 (0.0f, 0.0f, 0.0f));
//			break;
//		case Direction.LEFT:
//			break;
//		case Direction.RIGHT:
//			break;
//		}
//	}

}
