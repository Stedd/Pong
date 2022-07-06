using UnityEngine;
using System.Collections.Generic;

public class AI_Control : MonoBehaviour
{
    [SerializeField] private Main _gameMaster;
    [SerializeField] private ObjectPool _objectPool;
    [SerializeField] private GameObject _closestBall;
    [SerializeField] private float speed = 23;
    [SerializeField] private float posDiff;
    [SerializeField] private float hysteresis = 3;
    [SerializeField] private float ballPositionY;
    [SerializeField] private float minY = -12;
    [SerializeField] private float maxY = 12;

    void Update()
    {
        if (!(_gameMaster.WinConditionMet))
        {
            aiActivate();
        }
    }

    void aiActivate()
    {
        Vector3 position = gameObject.transform.position;

        if (_objectPool != null && _objectPool.ActiveBalls.Count > 0)
        {
            _closestBall = FindClosestBall();
            ballPositionY = _closestBall.transform.position.y;
        }
        else
        {
            ballPositionY = position.y;
        }

        //Modify
        posDiff = ballPositionY - position.y;

        if ((posDiff > hysteresis) && position.y <= maxY)
        {
            position.y += speed * Time.deltaTime;
        }
        if ((posDiff < hysteresis * -1) && position.y >= minY)
        {
            position.y -= speed * Time.deltaTime;
        }

        //Write back
        gameObject.GetComponent<Rigidbody>().transform.position = position;
    }

    public GameObject FindClosestBall()
    {
        float currentMinimumDistance = float.MaxValue;
        GameObject closestBall = _objectPool.ActiveBalls[0];
        foreach (GameObject ball in _objectPool.ActiveBalls)
        {
            float distanceToCurrentBall = Vector3.Distance(gameObject.transform.position, ball.transform.position);
            if (distanceToCurrentBall < currentMinimumDistance)
            {
                currentMinimumDistance = distanceToCurrentBall;
                closestBall = ball;
            }
        }
        return closestBall;
    }
}


