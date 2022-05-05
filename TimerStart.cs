using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerStart : MonoBehaviour
{
    [SerializeField] private GameObject _startPoint;

    [SerializeField] private GameObject _scriptProgressBar;
    ProgressBar progressBar;

    private void Start()
    {
        progressBar = _scriptProgressBar.GetComponent<ProgressBar>();

        Time.timeScale = 10;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Start"))
        {
            progressBar._canStart = true;

            Time.timeScale = 1;

            _startPoint.SetActive(false);
        }
    }

}
