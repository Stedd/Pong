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
    [SerializeField] private List<GameObject> _activeBalls;
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

    #region Publics

    public List<GameObject> ActiveBalls { get => _activeBalls; }

    #endregion


    void Awake()
    {
        InitializePool();
    }

    private void Start()
    {
        //GetFreeBall();
        GenerateCluster();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            GetFreeBall();
        }

        _activeBalls.Clear();

        foreach (GameObject ball in _objectPool)
        {
            if (ball.activeSelf)
            {
                _activeBalls.Add(ball);
            }
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

    public void GetFreeBall(Vector3 pos)
    {
        foreach (GameObject ball in _objectPool)
        {
            if (!ball.activeSelf)
            {
                ball.transform.position = pos;
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
    void GenerateCluster()
    {
        for (int i = -_gridSizeX / 2; i <= _gridSizeX / 2; i++)
        {
            for (int j = -_gridSizeY / 2; j <= _gridSizeY / 2; j++)
            {
                GetFreeBall(new Vector3(i * 2, j * 2, 0));
            }
        }
    }
}
