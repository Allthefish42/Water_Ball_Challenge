using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Timer : MonoBehaviour
{ 
    float timer = 0.0f;
    int timeRemaining = 10;
    public GameObject Time_Out_Window;

    void Update()
    {
        timer += Time.deltaTime;
        int seconds = (int)timer % 60;
        if (seconds > 0)
        {
            timer = 0;
           UpdateTimer();
        }  
        }

    private void UpdateTimer()
{
        gameObject.GetComponent<Text>().text = $"{timeRemaining}";
        timeRemaining -= 1;
        if(timeRemaining <= -1)
        {
            timeRemaining = 0;
            Time_Out_Window.SetActive(true);
        }
    }

}




  

    
