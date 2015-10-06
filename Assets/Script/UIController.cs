using UnityEngine;
using System.Collections;

public class UIController : MonoBehaviour {

	// Use this for initialization
	public Collider coll;
	private bool isMove = false;
	Vector3 origionPos;
	private Renderer rend;
	public GameObject ga ;
	public Rigidbody rb;
	void Start() {
		origionPos = transform.position;
		rend = ga.GetComponent<Renderer> ();
		rend.enabled = true;
		rb = GetComponent<Rigidbody>();
	}
	void OnTriggerEnter(Collider other) {
		isMove = false;
		rb.AddForce(0, 0, 0);
		Debug.Log ("i am sphere, ");
	}
	
	// Update is called once per frame
	void Update () {
		if (isMove == true) {
			Vector3 pos = new Vector3(transform.position.x, transform.position.y - Time.deltaTime * 2, transform.position.z);
			transform.position = pos;

		}
	
	}
	void OnGUI()
	{
		GUILayout.BeginArea(new Rect(Screen.width/2 -100, Screen.height -60, 400, 50));
		
		GUI.Label(new Rect (80, 20, 100, 20), "Please drage Mouse" );
		
		GUILayout.BeginHorizontal();

		if ( GUI.Button(new Rect (15, 15, 60, 30), "Rest") ) 
		{
			isMove = false;
			transform.position = origionPos;
			rend.material.color = Color.white;

		}

		if ( GUI.Button(new Rect(165, 15, 60, 30), "Play") ) 
		{
			//isMove = true;
			rb.AddForce(0, -80, 0);

		}

		GUILayout.EndArea ();
	}
}
