using UnityEngine;
using System.Collections;

public class Hazard_zone : MonoBehaviour {

	[SerializeField] private Main _gameMaster;
	[SerializeField] private Instantiator _instantiator;


	void OnTriggerEnter(Collider other){
		//Destroy ball
		Destroy (other.gameObject);
		//Generate new ball on collission
		if (!_gameMaster.WinConditionMet) {
			_instantiator.InitializePool ();
		}
		//announce hazard name to Main script to update score
		_gameMaster.UpdateScore (gameObject.name);
	}

}
