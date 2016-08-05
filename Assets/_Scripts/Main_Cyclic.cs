using UnityEngine;
using System.Collections;

public class Main_Cyclic : MonoBehaviour {

	public GameObject ball;
	GameObject test;
	Vector3 zeroVec = new Vector3(0,5,0);
	public float x=1.0f, y=1.0f, z=1.0f;
	public string ballName;
	public int gridSizeX, gridSizeY;
	//Quaternion zeroRot = new Quaternion(0.0f,0.0f,0.0f);
	
    //Use this for initialization
	void Start () {

		gridSizeX += 1;
		gridSizeY += 1;

		for (int i=-gridSizeX/2; i<gridSizeX/2; i++) {
			for (int j=-gridSizeY/2; j<gridSizeY/2; j++) {
				GameObject newBall = (GameObject)Instantiate (ball, new Vector3 (i * 2, j * 2, 0), Quaternion.Euler (zeroVec));
				newBall.name = i.ToString()+","+j.ToString();
				//namelist.
				//ball.AddComponent<Rigidbody>();
				//ball.GetComponent<Rigidbody>() = 50;
				//test = GameObject.Find("Ball8");

			}
		}
/*
		for (int x = 1; x<=5; x++) {
			test = GameObject.Find (x.ToString()+"(Clone)");
			test.GetComponent<Transform> ().position = new Vector3 (Random.Range (0, 10), Random.Range (0, 10), Random.Range (0, 10));
			Debug.Log ("DOne "+x.ToString());
		}
*/
	}
/*
	// Update is called once per frame
	void Update () {
		for (int a=; a<=10; a++) {
			Debug.Log (a.ToString());
			test = GameObject.Find(a.ToString());

			for (int b = 1; b<5; b++) {
				//test.GetComponent<Transform> ().localScale = new Vector3 (Random.Range (0, 10), Random.Range (0, 10), Random.Range (0, 10)); 
				test.GetComponent<Rigidbody>().velocity = new Vector3(b,0,0);
			}

		}
	}
*/

}
