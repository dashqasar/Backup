using UnityEngine;
using System.Collections;

public class MagneticRepulsion : MonoBehaviour {

	public GameObject obj;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}
	public void OnCollisionEnter(Collision collision) { 
		Debug.Log ("this is pannel");
		applyRepulsion (obj);
	}

	void applyRepulsion(GameObject repulsor)
	{	/*//
		Vector3 repulseDiff = repulsor.transform.position - transform.position;
		float sqrRepulse = repulseDiff.sqrMagnitude;
		float repulseMass = repulsor.GetComponent<Rigidbody>().mass;
		repulsor.GetComponent<Rigidbody>().AddForce( -repulseDiff / -sqrRepulse * repulseMass * 50);
		*/
		Vector3 repulseMass = repulsor.GetComponent<Rigidbody> ().velocity;
		repulsor.GetComponent<Rigidbody> ().velocity = -repulseMass;
		Debug.Log ("collide");
	}

}
