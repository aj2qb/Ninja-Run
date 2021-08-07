using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LevelController : MonoBehaviour
{
    private bool restart = false;
    public GameOver gameOver;
    public StartScreen start;
    public PointsScript scoreKeeping;
    public int _finalScore = 0;
    public GameObject ninja; 
    

    public void GameOver()
    {
        //print("In level controller: " + _foodScore._score); 
        ninja.SetActive(false); 
        gameOver.Setup(_finalScore); // change this to increment score instead of 0
    }

    public void StartMenu()
    {
        start.Setup();
    }


    public bool getGameStatus()
    {
        return restart;
    }

    public void setGameStatus(bool gameStatus)
    {
        restart = gameStatus;
    }
   
    private void Start()
    {
        // always start on start screen
        StartMenu();


    }
    // Update is called once per frame
    void Update()
    {
        if (getGameStatus())
        {
            // go to restart menu
            GameOver();
            print("go to restart menu");

        }

        scoreKeeping.Setup(_finalScore);


    }
}
