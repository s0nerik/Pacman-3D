using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Threading;

public class PacmanController : MonoBehaviour {

	public float Speed = 1.0f;

	public Text ScoreText;
	public Text WinText;

	private Rigidbody rb;

	private int score = 0;
	private int pickupsNum = 0;


	private bool shouldRotate = false;

	private Timer timer;

	private Vector3 desiredRotation = new Vector3 (0.0f, 0.0f, 0.0f);
	private Quaternion desiredQuaternion;
	
	private float rotationAmount = 0.0f;

	private float totalRotation = 0.0f;



	void CountPickUps() {
		pickupsNum = GameObject.FindGameObjectsWithTag("Pick Up").Length;
	}

	void OnTriggerEnter(Component other) {
		if (other.gameObject.CompareTag ("Pick Up")) {
			other.gameObject.SetActive (false);
			score++;
			UpdateScoreText();

			if (score == pickupsNum) { // Collected everything
				WinText.color = Color.white;
				Time.timeScale = 0.0f;
			}
		}
	}
	
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
		CountPickUps ();
		UpdateScoreText();
		WinText.color = Color.clear;

		InputHandler.OnInputEvent += startPacmanRotation;
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (new Vector3 (0.0f, 0.0f, 1.0f) * Speed * Time.deltaTime);
		if (shouldRotate) {
			applyRotation (InputHandler.InputGap / 2.0f);
		}
	}

	void UpdateScoreText() {
		ScoreText.text = "Score: " + score;
	}

	void startPacmanRotation(Direction d) {
		if (shouldRotate)
			return;

		switch (d)
		{
		case Direction.DOWN:
			rotationAmount = 180.0f;
			break;
		case Direction.LEFT:
			rotationAmount = -90.0f;
			break;
		case Direction.RIGHT:
			rotationAmount = 90.0f;
			break;
		default:
			rotationAmount = 0.0f;
			break;
		}

		desiredRotation = new Vector3 (transform.eulerAngles.x,
		                               transform.eulerAngles.y + rotationAmount,
		                               transform.eulerAngles.z);
		shouldRotate = true;
	}

	void applyRotation(float desiredDuration) {
		if (totalRotation < Mathf.Abs(rotationAmount))
		{
			var rotation = rotationAmount * (Time.deltaTime / desiredDuration);
			transform.Rotate(Vector3.up, rotation);
			totalRotation += Mathf.Abs(rotation);
		}
		else
		{
			transform.eulerAngles = desiredRotation;
			shouldRotate = false;
			totalRotation = 0.0f;
			rotationAmount = 0.0f;
		}
	}

}
