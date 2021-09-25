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
        /*
        if (Input.GetKeyDown(KeyCode.Q)) {
            EventManager.Invoke("OnPlayerDied", null, null);
        }
        if (Input.GetKeyDown(KeyCode.K)) {
            EventManager.Invoke("OnPlayerKilled", null, null);
        }
        if (Input.GetKeyDown(KeyCode.E)){
            EventManager.Invoke("OnPlayerGehen", null, null);
        }
        if (Input.GetKeyDown(KeyCode.L)) {
            EventManager.Invoke("OnPlayerJump", null, null);
        }
        if (Input.GetKeyDown(KeyCode.O)) {
            EventManager.Invoke("OnKaeferSummen", null, null);
        }
        if (Input.GetKeyDown(KeyCode.M)) {
            EventManager.Invoke("OnWin", null, null);
        }*/
    }
}
