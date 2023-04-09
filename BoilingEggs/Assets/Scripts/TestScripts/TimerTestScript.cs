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
    float boilingTime = 0f;
    public TextMeshProUGUI timerText, boilTimerText;
    
    public bool isTiming = false;      //has the player's timer started
    public bool isBoiling = false;     //has the egg(s) start boiling
    
    //some time vars that determine if the water is boiling or not
    int waterSimmer, waterBoil;                 //for water boiling
    int softBoilBottom, softBoilMax, mediumBoilMax, hardBoilMax; //for eggs
    
    //init the var for getting the player's input number
    int playerInputNum;

    public void BoilEgg()                       //boil egg
    {
        isBoiling = true;       //starts boiling
        EggManager.instance.InvEggNum--;        //egg number in inventory decreases
        EggManager.instance.PotEggNum++;        //egg number in pot increases
        
        Debug.Log("isBoiling? " + isBoiling);
        //Debug.Log("In inventory: " + EggManager.instance.InvEggNum + 
        //          "\n" + "In put: " + EggManager.instance.PotEggNum);
    }

    public void TakeEgg()                       //take egg out of the pot
    {
        EggManager.instance.PotEggNum--;        //egg number in pot decreases
        EggManager.instance.IceEggNum++;        //egg number in ice bath increases
        //Debug.Log("In inventory: " + EggManager.instance.InvEggNum + 
        //          "\n" + "In put: " + EggManager.instance.PotEggNum);

        isBoiling = false;      //stop boiling
        Debug.Log("isBoiling? " + isBoiling);
    }


    void BoilTimer()
    {
        if (boilingTime > waterBoil)                       //when more than 20 sec, water is boiling
        {
            boilTimerText.text = "BOILING!!!";
        }
        if (boilingTime > waterSimmer && boilingTime < waterBoil)   //when more than 10 sec but less than 20, water is simmering
        {
            boilTimerText.text = "Simmering...";
        }
        if (boilingTime < waterSimmer)
        {
            boilTimerText.text = "Getting warm..."; //when less than 10 sec, water getting warmer
        }
        
    }

    void Timer()
    {
        //trying to recall grade school math to calculate minutes and seconds
        int minute = Mathf.FloorToInt(timer / 60f);
        int second = Mathf.FloorToInt(timer - minute * 60f);

        string minText = "00";
        string secText = "00";
        
        //count the digit minute and second has
        int minDig = Mathf.FloorToInt(Mathf.Log10(minute)) + 1;
        int secDig = Mathf.FloorToInt(Mathf.Log10(second)) + 1;
        Debug.Log("Time is: " + minute + ":" + second + "\n" +
                  "Minute digit is: " + minDig + "\n" +
                  "Second digit is: " + secDig);
        //if there is only one digit, add a zero in front of it for the 00:00 digital clock effect
        if (minDig > 1)
        {
            minText = "" + minute;
        }
        else
        {
            minText = "0" + minute;
        }

        if (secDig > 1)
        {
            secText = "" + second;
        }
        else
        {
            secText = "0" + second;
        }

        //display time
        timerText.text = minText + ":" + secText;

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

    //turning player's input number (string) into integer
    void ParseInput()
    {
        
    }

    void Start()
    {
        //we start with neither timer has started nor eggs are boiling
        isTiming = false;
        isBoiling = false;
        
        //def the timer vars
        waterSimmer = 10;
        waterBoil = 20;
        softBoilBottom = (200 / 5) + waterBoil;     //the bottom time to be considered soft-boiled
        softBoilMax = (215 / 5) + waterBoil;        //the max time to be considered soft-boiled
        mediumBoilMax = (240 / 5) + waterBoil;      //the max time to be considered medium
        hardBoilMax = (255 / 5) + waterBoil;        //the max time to be considered hard-boiled
    }

    void Update()
    {
        //if timer starts
        if (isTiming)
        {
            //the game is 5 times faster than real time
            timer += Time.deltaTime * 5;
            Timer();        //dont forget to display the text
        }
        
        //if boiling timer starts
        if (isBoiling)
        {
            //boiling time is real time
            boilingTime += Time.deltaTime;
            BoilTimer();    //start counting the boiling time
        }
    }
}
