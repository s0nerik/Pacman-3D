using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class EditorMover : MonoBehaviour {

	public Transform Target;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (new Vector3(0, 0, Time.deltaTime));
	}
}
