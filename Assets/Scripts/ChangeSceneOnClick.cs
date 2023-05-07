using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneOnClick : MonoBehaviour
{
    public int onClickScene;

    public void openScene()
    {
        SceneManager.LoadScene(onClickScene);
    }

    public void quitGame()
    {
        Application.Quit();
    }
}
