using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class GameManager : MonoBehaviour
{
    //make this script a singleton
    public static GameManager instance;
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

    //how many eggs the player has right now, default start with 6
    int invEggNum = 6;
    //how many eggs are in the pot right now, default start with 0
    int potEggNum = 0;
    
    //init the eggNum text so we can display on screen later
    public TextMeshProUGUI eggInvNumText, eggPotNumText;
    
    //make the number of eggs in inventory a property
    public int InvEggNum
    {
        get { return invEggNum; }
        set
        {
            invEggNum = value;
            //show the inventory egg number on big egg
            eggInvNumText.text = "" + invEggNum;
        }
    }
    //make the number of eggs in pot a property
    public int PotEggNum
    {
        get { return potEggNum; }
        set
        {
            potEggNum = value;
            //show the pot egg number on pot
            eggPotNumText.text = "" + potEggNum;
        }
    }

    void Start()
    {
        //show the starting number of eggs in inventory and in pot
        eggInvNumText.text = "" + InvEggNum;
        eggPotNumText.text = "" + PotEggNum;


    }
}
