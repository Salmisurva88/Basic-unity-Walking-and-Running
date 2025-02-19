using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void LoadGame()
    {
        SceneManager.LoadScene("GamePlay");
    }

    public void GoToScene(string name)
    {
        SceneManager.LoadScene(name);
    }


}
