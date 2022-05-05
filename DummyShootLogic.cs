using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyShootLogic : MonoBehaviour
{
    [Header("SpawnPart")]
    [SerializeField] private GameObject _objectForSpawn;
    [SerializeField] private int _countSpawn;
    [SerializeField] private Transform _spawnPoint;

    [Header("Time")]
    [SerializeField] private float _timeBetwenSpawn;
    private float _elapseTime;

    private int _turn = 0;
    private bool _canShot = false;
    private Vector3 _spawnPointVector;
    [SerializeField] private List<GameObject> _bulletWasSpawned;

    [SerializeField] private AudioSource _shootSound;

    private void Awake()
    {
        for(int i = 0; i <= _countSpawn; i++)
        {
            _bulletWasSpawned.Add(Instantiate(_objectForSpawn));

            if(i >= _countSpawn)
            {
                for(int j = 0; j <= (_bulletWasSpawned.Count - 1); j++)
                {
                    _bulletWasSpawned[j].gameObject.SetActive(false);
                }
            }
        }
    }

    private void FixedUpdate()
    {
        if(_canShot)
        {
            _elapseTime += Time.fixedDeltaTime;

            if(_elapseTime >= _timeBetwenSpawn)
            {
                _spawnPointVector = _spawnPoint.transform.position;
                _bulletWasSpawned[_turn].transform.position = _spawnPointVector;
                
                _bulletWasSpawned[_turn].gameObject.SetActive(true);
                _turn++;

                _shootSound.Play();

                if(_turn == 10)
                {
                    _turn = 0;
                }
                
                _elapseTime = 0;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("ShotZone"))
        {
            _canShot = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.CompareTag("ShotZone"))
        {
            _canShot = false;
            _turn = 0;
        }
    }
}
