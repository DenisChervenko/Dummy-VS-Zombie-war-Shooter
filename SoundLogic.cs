using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundLogic : MonoBehaviour
{
    [SerializeField] private GameObject _soundOn;
    [SerializeField] private GameObject _soundOff;

    public void OnClickSoundOn()
    {
        AudioListener.volume = 0;
        _soundOn.SetActive(false);
        _soundOff.SetActive(true);
    }

    public void OnClickSoundOff()
    {
        AudioListener.volume = 1;
        _soundOff.SetActive(false);
        _soundOn.SetActive(true);
    }
}
