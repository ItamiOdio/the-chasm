using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public Animator transition;
   
    public void StartOver()
    {
        StartCoroutine(LoadLevel(1));
        PlayerStats.hp = 5;
    }

    public void LoadMenu()
    {
        StartCoroutine(LoadLevel(0));
    }

    public void LoadNextScene()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }

    IEnumerator LoadLevel(int index)
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(3);
        SceneManager.LoadSceneAsync(index);
    }
}
