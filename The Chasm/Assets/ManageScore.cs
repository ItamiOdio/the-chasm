using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManageScore : MonoBehaviour
{
    public static int lanternsAlight;
    public static int lanternsInScene;

    private void OnEnable()
    {
        lanternsAlight = 0;       
    }

    private void Update()
    {
        lanternsInScene = GameObject.FindGameObjectsWithTag("Lantern").Length;
    }



}
