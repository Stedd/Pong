using UnityEngine;
using System.Collections;

public class Hazard_zone : MonoBehaviour {

	[SerializeField] private Main _gameMaster;
	[SerializeField] private ObjectPool _instantiator;


	void OnTriggerEnter(Collider other){
		//Destroy ball
		other.gameObject.SetActive(false);

		if (!_gameMaster.WinConditionMet) {
			Invoke(nameof(SpawnNewBall), Random.value*5);
		}
		//announce hazard name to Main script to update score
		_gameMaster.UpdateScore (gameObject.name);
	}

	private void SpawnNewBall()
    {
		_instantiator.GetFreeBall();
	}

}
