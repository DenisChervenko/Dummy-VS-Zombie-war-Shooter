using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CurrentLevel : MonoBehaviour
{
    [SerializeField] private TMP_Text _score;

    private int _temp;

    private void Start()
    {
        if(PlayerPrefs.HasKey("Level"))
        {
            _temp = PlayerPrefs.GetInt("Level");

            _score.text = System.Convert.ToString(_temp);
        }
        else
        {
            _temp = 1;

            _score.text = System.Convert.ToString(_temp);
        }
    }
}
