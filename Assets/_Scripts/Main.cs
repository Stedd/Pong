using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Main : MonoBehaviour {

	//Bind text gameobjects for manipulation
	public GameObject 	playerScoreText, aiScoreText, announceText;

	//Score variables
	public int 			playerScore, aiScore;
	private float		winScore = 2;

	//Timer
	private float 		tempTime, showWinTextTime = 5;
	public bool			winConditionMet;

	void Start (){
	
		//Reset scores
		winConditionMet = false;
		playerScore = 0; 
		aiScore 	= 0;

		//Update score text
		announceText.GetComponent<TextMesh> ().text = "";
		playerScoreText.GetComponent<TextMesh> ().text 	= "Player Score: " 	+ playerScore.ToString ();
		aiScoreText.GetComponent<TextMesh> ().text 		= "A.I Score: " 	+ aiScore.ToString ();
	}

	void Update () {

		//Back to lobby if escape is pressed
		if(Input.GetKey("escape")){SceneManager.LoadScene(0);}

		//Winning condition

		if (playerScore >= winScore && !winConditionMet) {
			winCondition ("Player Wins");
		}
		 
		if (aiScore >= winScore  && !winConditionMet) {
			winCondition ("A.I Wins");
		}

		if (Time.time > tempTime && winConditionMet) {
			SceneManager.LoadScene("Credits");
		}

	}

	public void winCondition (string winnerName)
	{
		winConditionMet = true;
		tempTime = Time.time + showWinTextTime;
		announceText.GetComponent<TextMesh> ().text = winnerName;
	}

	//Modify score based on announcement from hazards
	public void updateScore(string hazardName){
		if (hazardName == "West_wall") {
			aiScore 	+=1;
		}
		if (hazardName == "East_wall") {
			playerScore +=1;
		}
		//Update text
		playerScoreText.GetComponent<TextMesh> ().text 	= "Player Score: " 	+ playerScore.ToString ();
		aiScoreText.GetComponent<TextMesh> ().text 		= "A.I Score: " 	+ aiScore.ToString ();

	}
}
