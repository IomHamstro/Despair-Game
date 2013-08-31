using UnityEngine;
using System.Collections;

public class ZombieHealth : MonoBehaviour
{
	public int maxHealth;
	public int _curHealth;
	
	void Start ()
	{
		if (maxHealth < 1)
			maxHealth = 1;
		_curHealth = maxHealth;
	}
	
	public void Zombie_Damage (int damage)
	{
		_curHealth -= damage;
		
		if (_curHealth <= 0) {
			Damage ();
		}
	}

	public void Damage ()
	{
		audio.Play ();
		Destroy (gameObject, 0.8f);		
	}
}
