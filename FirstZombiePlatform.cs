using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstZombiePlatform : MonoBehaviour
{
    [Header("PrefabForSpawn")]
    [SerializeField] private GameObject[] _prefabForSpawn;
    [SerializeField] private List<GameObject> _alreadySpawnedPrefab;

    [Header("PrefabOption")]
    [SerializeField] private int _minCount;
    [SerializeField] private int _maxCount;
    private int _countForSpawn;

    [Header("Spawn")]
    private int _turnSpawnAtStart;
    private int[] _turnSpawnAtTrigger = new int[8];

    [Header("SpawnPlace")]
    [SerializeField] private Transform _spawnPlace;
    private Vector3 _spawnPlaceVector;

    [Header("SpawnOption")]
    [SerializeField] private float _angleFar;
    [SerializeField] private float _distanceSpawn;

    public void SpawnZombie()
    {
       //SpawnPrefab
        for(int i = 0; i <= (_prefabForSpawn.Length - 1); i++)
        {

            for(int j = 0; j <= _maxCount; j++)
            {
                _alreadySpawnedPrefab.Add(Instantiate(_prefabForSpawn[_turnSpawnAtStart]));
            }
            
            _turnSpawnAtStart++;
        }

        //DisablePrefab
        for(int i = 0; i <= (_alreadySpawnedPrefab.Count - 1); i++)
        {
            _alreadySpawnedPrefab[i].gameObject.SetActive(false);
        }

        //adopt
        for(int i = 0; i <=(_alreadySpawnedPrefab.Count - 1); i++)
        {
            _alreadySpawnedPrefab[i].transform.SetParent(gameObject.transform);
        }



        _spawnPlaceVector = _spawnPlace.transform.position;

        _countForSpawn = Random.Range(_minCount, _maxCount);
        int turnSpawn = 0;

        for(int i = 0; i <= _countForSpawn; i++)
        {
            float x = _spawnPlaceVector.x + Mathf.Sin(_angleFar/_countForSpawn * i) * _distanceSpawn;
            float z = _spawnPlaceVector.z + Mathf.Cos(_angleFar/_countForSpawn * i) * _distanceSpawn;

            _spawnPlaceVector.x = x;
            _spawnPlaceVector.z = z;

            _turnSpawnAtTrigger[i] = Random.Range(0, (_alreadySpawnedPrefab.Count - 1));
            turnSpawn = _turnSpawnAtTrigger[i];

            _alreadySpawnedPrefab[turnSpawn].transform.position = _spawnPlaceVector;
            _alreadySpawnedPrefab[turnSpawn].gameObject.SetActive(true);
        }
    }
}
