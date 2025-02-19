using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GampePlay : MonoBehaviour
{
    public void LoadGame()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void GoToScene(string name)
    {
        SceneManager.LoadScene(name);
    }


}
