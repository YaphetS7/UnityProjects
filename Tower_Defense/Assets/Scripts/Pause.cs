using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{

    private bool paused;


	void Start ()
    {
        paused = false;
	}
	
	
	void Update ()
    {
		if(Input.GetKeyDown(KeyCode.Escape))
        {
            if (!paused)
            {
                paused = true;
                Time.timeScale = 0;
            }
            else
            {
                paused = false;
                Time.timeScale = 1;
            }
        }
	}
}
