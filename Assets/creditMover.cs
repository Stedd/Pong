using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class creditMover : MonoBehaviour {

	//tempVector

	Vector3 startPos 	= new Vector3 (0, -7, 0);
	Vector3 tempVec 	= new Vector3 ();
	public float speed 	= 0.1f;

	// Use this for initialization
	void Start () {

		//Set start position to text
		gameObject.GetComponent<Transform> ().transform.position = startPos;

	}
	
	// Update is called once per frame
	void FixedUpdate () {

		//scroll upwards

		if (tempVec.y < 7) {
			tempVec = gameObject.GetComponent<Transform> ().transform.position;

			tempVec.y += speed;

			gameObject.GetComponent<Transform> ().transform.position = tempVec;
		} 

		else {
			SceneManager.LoadScene("Main Menu");
		}
	}
}
