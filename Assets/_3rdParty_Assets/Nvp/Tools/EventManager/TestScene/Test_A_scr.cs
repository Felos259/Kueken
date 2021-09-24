using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Nvp.Events;


public class Test_A_scr : MonoBehaviour
{
    
    void OnEnable(){
        // Events abonieren, um bei Events benachrichtigt zu werden
        EventManager.AddEventListener("OnMouseLeftClick", OnMouseLeftClick);
        EventManager.AddEventListener(GameEvents.OnMouseRightClick, OnMouseRightClick);
    }

    void OnDisable(){
        // Events abbestellen, um bei Events nicht mehr benachrichtigt zu werden
        EventManager.RemoveEventListener("OnMouseLeftClick", OnMouseLeftClick);
        EventManager.RemoveEventListener(GameEvents.OnMouseRightClick, OnMouseRightClick);
    }


    // Methode, die aufgerufen wird, wenn der Event ausgelöst wird
    void OnMouseLeftClick(object sender, object eventArgs){
        Debug.Log("OnMouseLeftClick called");
    }

    // Methode, die aufgerufen wird, wenn der Event ausgelöst wird
    void OnMouseRightClick(object sender, object eventArgs){
        Debug.Log("OnMouseRightClick called");
    }
}
