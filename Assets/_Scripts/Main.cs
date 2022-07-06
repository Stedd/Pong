using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Main : MonoBehaviour
{
    //Score variables
    [Header("Scores")]
    [SerializeField] private int playerScore;
    [SerializeField] private int aiScore;
    [SerializeField] private int winScore = 200;

    [Header("Timers")]
    [SerializeField] private float tempTime = 5;
    [SerializeField] private float showWinTextTime = 5;
    [SerializeField] private bool winConditionMet;

    [Header("Textfields")]
    [SerializeField] private TextMesh playerScoreText;
    [SerializeField] private TextMesh aiScoreText;
    [SerializeField] private TextMesh announceText;


    #region Publics

    public bool WinConditionMet { get; }

    #endregion


    void Start()
    {
        //Reset scores
        winConditionMet = false;
        playerScore = 0;
        aiScore = 0;

        //Update score text
        announceText.text = "";
        playerScoreText.text = "Player Score: " + playerScore.ToString();
        aiScoreText.text = "A.I Score: " + aiScore.ToString();
    }

    void Update()
    {

        //Back to lobby if escape is pressed
        if (Input.GetKey(KeyCode.Escape)) { SceneManager.LoadScene(0); }

        //Winning condition

        if (playerScore >= winScore && !winConditionMet)
        {
            WinCondition("Player Wins");
        }

        if (aiScore >= winScore && !winConditionMet)
        {
            WinCondition("A.I Wins");
        }

        if (Time.time > tempTime && winConditionMet)
        {
            SceneManager.LoadScene("Credits");
        }

    }

    public void WinCondition(string winnerName)
    {
        winConditionMet = true;
        tempTime = Time.time + showWinTextTime;
        announceText.text = winnerName;
    }

    //Modify score based on announcement from hazards
    public void UpdateScore(string hazardName)
    {
        if (hazardName == "West_wall")
        {
            aiScore += 1;
        }
        if (hazardName == "East_wall")
        {
            playerScore += 1;
        }
        //Update text
        playerScoreText.text = "Player Score: " + playerScore.ToString();
        aiScoreText.text = "A.I Score: " + aiScore.ToString();
    }
}