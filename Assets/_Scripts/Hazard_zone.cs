using UnityEngine;
using System.Collections;

public class Hazard_zone : MonoBehaviour {


	void OnTriggerEnter(Collider other){
		//Destroy ball
		Destroy (other.gameObject);
		//Generate new ball on collission
		if (! (GameObject.FindWithTag("GameController").GetComponent<Main>().winConditionMet)) {
			FindObjectOfType<Instantiator> ().generate ();
		}
		//announce hazard name to Main script to update score
		FindObjectOfType<Main> ().updateScore (gameObject.name);
	}

}
