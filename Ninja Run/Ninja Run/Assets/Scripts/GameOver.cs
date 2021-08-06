using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;


public class GameOver : MonoBehaviour
{
    public NinjaController ninja;
    public TMP_Text pointsText;

    public void Setup(int score)
    {
        gameObject.SetActive(true);
        pointsText.text = "Score: " + score.ToString();
    }

    public void RestartButton()
    {
        SceneManager.LoadScene("Level0");
        ninja.gameOver = false;

    }

    public void ExitButton() //Change this when you make a scene with a start menu
    {
        SceneManager.LoadScene("Start Screen");
    }


}
