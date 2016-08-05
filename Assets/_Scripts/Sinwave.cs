using UnityEngine;
using System.Collections;

public class Sinwave : MonoBehaviour {

	//Temp vector
	private Vector3 objectPosition, tempVector;
	//Store start time
	private float 	startTime;
	public 	float 	rotationSpeed	= 2;
	public 	float 	magnitude		= 2;

	void Start () {
		startTime = Time.time;
		objectPosition = gameObject.GetComponent<Rigidbody> ().transform.position;
		Debug.Log (startTime.ToString());
	}

	void Update () {

		//Write position vector to temp
		//objectPosition = gameObject.GetComponent<Rigidbody> ().transform.position; 
		//Modify temp vector
		tempVector.x = magnitude * Mathf.Sin (startTime-Time.time*rotationSpeed);
		tempVector.z = magnitude * Mathf.Cos (startTime-Time.time*rotationSpeed);
		//Write temp vector back into actual position vecotr
		gameObject.GetComponent<Rigidbody> ().transform.position = objectPosition + tempVector;

	}
}
