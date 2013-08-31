// Выводит бар, показывающий состояние здоровья игрока
using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{
	public float maxHealth = 100;
	double curHealth = 100;
	public float maxHunger = 100;
	public float curHunger = 0;
	public float maxSleep = 100;
	float curSleep = 100;
	
	public void OnGUI ()
	{
		GUI.Box (new Rect (10, 10, Screen.width / 8, 25), "Health " + (int)curHealth + "/" + maxHealth);
		GUI.Box (new Rect (10, 36, Screen.width / 8, 25), "Hunger " + (int)curHunger + "/" + maxHunger);
		GUI.Box (new Rect (10, 62, Screen.width / 8, 25), "Sleep " + (int)curSleep + "/" + maxSleep);
	}
	
	private void ApplyDamage (double damage)
	{
		curHealth -= damage;

		if (curHealth <= 0) {
			Damage ();
		}
	}
	
	private void ApplyHunger (int Hunger)
	{
		if (curHunger <= Hunger) {
			curHunger = 0;
		} else {
			curHunger -= Hunger;
		}
	}
	
	public void Damage ()
	{
		Application.LoadLevel ("menu");
	}
	
	void Update ()
	{
		curHunger += 0.005f;
		curSleep -= 0.005f;
		
		if (curHealth >= maxHealth) {
			curHealth = maxHealth;
		} else {
			curHealth += 0.005f;
		}
		
		if ((curHunger >= 100) || (curSleep <= 0)) {
			Application.Quit ();
		}
	}
}
