using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UnitManager : MonoBehaviour
{
    [Header("PlayerArray")]
    [SerializeField] private List<GameObject> _unitOne;
    [SerializeField] private List<GameObject> _unitTwo;
    [SerializeField] private List<GameObject> _unitThree;
   
    [Header("Spawn")]
    [SerializeField] private Transform[] _spawnPoint;
    [SerializeField] private Vector3[] _spawnPointCode;

    private int _currentLevelUnit;
    

    //left - 0
    //right - 1
    public int _sideRoad;
    public int _countSpawn = 0;

    public int _turnSpawnOnePrefab = 0;
    public int _turnSpawnTwoPrefab = 0;
    public int _turnSpawnThreePrefab = 0;


    [SerializeField] private GameObject _inerfaceScrript;
    DieLogic dieLogic;

    private void Start()
    {
        dieLogic = _inerfaceScrript.GetComponent<DieLogic>();

        for(int i = 1; i <= (_unitOne.Count - 1); i++)
        {
            _unitOne[i].gameObject.SetActive(false);
        }

        for(int i = 0; i <= (_unitOne.Count - 1); i++)
        {
            _unitTwo[i].gameObject.SetActive(false);
            _unitThree[i].gameObject.SetActive(false);
        }

        _turnSpawnOnePrefab = 1;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("LeftSide"))
        {
            _sideRoad = 0;
        }
        else if(other.gameObject.CompareTag("RightSide"))
        {
            _sideRoad = 1;
        }
    }

    public void CallingMethod()
    {
        if(_countSpawn >= 0)
        {
            SpawnUnit();
        }
        else if(_countSpawn <= 0)
        {
            DetermineWhoCanBeRemoved();
        }
    }

    private void SpawnUnit()
    {             
        if(_turnSpawnOnePrefab == 0)
        {
            _countSpawn -= 1;
        }

        for(int i = _turnSpawnOnePrefab; i <= _countSpawn; ++i)
        {
            if(_turnSpawnOnePrefab >= 9)
            {
                break;
            }

            SpawnAroundPlayer(0, _turnSpawnOnePrefab);
        }

        if(_turnSpawnOnePrefab == 9)
        {
            _turnSpawnOnePrefab = 0;
            _countSpawn = 0;

            for(int i = 0; i < _unitOne.Count; i++)
            {
                _unitOne[i].gameObject.SetActive(false);
            }       

            SpawnAroundPlayer(1, _turnSpawnTwoPrefab);
        }

        if(_turnSpawnTwoPrefab == 9)
        {
            _turnSpawnTwoPrefab = 0;
            _countSpawn = 0;

            for(int i = 0; i < _unitTwo.Count; i++)
            {
                _unitTwo[i].gameObject.SetActive(false);
            }

            SpawnAroundPlayer(2, _turnSpawnThreePrefab);
        }
    }

    private void SpawnAroundPlayer(int list, int currentTurn)
    {
        _spawnPointCode[currentTurn] = _spawnPoint[currentTurn].transform.position;

        if(list == 0)
        {
            _unitOne[_turnSpawnOnePrefab].transform.position = _spawnPointCode[currentTurn];
            _unitOne[_turnSpawnOnePrefab].gameObject.SetActive(true);

            _turnSpawnOnePrefab++;
        }
        else if(list == 1)
        {
            _unitTwo[_turnSpawnTwoPrefab].transform.position = _spawnPointCode[currentTurn];
            _unitTwo[_turnSpawnTwoPrefab].gameObject.SetActive(true);

            _turnSpawnTwoPrefab++;
        }
        else if(list == 2)
        {
            _unitThree[_turnSpawnThreePrefab].transform.position = _spawnPointCode[currentTurn];
            _unitThree[_turnSpawnThreePrefab].gameObject.SetActive(true);

            _turnSpawnThreePrefab++;
        }
    }

    private void DetermineWhoCanBeRemoved()
    {
        if(_turnSpawnThreePrefab >= 1)
        {
            RemoveUnit(2);
        }
        else if(_turnSpawnTwoPrefab >= 1)
        {
            RemoveUnit(1);
        }
        else if(_turnSpawnOnePrefab >= 1)
        {
            RemoveUnit(0);
        }
    }

    private void RemoveUnit(int levelUnit)
    {
        if(levelUnit == 2)
        {
            for(int i = _countSpawn; i < 0; i++)
            {
                _unitThree[_turnSpawnThreePrefab].gameObject.SetActive(false);

                _turnSpawnThreePrefab--;

                if(_turnSpawnThreePrefab < 0)
                {
                    _unitThree[0].gameObject.SetActive(false);

                    int turnTemp = _turnSpawnTwoPrefab;

                    for(int k = turnTemp; k < (_unitTwo.Count - 1); k++)
                    {
                        _unitTwo[_turnSpawnTwoPrefab].gameObject.SetActive(true);

                        _turnSpawnTwoPrefab++;
                    }

                    _countSpawn = _turnSpawnTwoPrefab;

                    break;
                }
            }
        }
        else if(levelUnit == 1)
        {

            for(int i = _countSpawn; i < 0; i++)
            {
                _unitTwo[_turnSpawnTwoPrefab].gameObject.SetActive(false);

                _turnSpawnTwoPrefab--;

                if(_turnSpawnTwoPrefab <= 0)
                {
                    _unitTwo[0].gameObject.SetActive(false);

                    int turnTemp = _turnSpawnOnePrefab;

                    for(int k = turnTemp; k < (_unitOne.Count - 1); k++)
                    {
                        _unitOne[_turnSpawnOnePrefab].gameObject.SetActive(true);

                        _turnSpawnOnePrefab++;
                    }

                    _countSpawn = _turnSpawnOnePrefab;

                    break;
                }
            }
        }
        else if(levelUnit == 0)
        {   
            if(_turnSpawnOnePrefab == 0)
            {
                _unitOne[0].gameObject.SetActive(false);

                DieLogicEvent();
            }

            for(int i = _countSpawn; i < 0; i++)
            {
                _unitOne[_turnSpawnOnePrefab].gameObject.SetActive(false);

                _turnSpawnOnePrefab--;

                if(_turnSpawnOnePrefab < 0)
                {
                    DieLogicEvent();
                }

                if(i == 0)
                {
                    break;
                }
            }
            
            _countSpawn = _turnSpawnOnePrefab;
        }
    }

    private void DieLogicEvent()
    {
        _turnSpawnOnePrefab = 1;
        _turnSpawnTwoPrefab = 0;
        _turnSpawnThreePrefab = 0;

        SceneManager.LoadScene(0);
    }
}
