using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject PlayerPointsTxt;
    public GameObject PlayerLifeTxt;
    public int totalPointsOfScene = 150;

    private int playerPoints = 0;
    private int playerLife = 100;
    // Start is called before the first frame update
    void Start()
    {
        PlayerPointsTxt.GetComponent<UnityEngine.UI.Text>().text = "Points: " + playerPoints.ToString();
        PlayerLifeTxt.GetComponent<UnityEngine.UI.Text>().text = "Life: " + playerLife.ToString();
    }

    public void addPlayerPoints(int Points){
        playerPoints += Points;
        PlayerPointsTxt.GetComponent<UnityEngine.UI.Text>().text = "Points: " + playerPoints.ToString();

        if(playerPoints >= totalPointsOfScene){
            // Caso a quantidade de pontos do player bata a quantidade
            // de pontos da faze chama a tela de wingame
            SceneManager.LoadScene("GameOver");
        }
    }

    public void removePlayerPoints(int Points){
        playerPoints -= Points;
        PlayerPointsTxt.GetComponent<UnityEngine.UI.Text>().text = "Points: " + playerPoints.ToString();
    }

    public void addPlayerLife(int Life){
        playerLife += Life;
        PlayerLifeTxt.GetComponent<UnityEngine.UI.Text>().text = "Life: " + playerLife.ToString();
    }

    public void removePlayerLife(int Life){
        playerLife -= Life;
        PlayerLifeTxt.GetComponent<UnityEngine.UI.Text>().text = "Life: " + playerLife.ToString();

        if(playerLife <= 0){
            SceneManager.LoadScene("GameOver");
        }
    }
}
