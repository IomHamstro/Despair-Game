using UnityEngine;
using System.Collections;

public class waterlevelscript : MonoBehaviour {
  
  void Update(){
	if(transform.position.y < 10){
		Application.LoadLevel(1);
		}
	}
}