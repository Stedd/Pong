using UnityEngine;
using System.Collections;

public class Movement_Old : MonoBehaviour {

	//Variables
	public GameObject pongBall;
	public float speed;
	public float startAngleSpan, paddleAngleSpan;
	Vector3 directionVector;

	//Init
	void start(){
		pongBall.transform.position = new Vector3 (10, 10, 0);
		directionVector = new Vector3(0,-1,0);
	}

	void SphereCollider(SphereCollider collision){
/*
		if(collision.gameObject.tag == "Goal"){
			//Notify score controller +=1
			//Destroy ball
			
		}

		if(collision.gameObject.tag == "Boundary"){
			//Invert X angle
			
		}
*/
		if(collision.gameObject.tag == "Paddle"){
			//Modify Y angle
			directionVector = speed * newAngle(paddleAngleSpan, pongBall.transform.position, collision.gameObject);
		}
	}

	//Update loop
	void Updatefixed () {

		//Movement
		pongBall.transform.position += directionVector*speed;
	}

	Vector3 newAngle(float angleSpan, Vector3 localPos, GameObject collissionPos){
		Vector3 paddleLength = collissionPos.transform.localScale;
		Vector3 posDiff = localPos - collissionPos.transform.position;
		float angleOutY = ((angleSpan / paddleLength.y) * posDiff.y );
		Vector3 vectorOut = new Vector3(0, (Mathf.Asin(angleOutY)),0);		                    
		return vectorOut;
	}
}
