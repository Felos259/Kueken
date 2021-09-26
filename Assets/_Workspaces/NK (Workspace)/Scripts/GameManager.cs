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
        Playerdied();
        PlayerGeht();
        PlayerJump();
        PlayerKilled();


    }
    void Playerdied() {
        EventManager.Invoke("OnPlayerDied", null, null);
    }
    void PlayerKilled() {
        EventManager.Invoke("OnPlayerKilled", null, null);
    }
    void PlayerGeht() {
        EventManager.Invoke("OnPlayerGehen", null, null);
    }
    void Kaefersummt() {
        EventManager.Invoke("OnKaeferSummen", null, null);
    }
    void PlayerJump() {
        EventManager.Invoke("OnPlayerJump", null, null);
    }
    void Win() {
        EventManager.Invoke("OnWin", null, null);
    }
}
