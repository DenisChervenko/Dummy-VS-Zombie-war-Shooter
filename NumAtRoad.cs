using System.Runtime.Serialization;
using System;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NumAtRoad : MonoBehaviour
{
    [Header("TextNum")]
    [SerializeField] private TextMesh _leftNumber;
    [SerializeField] private TextMesh _rightNumber;

    [Header("BagroundNum")]
    [SerializeField] private SpriteRenderer _leftImage;
    [SerializeField] private SpriteRenderer _rightImage;

    [Header("Color")]
    [SerializeField] private Color _positiveColor;
    [SerializeField] private Color _negativeColor;

    [Header("ValueNum")]
    private int _leftNum;
    private int _rightNum;

    [SerializeField] private GameObject _trumped;

    //script
    private GameObject _unitManager;
    UnitManager unitManager;

    SpawnZombie spawnZombie;
    
    private void Start()
    {
        _unitManager = GameObject.Find("PlayerContoller");
        unitManager = _unitManager.GetComponent<UnitManager>();

        spawnZombie = gameObject.GetComponent<SpawnZombie>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            if(unitManager._sideRoad == 0)
            {
                if(_leftNum < 0)
                {
                    unitManager._countSpawn = (_leftNum - 1);
                }
                else if(_leftNum > 0)
                {
                    unitManager._countSpawn += _leftNum;
                }
            }
            else if(unitManager._sideRoad == 1)
            {
                if(_rightNum < 0)
                {
                    unitManager._countSpawn = (_rightNum - 1);
                }
                else if(_rightNum > 0)
                {
                    unitManager._countSpawn += _rightNum;
                }
            }

            unitManager.CallingMethod();

            _rightImage.gameObject.SetActive(false);
            _leftImage.gameObject.SetActive(false);
            _leftNumber.gameObject.SetActive(false);
            _rightNumber.gameObject.SetActive(false);
            _trumped.SetActive(false);
        }

        if(other.gameObject.CompareTag("ChangeNumber"))
        {
            GenerateNumber();
        }
    }

    public void GenerateNumber()
    {
        spawnZombie.SpawZombie();

        _leftNum = UnityEngine.Random.Range(-7, 7);
        _rightNum = UnityEngine.Random.Range(-7, 7);

        //change num if it has same polarity or equal 0
        if((_leftNum == 0 && _rightNum == 0) || (_leftNum > 0 && _rightNum > 0) || (_leftNum < 0 && _rightNum < 0) || _leftNum == 0 || _rightNum == 0) 
        {
            _leftNum = UnityEngine.Random.Range(-7, -1);
            _rightNum = UnityEngine.Random.Range(1, 7);
        } 

        //change background color dependence of polarity num
        if(_leftNum > 0 && _rightNum < 0)
        {
            _leftImage.color = _positiveColor;
            _rightImage.color = _negativeColor;
        }
        else if(_leftNum < 0 && _rightNum > 0)
        {
            _leftImage.color = _negativeColor;
            _rightImage.color = _positiveColor;
        }

        //change 3d text 
        if(_leftNum > 0)
        {
            _leftNumber.text = "+" + Convert.ToString(_leftNum);
        }
        else
        {
            _leftNumber.text = Convert.ToString(_leftNum);
        }
        
        if(_rightNum > 0)
        {
            _rightNumber.text = "+" + Convert.ToString(_rightNum); 
        }
        else
        {
            _rightNumber.text = Convert.ToString(_rightNum);
        }
    }

    public void ActiveSomePartRoad()
    {
        _rightImage.gameObject.SetActive(true);
        _leftImage.gameObject.SetActive(true);
        _leftNumber.gameObject.SetActive(true);
        _rightNumber.gameObject.SetActive(true);
        _trumped.SetActive(true);
    }
}
