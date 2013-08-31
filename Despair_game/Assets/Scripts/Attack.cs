using UnityEngine;
using System.Collections;

public class Attack : MonoBehaviour
{
	public Transform startPoint;
	public float force;
	public string animationName;
	public int damage;
	public Animation stickAnimation;
	private Item hoveredItem;
	private Camera _playerCamera;

	public Camera PlayerCamera {
		get {
			if (_playerCamera == null) {
				_playerCamera = Camera.main;
			}
			return _playerCamera;
		}
	}

	private Transform _playerCameraTr;

	public Transform PlayerCameraTr {
		get {
			if (_playerCameraTr == null) {
				_playerCameraTr = PlayerCamera.transform;
			}
			return _playerCameraTr;
		}
	}
	
	void Update ()
	{
		if (Input.GetKey (KeyCode.LeftShift) || Input.GetKey (KeyCode.RightShift)) {
			CheckHoveredObject ();
			if (hoveredItem != null && Input.GetMouseButtonDown (1)) {
				SendMessage ("ApplyHunger", hoveredItem.Hunger);
				Destroy (hoveredItem.gameObject);
				hoveredItem = null;
			}
		} else if (Input.GetKeyDown (KeyCode.Mouse0) && !stickAnimation.IsPlaying (animationName)) {
			AttackMethod ();
		}
	}
	
	void OnGUI ()
	{
		if (hoveredItem != null) {
			GUI.Label (new Rect (Input.mousePosition.x + 15, Screen.height - Input.mousePosition.y, 200, 80), "Name: " + hoveredItem.Sname);
			GUI.Label (new Rect (Input.mousePosition.x + 15, Screen.height - Input.mousePosition.y + 15, 200, 80), "Food: " + hoveredItem.Hunger);
		}
	}

	void CheckHoveredObject ()
	{
		RaycastHit hit;
		
		Vector3 cursorPointInWorld = PlayerCamera.ScreenToWorldPoint (new Vector3 (Input.mousePosition.x, Input.mousePosition.y, 10f));
		Vector3 direction = cursorPointInWorld - PlayerCameraTr.position;
		
		if (Physics.Raycast (PlayerCameraTr.position, direction, out hit, 10f)) {
			if (hoveredItem == null || hoveredItem.collider != hit.collider.gameObject) {
				if (hit.collider.tag == "apple") {
					hoveredItem = hit.collider.GetComponent<Item> ();
				} else {
					hoveredItem = null;
				}
			}
		} else {
			hoveredItem = null;
		}
	}
	
	void AttackMethod ()
	{			
		stickAnimation.Play (animationName);
		
		RaycastHit hit;
		Vector3 direct = startPoint.TransformDirection (Vector3.forward * force);
		
		if (Physics.Raycast (startPoint.position, direct, out hit, force)) {
			if (hit.rigidbody) {
				hit.rigidbody.AddForceAtPosition (direct, startPoint.position);
			}
			if (hit.transform.tag == "zombie") {
				hit.transform.SendMessage ("Zombie_Damage", damage);
			}
		}
	}
}