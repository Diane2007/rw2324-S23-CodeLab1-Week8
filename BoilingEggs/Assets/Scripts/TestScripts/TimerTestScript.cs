using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimerTestScript : MonoBehaviour
{
    //init timer and timer text
    float timer = 0f;
    public TextMeshProUGUI timerText;
    bool isTiming = false;
    
    public void BoilEgg()
    {
        EggManager.instance.InvEggNum--;
        EggManager.instance.PotEggNum++;
        Debug.Log("In inventory: " + EggManager.instance.InvEggNum + 
                  "\n" + "In put: " + EggManager.instance.PotEggNum);
    }

    public void TakeEgg()
    {
        EggManager.instance.PotEggNum--;
        Debug.Log("In inventory: " + EggManager.instance.InvEggNum + 
                  "\n" + "In put: " + EggManager.instance.PotEggNum);
    }

    void Timer()
    {
        //trying to recall grade school math to calculate minutes and seconds
        int minute = Mathf.FloorToInt(timer / 60f);
        int second = Mathf.FloorToInt(timer - minute * 60f);
        
        
        timerText.text = "" + minute + ":" + "" + second;
        //Debug.Log("" + minute + ":" + "" + second);
    }

    //when clicking on start timer button, start timing
    public void StartTimer()
    {
        isTiming = true;
    }
    
    //when clicking on stop timer button, stop timing
    public void StopTimer()
    {
        isTiming = false;
        timer = 0f;     //reset timer to 0
        timerText.text = "00:00";
    }

    void Update()
    {
        //if timer starts
        if (isTiming)
        {
            //the game is 5 times faster than real time
            timer += Time.deltaTime * 5;
            Timer();    //dont forget to display the text
        }
    }
}
