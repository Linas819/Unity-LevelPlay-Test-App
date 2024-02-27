using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadPortrait()
    {
        SceneManager.LoadScene("Landscape");
    }

    public void LoadLandscape()
    {
        SceneManager.LoadScene("Portrait");
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
