using UnityEngine;
using UnityEngine.SceneManagement;

public class DieLogic : MonoBehaviour
{
    [SerializeField] private GameObject _parentDieScreen;

    public void ShowDieScreen()
    {
        _parentDieScreen.SetActive(true);

        Time.timeScale = 0;
    }

    public void OnClickRestart()
    {
        SceneManager.LoadScene(1);
    }

    public void OnClickHome()
    {
        SceneManager.LoadScene(0);
    }
}
