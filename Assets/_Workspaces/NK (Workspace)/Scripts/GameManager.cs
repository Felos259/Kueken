using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Nvp.Events;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        EventManager.Invoke("OnGameStarted", null, null);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("space Gedrueckt");
            
        }
        if (Input.GetKeyDown(KeyCode.Q)) {
            EventManager.Invoke("OnPlayerDied", null, null);
        }
    }
}
