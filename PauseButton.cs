using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseButton : MonoBehaviour
{
    [SerializeField] private GameObject _homeButton;
    [SerializeField] private GameObject _backButton;

    [SerializeField] private GameObject _pauseButton;
    [SerializeField] private GameObject _callButton;

    public void OnClickPause()
    {
        _backButton.SetActive(true);
        _homeButton.SetActive(true);

        _pauseButton.SetActive(false);
        _callButton.SetActive(false);

        Time.timeScale = 0;
    }

    public void OnClickResume()
    {
        _backButton.SetActive(false);
        _homeButton.SetActive(false);

        _pauseButton.SetActive(true);
        _callButton.SetActive(true);

        Time.timeScale = 1;
    }

    public void OnClickHome()
    {
        SceneManager.LoadScene(0);
    }
}
