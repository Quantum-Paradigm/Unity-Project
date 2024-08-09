using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void LoadMainMenu(){
        SceneManager.LoadScene("MainMenu");
    }

    public void LoadHome(){
        SceneManager.LoadScene("SampleScene");
    }

    public void ExitApplication(){
    Application.Quit();
    }

}
