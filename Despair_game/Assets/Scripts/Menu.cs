using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour
{
	public GUIStyle label;
	private int _window = 0;
	
	void  OnGUI ()
	{ 
		GUI.Label (new Rect (Screen.width / 2, 0, 50, 20), "I'm sorry, but I have not had time to make a game =)", label);	
		if (_window == 0) {
			if (GUI.Button (new Rect (Screen.width / 2 - 90, Screen.height / 2 + 80, 180, 30), "Exit game")) { 
				Application.LoadLevel (1); 
			} 
		}
	}
}