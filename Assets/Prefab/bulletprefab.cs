using UnityEngine;
using System.Collections;

public class bulletprefab : MonoBehaviour {
	public float speed = 1000;
	public float lifeTime = 0.5f;
	public float dist = 100;
	private float spawnTime = 0.0f;
//	private Transform tr;
	// Use this for initialization
	void Start () {
//		tr = transform;
		spawnTime = Time.time;
		Debug.Log ("bullet activate!");
	
	}
		
	// Update is called once per frame
	void Update () {

//		tr.position += tr.forward * speed * Time.deltaTime;
		dist -= speed * Time.deltaTime;
		//Debug.Log (dist);
		if (Time.time > spawnTime + lifeTime || dist < 0) {
			Destroy (gameObject);
		}
	}
}
