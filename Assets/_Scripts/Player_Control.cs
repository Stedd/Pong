using UnityEngine;
using System.Collections;

public class Player_Control : MonoBehaviour {

	public 	Vector3 	objectPosition;
	public 	float 		speed;
	public 	float 		minY, maxY;

	// Use this for initialization
	void Start () {
		speed 		= 23;
		minY 		= -12;
		maxY		= 12;
	}
	
	// Update is called once per frame
	void Update () {
		//Temp store object position vector
		objectPosition = gameObject.GetComponent<Rigidbody> ().transform.position;
		//Modify
		if (Input.GetKey ("up") && objectPosition.y <= maxY) {
			objectPosition.y += speed * Time.deltaTime;
		}
		if (Input.GetKey ("down") && objectPosition.y >= minY) {
			objectPosition.y -= speed * Time.deltaTime;
		}
		//Write back
		gameObject.GetComponent<Rigidbody> ().transform.position = objectPosition;
	}
}
