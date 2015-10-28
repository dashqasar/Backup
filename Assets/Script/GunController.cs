using UnityEngine;
using System.Collections;

public class GunController : MonoBehaviour {
	public GameObject bullet;
	private float distance = 10.0f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButton (0)) {
			//GameObject bul = (GameObject)Instantiate(bullet, transform.position, transform.rotation);
			//bul.transform.position = transform.position;
			//bul.GetComponent<bulletprefab>().OnEnabled();

			Vector3 position =new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance);
			position = Camera.main.ScreenToWorldPoint(position);
			var go = Instantiate(bullet, transform.position, Quaternion.identity) as GameObject;
			go.transform.LookAt(position);    
			//Debug.Log(position);    
			go.GetComponent<Rigidbody>().AddForce(go.transform.forward * 2000);
		}
	
	}
}
