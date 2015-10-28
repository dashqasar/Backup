using UnityEngine;
using System.Collections;

public class CollideDetection : MonoBehaviour {

	// Use this for initialization
	public Transform  obj;
	private Transform character;
	private RaycastHit hit ;
	private Renderer rend;
	
	// Use this for initialization
	void Awake () {
		character = transform;
		hit = new RaycastHit ();
	}

	void Start () {
		rend = GetComponent<Renderer> ();
		rend.enabled = true;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public bool CanSeeObject () {
		Vector3 objDirection  = (obj.position - character.position);
		
		Physics.Raycast (character.position, objDirection,out hit, objDirection.magnitude);
		if ( hit.collider && hit.collider.transform == obj ) {
			return true;
		}
		return false;
	}
	
	public void OnCollisionEnter(Collision other) {
		if ( other.transform == obj && CanSeeObject() ) {
			// do something;

			rend.material.color = Color.red;
			Debug.Log("I am collider");
			//TrackCollision();
		}
	}
}
