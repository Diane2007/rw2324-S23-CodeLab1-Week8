using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EggManager : MonoBehaviour
{
    //number of eggs in inventory and in pot
    int invEggNum, potEggNum, iceEggNum;
    
    //init the text
    public TextMeshProUGUI invEggText, potEggText, iceEggText;
    public TextMeshProUGUI displayText, underText, softText, mediumText, hardText, overText;
    
    //init buttons
    public Button boilEggButton, takeEggButton;
    
    //connect with script
    public TimerTestScript timerScript;

    //public Text inputNum;
    //int playerInputNum;
    
    //create a dictionary to hold the egg and their state
    Dictionary<string, int> eggsBoiled = new Dictionary<string, int>();

    public static EggManager instance;
    void Awake()
    {
        if (!instance)
        {
            DontDestroyOnLoad(gameObject);
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    
    public void BoilEgg()                       //boil egg
    {
        timerScript.isBoiling = true;       //starts boiling  egg

        //egg number in inventory decreases
        InvEggNum -= 6;
        //egg number in pot increases
        PotEggNum += 6;
        
        //Debug.Log("isBoiling? " + timerScript.isBoiling);
    }

    public void TakeEgg()                       //take egg out of the pot
    {
        PotEggNum--;        //egg number in pot decreases
        IceEggNum++;        //egg number in ice bath increases
        //Debug.Log("In inventory: " + EggManager.instance.InvEggNum + 
        //          "\n" + "In put: " + EggManager.instance.PotEggNum);
        
        //determine the egg's boil state when taking out
        
        //UNDERCOOKED: BoilingTime < softBoilBottom time
        if (timerScript.BoilingTime < timerScript.softBoilBottom)
        {
            BoiledEggs("UNDERCOOKED", 1);
            underText.text = "Undercooked eggs: " + eggsBoiled["UNDERCOOKED"];
        }
        //SOFT-BOILED: softBoilBottom < BoilingTime < softBoilMax
        if (timerScript.BoilingTime > timerScript.softBoilBottom && timerScript.BoilingTime < timerScript.softBoilMax)
        {
            BoiledEggs("SOFT-BOILED", 1);
            softText.text = "Soft-boiled eggs: " + eggsBoiled["SOFT-BOILED"];
        }
        //MEDIUM: softBoilMax < BoilingTime < mediumBoilMax
        if (timerScript.BoilingTime > timerScript.softBoilMax && timerScript.BoilingTime < timerScript.mediumBoilMax)
        {
            BoiledEggs("MEDIUM", 1);
            mediumText.text = "Medium eggs: " + eggsBoiled["MEDIUM"];
        }
        //HARD: mediumBoilMax < BoilingTime < hardBoilMax
        if (timerScript.BoilingTime > timerScript.mediumBoilMax && timerScript.BoilingTime < timerScript.hardBoilMax)
        {
            BoiledEggs("HARD-BOILED", 1);
            hardText.text = "Hard-boiled eggs: " + eggsBoiled["HARD-BOILED"];
        }
        //OVERCOOKED: BoilingTime > hardBoilMax
        if (timerScript.BoilingTime > timerScript.hardBoilMax)
        {
            BoiledEggs("OVERCOOKED", 1);
            overText.text = "Overcooked eggs: " + eggsBoiled["OVERCOOKED"];
        }
        
        //if there are no eggs in the pot
        if(PotEggNum == 0)
        {
            timerScript.isBoiling = false;      //stop boiling
            Debug.Log("BoilingTime: " + timerScript.BoilingTime);
            timerScript.BoilingTime = 0f;
            if (invEggNum > 0)
            {
                boilEggButton.interactable = true;
            }
        }
        
        //Debug.Log("isBoiling? " + timerScript.isBoiling);

        //somehow this doesn't display as intended?
        //display eggType and value
        // foreach (KeyValuePair<string, int> boiledEgg in eggsBoiled)
        // {
        //     Debug.Log("You have: " + boiledEgg.Value + " " + boiledEgg.Key);
        //     
        //     //display string as its key code
        //     displayText.text += "\n" + boiledEgg.Key + " (" + eggsBoiled[boiledEgg.Key]  + ")";
        // }
        
    }
    
    public int InvEggNum
    {
        get { return invEggNum; }
        set
        {
            invEggNum = value;
            invEggText.text = "You have: " + invEggNum + " eggs";

            if (invEggNum <= 0 || timerScript.isBoiling)    //if there is no egg in inventory or is boiling
            {
                boilEggButton.interactable = false;         //cannot boil more eggs
            }
            else
            {
                boilEggButton.interactable = true;
            }
        }
    }

    public int PotEggNum
    {
        get { return potEggNum; }
        set
        {
            potEggNum = value;
            potEggText.text = "Boiling: " + potEggNum + " eggs";

            if (potEggNum <= 0)                             //if there is no egg in pot
            {
                takeEggButton.interactable = false;         //cannot take more eggs
                
            }
            else
            {
                takeEggButton.interactable = true;
            }
        }
    }

    public int IceEggNum
    {
        get { return iceEggNum; }
        set
        {
            iceEggNum = value;
            iceEggText.text = "In ice bath: " + iceEggNum + " eggs";
        }
    }

    void Start()
    {
        //player starts game with 12 eggs
        invEggNum = 12;
        //display all the egg numbers
        invEggText.text = "You have: " + InvEggNum + " eggs";
        potEggText.text = "Boiling: " + PotEggNum + " eggs";
        iceEggText.text = "In ice bath: " + IceEggNum + " eggs";
        
        //give TimerTestScript's BoilingTime a variable to hold
        
    }

    //determines the egg's finished state
    void BoiledEggs(string eggType, int amountToAdd)
    {
        //if we already have that type of egg
        if (eggsBoiled.ContainsKey(eggType))
        {
            eggsBoiled[eggType] += amountToAdd;     //just increase that type's amount
        }
        else
        {
            //if we don't have that type of egg, add that type and the number to the dictionary
            eggsBoiled.Add(eggType, amountToAdd);
        }
    }
    
}
