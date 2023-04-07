using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropEggScript : MonoBehaviour
{
    public GameObject oneEgg;   //the egg prefab
    GameObject egg;             //the spawned egg
    
    //init mouse position
    public Vector3 mousePos;
    
    //when clicked on the big egg drawing
    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //if there are no eggs being instantiated
            if (!egg)
            {
                //instantiate a normal size egg that player can drag
                egg = Instantiate<GameObject>(oneEgg, mousePos, Quaternion.identity);    //no rotation
                oneEgg.transform.position = Input.mousePosition;
                Debug.Log("Clicked on egg!");
                
                //decrease inventory egg number and increase pot egg number
                GameManager.instance.InvEggNum--;
                GameManager.instance.PotEggNum++;
            }
        }
    }

    //then when player releases mouse over the pot
    //the instantiated egg disappears
    //and the number of eggs in pot increases

    void Update()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

}
