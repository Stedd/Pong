using UnityEngine;
using System.Collections;

public class border_bounce : MonoBehaviour {

	private Vector3 tempdirectionVector;

	void OnTriggerEnter(Collider other){

		//Temp store object position vector
		tempdirectionVector = other.gameObject.GetComponent<Movement> ().DirectionVector;
		//Modify
		if(gameObject.tag == ("hazard_border")){
		tempdirectionVector.y *= -1;
		}
		if(gameObject.tag == ("paddle")){
			tempdirectionVector.x *= -1;
		}
		//Write back
		other.gameObject.GetComponent<Movement> ().DirectionVector = tempdirectionVector;
	}
}
