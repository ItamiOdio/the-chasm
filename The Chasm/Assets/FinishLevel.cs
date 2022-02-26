using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLevel : MonoBehaviour
{
    LevelLoader loader;
    int points;
    void Start()
    {
        loader = (LevelLoader)FindObjectOfType(typeof(LevelLoader));
        transform.GetChild(0).gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.GetChild(0).gameObject.activeInHierarchy)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                points = 100 + ManageScore.lanternsAlight * 20;
                if (ManageScore.lanternsAlight == ManageScore.lanternsInScene)
                {
                    points += 100;
                }
                PlayerStats.UpdatePoints(points);
                if (SceneManager.GetActiveScene().name == "Level 5")
                {
                    if(PlayerStats.points > PlayerPrefs.GetInt("BestScore", 0))
                    {
                        PlayerPrefs.SetInt("BestScore", PlayerStats.points);
                    }
                }
                loader.LoadNextScene();
            
                Debug.Log("Fin lvl");
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            transform.GetChild(0).gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        transform.GetChild(0).gameObject.SetActive(false);
    }

    
}
