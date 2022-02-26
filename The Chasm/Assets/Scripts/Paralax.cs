using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paralax : MonoBehaviour
{
    public Transform cam;
    public float relativity;
    public bool lockY = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (lockY)
        {
            transform.position = new Vector2(cam.position.x * relativity, transform.position.y);
        }
        else
        {
            transform.position = new Vector2(cam.position.x * relativity, cam.position.y * relativity);
        }
        
    }
}
