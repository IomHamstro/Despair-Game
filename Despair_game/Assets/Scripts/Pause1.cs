using UnityEngine; 
using System.Collections;

public class Pause1 : MonoBehaviour
{ 

	private bool _paused = false;
	private int _window = 100;
	private float _FloatVolume = 50;
	private int IntVolume;
	private float _FloatResolution = 2;
	private int IntResolution;
	private string StringWidth;
	private string StringHeight;
	private int width = 1600;
	private int height = 900;
	private bool FullScreen = true;

	void Update ()
	{ 
	
		if (Input.GetKeyUp (KeyCode.Escape)) {
			
			if (!_paused) {  
				Time.timeScale = 0;  
				_paused = true; 
				_window = 0;
			} else {  
				Time.timeScale = 1;  
				_paused = false;
				_window = 100;
			} 
		} 
	}
	
	void  OnGUI ()
	{ 
					
		if (_window == 0) {
			GUI.Box (new Rect (Screen.width / 2 - 100, Screen.height / 2 - 100, 200, 180), "Game menu");
			
			if (GUI.Button (new Rect (Screen.width / 2 - 90, Screen.height / 2 - 80, 180, 30), "Continue")) {
				Time.timeScale = 1;
				_paused = false;
				_window = 100; 
			} 
			if (GUI.Button (new Rect (Screen.width / 2 - 90, Screen.height / 2 - 40, 180, 30), "Options")) {
				_window = 1; 
			}
			if (GUI.Button (new Rect (Screen.width / 2 - 90, Screen.height / 2 - 0, 180, 30), "Main menu")) {
				Time.timeScale = 1;  
				_paused = false;
				_window = 100;
				Application.LoadLevel (0);   
			} 
			if (GUI.Button (new Rect (Screen.width / 2 - 90, Screen.height / 2 + 40, 180, 30), "Exit game")) {
				Application.Quit (); 
			} 
		}

		if (_window == 1) {  
			GUI.Box (new Rect (Screen.width / 2 - 100, Screen.height / 2 - 100, 200, 180), "Options"); 
			
			if (GUI.Button (new Rect (Screen.width / 2 - 90, Screen.height / 2 - 80, 180, 30), "Video")) {
				_window = 3;
			} 
			if (GUI.Button (new Rect (Screen.width / 2 - 90, Screen.height / 2 - 40, 180, 30), "Audio")) { 
				_window = 2;
			}
			if (GUI.Button (new Rect (Screen.width / 2 - 90, Screen.height / 2 - 0, 180, 30), "Back") || Input.GetKeyUp (KeyCode.Escape)) {
				_window = 0; 
			} 
		}
		// Звук
		if (_window == 2) { 
			GUI.Box (new Rect (Screen.width / 2 - 100, Screen.height / 2 - 100, 200, 180), "Audio"); 
			GUI.Label (new Rect (Screen.width / 2 - 100, Screen.height / 2 - 80, 180, 140), "Volume:");
			
			_FloatVolume = GUI.HorizontalSlider (new Rect (Screen.width / 2 + 50 - 90, Screen.height / 2 + 6 - 80, 100, 20), _FloatVolume, 0, 100);
			IntVolume = (int)_FloatVolume;
			audio.volume = IntVolume;
			
			if (GUI.Button (new Rect (Screen.width / 2 - 90, Screen.height / 2 + 40, 180, 30), "Back") || Input.GetKeyUp (KeyCode.Escape)) { 
				_window = 1; 
			} 
		}
		// Видео
		if (_window == 3) { 
			GUI.Box (new Rect (Screen.width / 2 - 100, Screen.height / 2 - 100, 200, 180), "Video"); 
			GUI.Label (new Rect (Screen.width / 2 - 90, Screen.height / 2 - 80, 180, 30), "Resolution:"); // текст 
			
			_FloatResolution = GUI.HorizontalSlider (new Rect (Screen.width / 2 - 20, Screen.height / 2 - 75, 100, 30), _FloatResolution, 0, 2);
			// Расчеты расширения
			IntResolution = (int)_FloatResolution;
			if (IntResolution == 0) {
				width = 640;
				height = 480;
				StringWidth = width.ToString ();
				StringHeight = height.ToString ();
			}
			if (IntResolution == 1) {
				width = 1024;
				height = 768;
				StringWidth = width.ToString ();
				StringHeight = height.ToString ();
			}
			if (IntResolution == 2) {
				width = 1600;
				height = 900;
				StringWidth = width.ToString ();
				StringHeight = height.ToString ();
			}
			// Вывод на экран выбираемого расширения
			GUI.Label (new Rect (Screen.width / 2 - 90, Screen.height / 2 - 40, 180, 30), StringWidth); // ширина
			GUI.Label (new Rect (Screen.width / 2 - 50, Screen.height / 2 - 40, 180, 30), StringHeight); // высота
			
			FullScreen = GUI.Toggle (new Rect (Screen.width / 2 - 90, Screen.height / 2 - 0, 180, 30), FullScreen, "Full screen"); 
			//if (FullScreen == true) {}
			
			if (GUI.Button (new Rect (Screen.width / 2 - 90, Screen.height / 2 + 40, 180, 30), "Save and back")) { 
				Screen.SetResolution (width, height, FullScreen);//A - ширина. B - высота. С - полноэкранный или оконный.
				_window = 1;
			} 
			if (Input.GetKeyUp (KeyCode.Escape)) { 
				_window = 1;
			}
		}

		if (Input.GetKeyUp (KeyCode.Escape))
			_window = 1;
	}
}
