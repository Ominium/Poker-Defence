using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class StartUI : MonoBehaviour
{

    public void NewGameButton()
    {
        PlayerPrefs.SetInt("Uitem1", 0);
        PlayerPrefs.SetInt("Uitem2", 0);
        PlayerPrefs.SetInt("Uitem3", 0);
        PlayerPrefs.SetInt("Round", 0);
        PlayerPrefs.SetInt("Gold", 0);
        PlayerPrefs.SetInt("UP0", 0);
        PlayerPrefs.SetInt("UP1", 0);
        PlayerPrefs.SetInt("UP2", 0);
        PlayerPrefs.SetInt("UP3", 0);
        PlayerPrefs.SetInt("UP4", 0);
        PlayerPrefs.SetInt("UP5", 0);
        SceneManager.LoadScene(1);
    }
    public void ContinueButton()
    {

        SceneManager.LoadScene(1);
    }
    public void ExitButton()
    {

        Application.Quit();
    }

}
