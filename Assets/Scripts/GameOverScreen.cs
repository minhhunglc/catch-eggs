using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverScreen : MonoBehaviour
{
    public Text scoresText;

    public void Setup(int score)
    {
        gameObject.SetActive(true);
        scoresText.text = " SCORES: " + score.ToString();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("Game");

    }
    public void MainGame()
    {
        SceneManager.LoadScene("MainMenu");
    }


}

