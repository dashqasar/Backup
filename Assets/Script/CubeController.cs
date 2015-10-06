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
	private Vector3 originpos;
	
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
		originpos = this.gameObject.transform.position;
	}
	
	void OnGUI () {
		// Turret rotation and angle clamp
		
		if ( Input.GetMouseButton(0) ) {
			
			if ( Input.GetAxis("Mouse X") >= Screen.width/2 - 100 && Input.GetAxis("Mouse X") <= Screen.width/2 + 100 &&
			    Input.GetAxis("Mouse Y") >= Screen.height - 60 && Input.GetAxis("Mouse Y") <= Screen.height - 10 )
			{
				Debug.Log(Input.GetAxis("Mouse X"));
				Debug.Log(Input.GetAxis("Mouse Y"));
				return;
			};
			
			float mouseposition = Input.mousePosition.y;
			if (mouseposition > 120){
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
		};
		
		/*xDegkey -= Input.GetAxis ("Horizontal") * step;
		yDegkey -= Input.GetAxis ("Vertical") * step;
		if (xDegkey + yDegkey != 0.0f){
		fromRotation = transform.rotation;
		toRotation = Quaternion.Euler(yDeg,xDeg,0);
		transform.rotation = Quaternion.Lerp(fromRotation,toRotation,Time.deltaTime  * lerpSpeed);	
			xDegkey = 0.0f;
			yDegkey = 0.0f;
		}	*/
		
		if ( Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow) ) {
			transform.Rotate(-Vector3.forward * step * Time.deltaTime);
		}
		
		if ( Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow) ) {
			transform.Rotate(Vector3.forward * step * Time.deltaTime);
		}	
		
		if ( Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow) ) {
			transform.Rotate(Vector3.up * step * Time.deltaTime);
		}
		
		if ( Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow) ) {
			transform.Rotate(-Vector3.up * step * Time.deltaTime);
		}
		
		// Support the computer scrollwheel
		float scroll = Input.GetAxis("Mouse ScrollWheel");
		//		float scroll = Input.mouseScrollDelta.sqrMagnitude;
		if(scroll !=0f){
		if (scroll < 0f) {
			//scrollPosition += Vector3.forward * scroll * scrollspeed;
			//transform.localScale = scrollPosition;
			//transform.localScale = new Vector3(transform.localScale.x, scroll * 5, transform.localScale.y);
			transform.localScale += new Vector3 (0.1F, 0, 0);
/*//			scrollPosition = this.gameObject.transform.position;
			scrollPosition += Vector3.forward * scroll * scrollspeed;
			if ( Mathf.Abs(scrollPosition.z - originpos.z) < scrollwidth ) {
				this.gameObject.transform.position = scrollPosition;
			};	//*/
		} else {
			transform.localScale -= new Vector3(0.1F, 0, 0);
		}
	}
	}
}
