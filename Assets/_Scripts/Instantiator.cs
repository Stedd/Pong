using UnityEngine;
using System.Collections;

public class Instantiator : MonoBehaviour {

	//Load prefab
	public 	GameObject 	preFab;
	//Temp gameobject for setting new object configuration	
	private GameObject 	newObject;
	//InstantiateID
	public 	string 		instantiateName; 
	public 	int 		instantiateID;
	//Position, rotation, velocity
	public 	Vector3 	positionVec, rotationVec, velocityVec;
	//TEST
	private float 		spawnRate, nextSpawn;

	public int			gridSizeX, gridSizeY;

	void Start(){
//		nextSpawn = 0.0f;
//		spawnRate = 0.7f;
		generate ();
	}

	void Update(){
		if (Input.GetKeyDown("mouse 0")) {
			generate ();
			//generateCluster ();
		}

//		if (Time.time > nextSpawn) {
//			generate ();
//			nextSpawn = Time.time + spawnRate;
//		}
	}

	public void generate () {
		//Generate new object
		newObject 		= (GameObject)Instantiate (preFab, positionVec, Quaternion.Euler(rotationVec));
		//Set new object ID
		newObject.name 	= instantiateName + instantiateID.ToString ();
		//Set new velocity for rigid body for object
		newObject.GetComponent<Rigidbody> ().velocity = velocityVec;
		//Increase ID number for next object
		instantiateID 	+= 1;
	}

	void generateCluster () 
	{
		for (int i = -gridSizeX / 2; i <= gridSizeX / 2; i++) 
		{
			for (int j = -gridSizeY / 2; j <= gridSizeY / 2; j++)
			{
				GameObject newBall = (GameObject)Instantiate (preFab, new Vector3 (i * 2, j * 2, 0), Quaternion.Euler (rotationVec));
				newBall.name = i.ToString () + "," + j.ToString ();

			}
		}
	}
}
