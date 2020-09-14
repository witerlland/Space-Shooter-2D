using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public void retryGame(string SceneName){
        SceneManager.LoadScene(SceneName);

        if(Time.timeScale == 0){
            Time.timeScale = 1;
        }
    }

    public void closegame(){
        Application.Quit();
    }
}
