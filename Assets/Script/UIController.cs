using UnityEngine;
using System.Collections;

public class UIController : MonoBehaviour {

	// Use this for initialization

	Vector3 origionPos;
	private Renderer CubeRenderer;
	private Renderer sphereRenderer; 
	public GameObject ga ;
	public Rigidbody SphereRb;
	public Color[] ColorSel;
	void Start() {
		origionPos = transform.position;
		CubeRenderer = ga.GetComponent<Renderer> ();
		CubeRenderer.enabled = true;
		SphereRb = GetComponent<Rigidbody>();
		sphereRenderer = GetComponent<Renderer>();
	}
	void OnCollisionEnter(Collision collision) { 
		SetColor ();
		//SphereRb.AddForce(0, 0, 0);
		Debug.Log ("i am sphere, ");

	}
	void SetColor(){
		int i = Random.Range(1,10);
		sphereRenderer.material.color = ColorSel[i];
	}
	
	// Update is called once per frame
	void Update () {

	}
	void OnGUI()
	{
		GUILayout.BeginArea(new Rect(Screen.width/2 -100, Screen.height -60, 400, 50));
		
		GUI.Label(new Rect (80, 20, 100, 20), "Please drage Mouse" );
		
		GUILayout.BeginHorizontal();

		if ( GUI.Button(new Rect (15, 15, 60, 30), "Rest") ) 
		{
			transform.position = origionPos;
			CubeRenderer.material.color = Color.white;
			SphereRb.useGravity = false;

		}

		if ( GUI.Button(new Rect(165, 15, 60, 30), "Play") ) 
		{
			//isMove = true;
			SphereRb.useGravity = true;

		}

		GUILayout.EndArea ();
	}
}
