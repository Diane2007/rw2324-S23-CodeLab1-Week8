using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropEggScript : MonoBehaviour
{
    public GameObject oneEgg;   //the egg prefab
    GameObject egg;             //the spawned egg
    
    //init mouse position
    Vector3 mousePos;
    
    //when clicked on egg button
    public void TakeEgg()
    {
        //if there are no eggs already instantiated
        if (!egg)
        {
            //get current mouse position
            mousePos = GetMousePosition();
            Debug.Log("mouse position: " + mousePos);
            
            //instantiate an egg that player can drag
            egg = Instantiate(oneEgg, mousePos, Quaternion.identity);
            Debug.Log("Egg button clicked!"); 
            
            //decrease inventory egg num
            GameManager.instance.InvEggNum--;
            
        }
    }

    //then when player releases mouse over the pot
    //the instantiated egg disappears
    //and the number of eggs in pot increases

    void Update()
    {
        //mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    Vector3 GetMousePosition()
    {
        Vector3 mousePos = Input.mousePosition;
        return Camera.main.ScreenToWorldPoint(mousePos);
    }

}
