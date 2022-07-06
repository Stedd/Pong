using UnityEngine;
using System.Collections;

public class PaddleBounce : MonoBehaviour
{

    [SerializeField] private Vector3 tempdirectionVector, paddlePosition, colissionPosition;
    [SerializeField] private float paddleSize, yDifference;
    [SerializeField] private int angleRange;
    [SerializeField] private bool invertDirection;

    void OnTriggerEnter(Collider other)
    {
        paddlePosition = gameObject.GetComponent<Transform>().position;
        paddleSize = gameObject.GetComponent<Transform>().localScale.y;
        colissionPosition = other.gameObject.GetComponent<Transform>().position;
        Movement _ballMovement = other.gameObject.GetComponent<Movement>();

        tempdirectionVector = _ballMovement.DirectionVector;

        if (gameObject.tag == ("hazard_border"))
        {
            tempdirectionVector.y *= -1;
            _ballMovement.DirectionVector = tempdirectionVector;
        }

        if (gameObject.tag == ("paddle"))
        {
            yDifference = paddlePosition.y - colissionPosition.y;
            tempdirectionVector.y = (angleRange / (paddleSize / 2)) * yDifference * -1;

            if (gameObject.name == ("ai_paddle"))
            {
                invertDirection = true;
            }
            if (gameObject.name == ("player_paddle"))
            {
                invertDirection = false;
            }

            _ballMovement.DirectionVector = _ballMovement.NewAngle(false, invertDirection, 0, 0, tempdirectionVector.y);
        }
    }
}
