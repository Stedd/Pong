using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour
{

    //Movement
    [SerializeField] private Vector3 objectPosition;
    [SerializeField] private Vector3 directionVector;
    [SerializeField] private float speed;

    //Private
    [SerializeField] private float minAngle, maxAngle;

    //Timing
    [SerializeField] private float startTime;
    [SerializeField] private float holdTime;

    //Scale
    [SerializeField] private Vector3 scaleVector = new(1, 1, 1);
    [SerializeField] private int pointValue = 10;

    #region Publics

    public Vector3 DirectionVector
    {
        get => directionVector;
        set => directionVector = value;
    }
    #endregion

    void OnEnable()
    {
        //Log start time
        startTime = Time.time;
        //Generate new directionVector
        directionVector = NewAngle(true, false, minAngle, maxAngle, 0);
    }

    public void FixedUpdate()
    {

        //Hold ball for "holdTime" before it starts moving
        if (Time.time > (startTime + holdTime))
        {
            //Temp store object position vector
            objectPosition = gameObject.GetComponent<Rigidbody>().transform.position;
            //Modify
            objectPosition += directionVector * speed * Time.deltaTime;
            //Write back
            gameObject.GetComponent<Rigidbody>().transform.position = objectPosition;
        }
    }

    public Vector3 NewAngle(bool random, bool invertDirection, float min, float max, float newAngle)
    {

        //Tempvector for return
        Vector3 tempVector = Vector3.zero;
        float tempAngle;

        //Generate random radian from input range
        if (random)
        {
            tempAngle = Random.Range(min, max);
        }
        else
        {
            tempAngle = newAngle;
        }

        tempAngle *= Mathf.Deg2Rad;

        //Decompose random radian and store in direction vector
        tempVector.y = Mathf.Sin(tempAngle);
        tempVector.x = Mathf.Cos(tempAngle);

        //Random direction
        if ((random && Random.value > 0.5f) || invertDirection) { tempVector.x *= -1; }

        //Return startvector
        return tempVector;
    }
}
