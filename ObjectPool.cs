using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [Header("ObjectForPool")]
    [SerializeField] private GameObject _roadPrefab;

    [Header("CountObject")]
    [SerializeField] private int _countRoadPrefab;

    [Header("ObjectList")]
    [SerializeField] private List<GameObject> _spawnedRoad;

    [Header("SpawnPoint")]
    [SerializeField] private Transform _spawnPointAtScene;
    private Vector3 _spawnPointAtCode;

    [Header("Time")]
    [SerializeField] private float _timeBetvenSpawn;
    private float _elapsedTime;

    [Header("PrefabTurn")]
    private int _currentTurnPrefab;

    private void Awake()
    {
        //initialize spawn point
        _spawnPointAtCode = _spawnPointAtScene.transform.position;

        //create prefab
        for(int i = 0; i <= (_countRoadPrefab - 1); i++)
        {
            _spawnedRoad[i] = Instantiate(_roadPrefab);
            if(i >= (_countRoadPrefab - 1))
            {
                for(int j = 0; j <= (_spawnedRoad.Count - 1); j++)
                {
                    _spawnedRoad[j].gameObject.SetActive(false);
                }
            }
        }
    }

    private void Update()
    {
        _elapsedTime += Time.deltaTime;

        if(_elapsedTime >= _timeBetvenSpawn)
        {
            if(_currentTurnPrefab >= 5)  
            {
                _currentTurnPrefab = 0;
            }

            _spawnedRoad[_currentTurnPrefab].transform.position = _spawnPointAtCode;

            _spawnedRoad[_currentTurnPrefab].gameObject.SetActive(true);

            _currentTurnPrefab++;

            _elapsedTime = 0;
        }
    }
}
