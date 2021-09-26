using Nvp.Events;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject puppet;
    public GameObject trigger1;
    public GameObject trigger2;
    int j = 0;

    //Variablen für den Tod
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Summen();
        j++;
    }
    void Summen() {
        if (j == 120) {
            EventManager.Invoke("OnKaeferSummen", null, null);
        }
    }



}

