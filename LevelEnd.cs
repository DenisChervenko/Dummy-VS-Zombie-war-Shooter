using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class LevelEnd : MonoBehaviour
{
    [SerializeField] private TMP_Text _currentLevel;
    private int _tempLevel = 1;

    private void Start()
    {
        if(PlayerPrefs.HasKey("Level"))
        {
            _tempLevel = PlayerPrefs.GetInt("Level");

            _currentLevel.text = System.Convert.ToString(_tempLevel);
        }
        else
        {
            _currentLevel.text = System.Convert.ToString(_tempLevel);
        }
    }

    public void Win()
    {
        _tempLevel++;

        PlayerPrefs.SetInt("Level", _tempLevel);

        SceneManager.LoadScene(1);
    }
}
