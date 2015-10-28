using UnityEngine;
using System.Collections;

public class CubeController : MonoBehaviour {
	
	//Player Turret
	public int speed = 1;
	public float friction = 1 ;
	public float lerpSpeed  = 1;
	public float scrollwidth = 5;
	public float scrollspeed = 5;
	public float step = 1;
	private float xDeg ;
	private float yDeg ;
	private float xDegkey ;
	private float yDegkey ;
	private Quaternion fromRotation ;
	private Quaternion toRotation ;
	private Vector3 scrollPosition;

	
	private bool imBeingDragged = false;
	void OnMouseDown() {
		if ( !imBeingDragged ) {
			//Do something here
			imBeingDragged = true;
		}
	}
	
	void OnMouseUp() {
		imBeingDragged = false;
	}
	
	void Update() {
		//**/ print(imBeingDragged);
	}
	
	void Awake (){

	}
	
	void OnGUI () {
		// Turret rotation and angle clamp
		
		if ( Input.GetMouseButton(0) ) {
			if ( Input.GetAxis("Mouse X") != 0 && Input.GetAxis("Mouse X") != 0 )
			{
				xDeg -= Input.GetAxis("Mouse X") * speed * friction;
				yDeg -= Input.GetAxis("Mouse Y") * speed * friction;
				// Debug.Log(mouseposition);
				fromRotation = transform.rotation;
				toRotation = Quaternion.Euler(yDeg, xDeg, 0);
				transform.rotation = Quaternion.Lerp(fromRotation, toRotation, Time.deltaTime  * lerpSpeed);
			};
		}

			// Support the computer scrollwheel
		float scroll = Input.GetAxis("Mouse ScrollWheel");
		if(scroll !=0f){
			if (scroll < 0f) {				
				transform.localScale += new Vector3 (0.1F, 0, 0);
			} else {
				transform.localScale -= new Vector3(0.1F, 0, 0);
			}
		}
	}
}
