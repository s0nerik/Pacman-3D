using UnityEngine;
using System.Collections;

public class Rotator : MonoBehaviour {

	// Use this for initialization
	void Start () {
//		gameObject.tag = "Pick Up";
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate (new Vector3 (Random.value * 45, Random.value *45, Random.value *45) * 2 * Time.deltaTime);
	}
}
