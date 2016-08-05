using UnityEngine;
using System.Collections;

public class ai_control : MonoBehaviour 
{

	public 	Vector3 	objectPosition;
	public 	Vector3[]	ballPosition;
	public 	float 		speed, posDiff, hysteresis;
	public	float		ballPositionY;
	public 	float 		minY, maxY;
	
	// Use this for initialization
	void Start () 
	{
		speed 		= 23;
		hysteresis 	= 3f;
		minY 		= -12;
		maxY		= 12;
	}
	
	// Update is called once per frame
void Update ()
	{
		if (! (GameObject.FindWithTag("GameController").GetComponent<Main>().winConditionMet)) {
			aiActivate ();
		} 

	}

	void aiActivate(){
		//Temp store object position vector
		objectPosition = gameObject.GetComponent<Rigidbody> ().transform.position;
		//TODO:find closes ball and follow
//		ballPositionY = FindObjectOfType<Movement> ().transform.position.y;
		ballPositionY = GameObject.FindWithTag("Ball").GetComponent<Movement>().transform.position.y;
		//Modify
		posDiff = ballPositionY - objectPosition.y;

		if ((posDiff > hysteresis) && objectPosition.y <= maxY) {
			objectPosition.y += speed * Time.deltaTime;
		}
		if ((posDiff < hysteresis * -1) && objectPosition.y >= minY) {
			objectPosition.y -= speed * Time.deltaTime;
		}

		//Write back
		gameObject.GetComponent<Rigidbody> ().transform.position = objectPosition;
	}
}


