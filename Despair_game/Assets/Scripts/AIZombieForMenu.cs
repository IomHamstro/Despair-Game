// AI with using NavMesh
using UnityEngine;
using System.Collections;

public class AIZombieForMenu : MonoBehaviour
{
	public NavMeshAgent agent;
	public Transform target;
	public  float startAgentSpeed;
	public GameObject prefab;
		
	void Start ()
	{
		startAgentSpeed = agent.speed;
		agent = GetComponent<NavMeshAgent> ();
	}
	
	void Update ()
	{
		agent.SetDestination (target.position);
		Vector3 v1 = new Vector3(4,0, -11);
		if (Vector3.Distance (transform.position, target.transform.position) <= 2) {
			GameObject newZombie = Instantiate (prefab, v1, Quaternion.identity) as GameObject;
			Destroy(gameObject);
		}
	}
}