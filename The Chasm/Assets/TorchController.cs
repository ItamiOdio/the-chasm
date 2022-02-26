using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TorchController : MonoBehaviour
{
    public Animator torchAnimator;
    
    float lightTime;
    float counter;
    void Start()
       
    {
        gameObject.transform.GetChild(0).gameObject.SetActive(false);
        gameObject.transform.GetChild(1).gameObject.SetActive(false);
        lightTime = SceneManager.GetActiveScene().buildIndex * 10 + 30;

    }

    void Update()
    {
        if (gameObject.transform.GetChild(0).gameObject.activeInHierarchy)
        {
            counter += Time.deltaTime;
        }

        if (counter >= lightTime)
        {
            counter = 0;
            gameObject.transform.GetChild(1).gameObject.SetActive(false);
            StartCoroutine(FadeOutTorch());
            ManageScore.lanternsAlight--;

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(!gameObject.transform.GetChild(0).gameObject.activeInHierarchy)
        {
            gameObject.transform.GetChild(1).gameObject.SetActive(true);
            gameObject.transform.GetChild(0).gameObject.SetActive(true);
            torchAnimator.SetTrigger("FadeInLight");
            ManageScore.lanternsAlight++;
           
        }
        
    }


    IEnumerator FadeOutTorch()
    {
        torchAnimator.SetTrigger("FadeOutLight");
        yield return new WaitForSeconds(1);
        gameObject.transform.GetChild(0).gameObject.SetActive(false);
    }

}
