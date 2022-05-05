using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingButton : MonoBehaviour
{
    [SerializeField] private GameObject _settingButton;
    [SerializeField] private GameObject _score;
    [SerializeField] private GameObject _playButton;


    [SerializeField] private GameObject _backButton;
    [SerializeField] private GameObject _settingScreen;

    public void OnClickSetting()
    {
        _score.SetActive(false);
        _playButton.SetActive(false);
        _settingButton.SetActive(false);

        _backButton.SetActive(true);
        _settingScreen.SetActive(true);
    }

    public void OnClickBack()
    {
        _backButton.SetActive(false);
        _settingScreen.SetActive(false);

        _score.SetActive(true);
        _playButton.SetActive(true);
        _settingButton.SetActive(true);
    }
}
