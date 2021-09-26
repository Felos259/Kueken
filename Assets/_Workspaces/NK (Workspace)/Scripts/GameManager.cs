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


    }
    public void Playerdied() {
        EventManager.Invoke("OnPlayerDied", null, null);
    }
    public void PlayerKilled() {
        EventManager.Invoke("OnPlayerKilled", null, null);
    }
    public void PlayerGeht() {
        
        
    }
    public void Kaefersummt() {
        
    }
    public void PlayerJump() {
        
    }
    public void Win() {
        EventManager.Invoke("OnWin", null, null);
    }
}
