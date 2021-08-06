using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PointsScript : MonoBehaviour
{
    public TMP_Text _mainPointsText;
    public NinjaController ninja;

    public void Setup(int score)
    {
        _mainPointsText.text = "Score: " + score.ToString();
    }

    public void Update()
    {
        if (ninja.gameOver)
        {
            gameObject.SetActive(false);
        }
        else
        {
            gameObject.SetActive(true);
        }

    }

}