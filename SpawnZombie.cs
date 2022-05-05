using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnZombie : MonoBehaviour
{
    [SerializeField] private GameObject[] _zombie;
    [SerializeField] private List<GameObject> _zombieWasSpawned;

    [SerializeField] private Transform[] _spawnPoint;
    [SerializeField] private Vector3[] _spawnPointVector;

    private int _turnSpawn;
    private int _turnSpawnStart;
    private void Start()
    {

        for(int i = 0; i <= (_zombieWasSpawned.Count - 1); i++)
        {
            _zombieWasSpawned[i] = Instantiate(_zombie[_turnSpawnStart]);

            _turnSpawnStart++;
            if(_turnSpawnStart >= 3)
            {
                _turnSpawnStart = 0;
            }
        }

            
        

        for(int i = 0; i <= (_zombieWasSpawned.Count - 1); i++)
        {
            _zombieWasSpawned[i].gameObject.SetActive(false);
        }
    }

    public void SpawZombie()
    {
        for(int i = 0; i <= (_spawnPoint.Length -1); i++)
        {
            _spawnPointVector[_turnSpawn] = _spawnPoint[_turnSpawn].transform.position;

            _zombieWasSpawned[_turnSpawn].transform.position = _spawnPointVector[_turnSpawn];
            _zombieWasSpawned[_turnSpawn].gameObject.SetActive(true);

            _turnSpawn++;
        }
        
        _turnSpawn = 0;
    }
}
