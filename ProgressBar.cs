using UnityEngine.UI;
using UnityEngine;

public class ProgressBar : MonoBehaviour
{
    [SerializeField] private Image _fillOption;
    [SerializeField] private GameObject _levelEndScript;
    LevelEnd levelEnd;

    [Header("Time")]
    [SerializeField] private float _highestTime;
    [SerializeField] private float _lowerTime;

    public bool _canStart = false;

    private float _time;

    private void Start()
    {
        levelEnd = _levelEndScript.GetComponent<LevelEnd>();

        _time = Random.Range(_highestTime, _lowerTime);
    }

    private void FixedUpdate()
    {
        if(_canStart)
        {
            _fillOption.fillAmount += _time;

            if(_fillOption.fillAmount == 1)
            {
                levelEnd.Win();
            }
        } 
    }
}
