using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStats : MonoBehaviour
{
    public static int hp;
    public static int points=0;
    public int lanternsLit;

    public static bool isImmune = false;
    public LevelLoader loader;
    float immuneTime = 2f;
    float timer;

    void Start()
    {
        timer = 0;
        hp = 5;
    }

    private void Update()
    {
        if (isImmune)
        {
            if(timer <= immuneTime)
            {
                timer += Time.deltaTime;
            }
            else
            {
                isImmune = false;
            }
        }

        if (hp <= 0)
        {
            loader.StartOver();
        }
    }

    public static void UpdatePoints(int newPoints)
    {
        points += newPoints;
    }

    public void addLight()
    {
        lanternsLit += 1;
    }

}
