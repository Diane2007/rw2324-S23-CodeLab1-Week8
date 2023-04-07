using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EggManager : MonoBehaviour
{
    //number of eggs in inventory and in pot
    int invEggNum;
    int potEggNum;
    
    //init the text
    public TextMeshProUGUI invEggText, potEggText;

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
        }
    }

    public int PotEggNum
    {
        get { return potEggNum; }
        set
        {
            potEggNum = value;
            potEggText.text = "Eggs in pot: " + potEggNum;
        }
    }

    void Start()
    {
        //player starts game with 12 eggs
        invEggNum = 12;
        //display all the egg numbers
        invEggText.text = "You have: " + InvEggNum + " eggs";
        potEggText.text = "Boiling: " + PotEggNum + " eggs";

    }
}
