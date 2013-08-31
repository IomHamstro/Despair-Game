using UnityEngine;
using System.Collections;

public class CreateNewObjects : MonoBehaviour
{

	public int radius;
	public GameObject player;
	public GameObject prefab1;
	public GameObject prefab2;
	
	void Start ()
	{
		player = GameObject.FindGameObjectWithTag ("Player");

		int i = 0;
		while (i<100) {
			Vector3 v1 = new Vector3 (player.transform.position.x + Random.Range (-radius, radius), player.transform.position.y, player.transform.position.z + Random.Range (-radius, radius));
			GameObject newApple = Instantiate (prefab1, v1, Quaternion.identity) as GameObject;
			GameObject newZombie = Instantiate (prefab2, v1, Quaternion.identity) as GameObject;
			i++;
		}
	}

}
