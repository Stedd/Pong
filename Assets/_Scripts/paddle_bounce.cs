using UnityEngine;
using System.Collections;

public class paddle_bounce : MonoBehaviour {

	private Vector3 	tempdirectionVector, paddlePosition, colissionPosition;
	private float		paddleSize, yDifference;
	public 	int 		angleRange;
	private bool		invertDirection;
	void OnTriggerEnter(Collider other){
		//Get size of paddle and positions of collission 

		paddlePosition = gameObject.GetComponent<Transform> ().position;
		paddleSize = gameObject.GetComponent<Transform> ().localScale.y;
		colissionPosition = other.gameObject.GetComponent<Transform> ().position;

		//Temp store object direction vector

		tempdirectionVector = other.gameObject.GetComponent<Movement> ().directionVector;

		//Modify
		if(gameObject.tag == ("hazard_border")){
			//Invert angle

			tempdirectionVector.y *= -1;

			//Inverting one axis, no need to decompose, modify direction vector directly

			other.gameObject.GetComponent<Movement> ().directionVector = tempdirectionVector;
		}

		if(gameObject.tag == ("paddle")){
			//Calculate difference

			yDifference = paddlePosition.y - colissionPosition.y;

			//calculate new angle

			tempdirectionVector.y = (angleRange/(paddleSize/2))*yDifference * -1;

			if (gameObject.name==("ai_paddle"))
			    {
				invertDirection = true;
			}
			if(gameObject.name==("player_paddle")){
				invertDirection = false;
			}


			//Send new angle to ball, will be decomposed in movement script
			//Debug.Log(tempdirectionVector.y.ToString());
			other.gameObject.GetComponent<Movement> ().directionVector = other.gameObject.GetComponent<Movement> ().newAngle(false,invertDirection, 0, 0, tempdirectionVector.y);
		}
	}
}
