using UnityEngine;
using System.Collections;


public class MainInv : MonoBehaviour
{
	void Update ()
	{
		bool cursorInteraction = Input.GetKey (KeyCode.LeftShift) || Input.GetKey (KeyCode.RightShift);
		Screen.showCursor = cursorInteraction;
		GetComponent<MouseLook> ().enabled = !cursorInteraction; 
		Camera.main.GetComponent<MouseLook> ().enabled = !cursorInteraction; 

	}
}