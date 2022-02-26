using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseManager : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject PauseMenu;
    public GameObject AreYouSure;
    public static bool isPaused = false;
    public GameObject General;
    public LevelLoader loader;

    public Image menu1;
    public Image menu2;

    public Image no1;
    public Image no2;

    private void Start()
    {
        menu1.enabled = false;
        menu2.enabled = false;

        no1.enabled = false;
        no2.enabled = false;

    }
    // Update is called once per frame
    void Update()
    {
     if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void ResumeGame()
    {
        PauseMenu.SetActive(false);
        Time.timeScale = 1;
        isPaused = false;
    }

    public void PauseGame()
    {
        PauseMenu.SetActive(true);
        Time.timeScale = 0;
        isPaused = true;
    }

    public void GoToMenu()
    {
        Time.timeScale = 1;
        loader.LoadMenu();
    }
}
