using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadMenu : MonoBehaviour
{
    public void GoToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
    public void GMenu()
    {
        SceneManager.LoadScene("GMenu");
 Time.timeScale = 1f;
    }
}
