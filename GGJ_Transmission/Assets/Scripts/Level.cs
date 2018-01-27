using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour {



    void Game()
{
        SceneManager.LoadScene("Game");
}

    void Menu()
    {
        SceneManager.LoadScene("Menu");
    }

    void Quit()
    {
        Quit();
    }

}
