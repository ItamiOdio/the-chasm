using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD_controller : MonoBehaviour
{

    public Image[] Health;
    public Text scoreText;

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < Health.Length; i++)
        {
            if(i < PlayerStats.hp)
            {
                Health[i].gameObject.SetActive(true);
            }
            else
            {
                Health[i].gameObject.SetActive(false);
            }
        }
        scoreText.text = ManageScore.lanternsAlight.ToString() + "/" + ManageScore.lanternsInScene.ToString();

    }

}
