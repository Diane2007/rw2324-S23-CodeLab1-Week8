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
    //init buttons
    public Button boilEggButton, takeEggButton;
    
    //connect with script and input field
    public TimerTestScript timerScript;
    public TextMeshProUGUI inputNum;
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

    public int InvEggNum
    {
        get { return invEggNum; }
        set
        {
            invEggNum = value;
            invEggText.text = "Eggs in inventory: " + invEggNum;

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
            potEggText.text = "Eggs in pot: " + potEggNum;

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

    // void ParseInput()
    // {
    //     //parse the player input number, which is a string, into integer
    //     playerInputNum = int.Parse(inputNum.text);
    // }

    public int IceEggNum
    {
        get { return iceEggNum; }
        set
        {
            iceEggNum = value;
            iceEggText.text = "Eggs in ice: " + iceEggNum;
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
    }

    //determines the egg's finished state
    public void BoiledEggs(string eggType, int amountToAdd)
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
