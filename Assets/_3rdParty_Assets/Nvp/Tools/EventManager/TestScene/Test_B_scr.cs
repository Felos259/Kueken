using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Nvp.Events;
public class Test_B_scr : MonoBehaviour
{
   

    // Update is called once per frame
    void Update()
    {
        // Auslösen eines bestimmten Events, wobei der jeweilige Event
        // über eine Zeichenfolge bestimmt wird
        // (flexibler)
        if (Input.GetMouseButtonDown(0)){
            EventManager.Invoke("OnMouseLeftClick", this, null);
        }

        // Auslösen eines bestimmten Events, wobei der jeweilige Event
        // über eine Zeichenfolge bestimmt wird
        // (sicherer)
        if (Input.GetMouseButtonDown(1))
        {
            EventManager.Invoke(GameEvents.OnMouseRightClick, this, null);
        }
    }
}
