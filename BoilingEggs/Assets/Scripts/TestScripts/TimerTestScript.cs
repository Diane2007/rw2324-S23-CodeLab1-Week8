using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
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
        
        //count the digit minute and second has
        //if there is only one digit, add a zero in front of it for the 00:00 digital clock effect
        //that is, if they are bigger than 0 for mathematical reasons
        int minDig = Mathf.FloorToInt(Mathf.Log10(minute)) + 1;
        int secDig = Mathf.FloorToInt(Mathf.Log10(second)) + 1;
        Debug.Log("Time is: " + minute + ":" + second + "\n" +
                  "Minute digit is: " + minDig + "\n" +
                  "Second digit is: " + secDig);


        /*
        //if minute and second only have one digit, add a zero in front
        if (minute / 10 > 1 && second / 10 > 1)         //both two digits
        {
            timerText.text = "" + minute + ":" + "" + second;
        }
        if (minute / 10 > 1 && second / 10 < 1)         //minute has two digits but second has one
        {
            timerText.text = "" + minute + ":0" + "" + second;  //add a 0 before second
        }
        if (minute / 10 < 1 && second / 10 > 1)         //minute has one digit but second has two
        {
            timerText.text = "0" + "" + minute + ":" + "" + second; //add a 0 before minute
        }
        if (minute / 10 < 1 && second / 10 < 1) //both one digit
        {
            timerText.text = "0" + "" + minute + ":0" + "" + second;    //add 0 before both second and minute
        }
        */
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
