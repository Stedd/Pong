using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

	//Movement
	public 	Vector3 	objectPosition;
	public 	Vector3 	directionVector;
	public 	float 		speed;

	//Private
	public	float 		minAngle, maxAngle;

	//Timing
	public 	float 		startTime;
	public	float 		holdTime;

	//Scale
	public	Vector3 	scaleVector = new Vector3 (1,1,1);
	public	int			pointValue 	= 10;
		
	void Start () {
		//Log start time
		startTime = Time.time;
		//Generate new directionVector
		directionVector = newAngle (true, false, minAngle, maxAngle, 0);
	}

	public void FixedUpdate () {

		//Hold ball for "holdTime" before it starts moving
		if (Time.time > (startTime + holdTime)) {
			//Temp store object position vector
			objectPosition = gameObject.GetComponent<Rigidbody> ().transform.position;
			//Modify
			objectPosition += directionVector * speed * Time.deltaTime;
			//Write back
			gameObject.GetComponent<Rigidbody> ().transform.position = objectPosition;
		}
	}

	public Vector3 newAngle(bool random,bool invertDirection, float min, float max, float newAngle){

		//Tempvector for return
		Vector3 tempVector = new Vector3 (0,0,0);
		float tempAngle;

		//Generate random radian from input range
		if (random) {
			tempAngle = Random.Range (min, max);
		}
		else{
			tempAngle = newAngle;
		}
		
		tempAngle *= Mathf.Deg2Rad;

		//Decompose random radian and store in direction vector
		tempVector.y = Mathf.Sin (tempAngle);
		tempVector.x = Mathf.Cos (tempAngle);

		//Random direction
		if((random && Random.value>0.5f)|| invertDirection ){tempVector.x *= -1;}

		//Return startvector
		return tempVector;
	}
}
