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
    public void Playerdied() {
        EventManager.Invoke("OnPlayerDied", null, null);
    }
    public void PlayerKilled() {
        EventManager.Invoke("OnPlayerKilled", null, null);
    }
    public void PlayerGeht() {
        EventManager.Invoke("OnPlayerGehen", null, null);
    }
    public void Kaefersummt() {
        EventManager.Invoke("OnKaeferSummen", null, null);
    }
    public void PlayerJump() {
        EventManager.Invoke("OnPlayerJump", null, null);
    }
    public void Win() {
        EventManager.Invoke("OnWin", null, null);
    }
}
