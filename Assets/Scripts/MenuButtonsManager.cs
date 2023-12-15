using System.Collections;
using System.Collections.Generic;
using System.Windows;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtonsManager : MonoBehaviour
{
    public GameObject messageBox, gameOver, gameWin;

    public void PlayButton()
    {
        SceneManager.LoadScene(1);
    }

    public void QuitButton()
    {
        UnityEngine.Application.Quit();
    }

    public void MenuButton()
    {
        SceneManager.LoadScene(0);
    }

    public void OKButton()
    {
        messageBox.SetActive(false);
    }

    public void OKButton2()
    {
        gameOver.SetActive(false);
    }
    
    public void OKButton3()
    {
        gameWin.SetActive(false);
    }

    public void RestartButton()
    {
        SceneManager.LoadScene(1);
    }
}
