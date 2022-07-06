using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObjectPool : MonoBehaviour
{
    #region Inspector
    //Load prefab
    [SerializeField] private GameObject _prefab;
    [SerializeField] private GameObject _ballPool;

    [Header("ObjectPoolConfig")]
    [SerializeField] private int _objectsToSpawn = 40;
    [SerializeField] private List<GameObject> _objectPool;
    //Temp gameobject for setting new object configuration	
    //InstantiateID
    [SerializeField] private string _instantiateName;
    [SerializeField] private int _instantiateID;
    //Position, rotation, velocity
    [SerializeField] private Vector3 _positionVec, _rotationVec, _velocityVec;
    //TEST
    [SerializeField] private float _spawnRate, _nextSpawn;

    [SerializeField] private int _gridSizeX, _gridSizeY;

    #endregion

    void Awake()
    {
        InitializePool();
    }

    private void Start()
    {
        GetFreeBall();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            GetFreeBall();
        }
    }

    public void GetFreeBall()
    {
        foreach (GameObject ball in _objectPool)
        {
            if (!ball.activeSelf)
            {
                ball.transform.position = _positionVec;
                ball.GetComponent<Rigidbody>().velocity = _velocityVec;
                ball.SetActive(true);
                break;
            }
        }
    }

    public void InitializePool()
    {
        GameObject _tempGO;

        for (int i = 0; i < _objectsToSpawn; i++)
        {
            _tempGO = (GameObject)Instantiate(_prefab, _positionVec, Quaternion.Euler(_rotationVec), _ballPool.transform);
            _tempGO.name = _instantiateName + _instantiateID.ToString();
            _tempGO.SetActive(false);
            _tempGO.GetComponent<Rigidbody>().velocity = _velocityVec;
            _objectPool.Add(_tempGO);
            _instantiateID += 1;
        }
    }

    [ContextMenu("GenerateCluster")]
    void generateCluster()
    {
        for (int i = -_gridSizeX / 2; i <= _gridSizeX / 2; i++)
        {
            for (int j = -_gridSizeY / 2; j <= _gridSizeY / 2; j++)
            {
                GameObject newBall = (GameObject)Instantiate(_prefab, new Vector3(i * 2, j * 2, 0), Quaternion.Euler(_rotationVec), _ballPool.transform);
                newBall.name = $"ClusterBall[{i},{j}]";

            }
        }
    }
}
