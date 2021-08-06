using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class StartScreen : MonoBehaviour
{
    public GameObject helpMenu;
  
    public void Setup()
    {
        gameObject.SetActive(true);

    }


    public void BeginPlay()
    {
        SceneManager.LoadScene("Level0");
    }

    public void openHelpMenu()
    {
        helpMenu.SetActive(true);
    }

    public void closeHelpMenu()
    {
        helpMenu.SetActive(false);
    }
}
