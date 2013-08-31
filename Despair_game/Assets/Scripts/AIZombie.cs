using UnityEngine;
using System.Collections;

public class AIZombie : MonoBehaviour
{
	public NavMeshAgent agent;
	public Transform target;
	public  float startAgentSpeed;
	public string AnimationEnemyAttackName;
	public float damage;
	
	void AttackZombie ()
	{
		animation.Play (AnimationEnemyAttackName);
		
		GameObject player = GameObject.FindGameObjectWithTag ("Player");
		if (Vector3.Distance (transform.position, player.transform.position) <= 3) {
			player.SendMessageUpwards ("ApplyDamage", damage);
		}
	}
	
	void Start ()
	{
		startAgentSpeed = agent.speed;
		agent = GetComponent<NavMeshAgent> ();
	}
	
	void Update ()
	{
		GameObject player = GameObject.FindGameObjectWithTag ("Player");	
		agent.SetDestination (target.position);
	
		if (Vector3.Distance (transform.position, player.transform.position) <= 10) {
			target = player.transform;			 	
		}
		if (Vector3.Distance (transform.position, player.transform.position) <= 2) {
			if (!animation.IsPlaying (AnimationEnemyAttackName)) {
				AttackZombie ();
			}
			agent.speed = 0;			 	
		} else {
			agent.speed = startAgentSpeed;
		}
	}
}