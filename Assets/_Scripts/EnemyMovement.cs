using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour {

	public GameObject Ground;
	public GameObject Pacman;

	private NavMeshAgent agent;

	private Vector3 groundSize;

	// Use this for initialization
	void Start () {
		agent = GetComponent<NavMeshAgent> ();
		groundSize = Ground.GetComponent<Collider>().bounds.size;
		InvokeRepeating ("changeDestination", 0.0f, 1.0f);
	}

	void changeDestination() {
		agent.SetDestination (Pacman.transform.position);
//		agent.SetDestination (new Vector3 (Random.Range (0, groundSize.x), 0.0f, Random.Range (0, groundSize.z)));
	}

//	void FixedUpdate() {
//		agent.SetDestination (Pacman.transform.position);
//	}

	// Update is called once per frame
	void Update () {
	}
}
