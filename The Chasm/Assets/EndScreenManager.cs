using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndScreenManager : MonoBehaviour
{
    public LevelLoader loader;
    public Text score;
    public Text bestScore;

    private void Start()
    {
        score.text = PlayerStats.points.ToString();
        bestScore.text = PlayerPrefs.GetInt("BestScore", 0).ToString();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            loader.LoadMenu();
        }
    }
}
