using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Nvp.Events;
using System;

public class AudioManager : MonoBehaviour
{
    public AudioSource backgroundMusic;
    public AudioSource sterbenSFX;
    public AudioSource springenSFX;
    public AudioSource gehenSFX;
    public AudioSource kaeferSummen;
    public AudioSource winSFX;
    public AudioSource toetenSFX;

    public void OnEnable()
    {
        EventManager.AddEventListener("OnGameStarted", OnGameStarted);
        EventManager.AddEventListener("OnPlayerDied", OnPlayerDied);
        EventManager.AddEventListener("OnPlayerJump",OnPlayerJump);
        EventManager.AddEventListener("OnPlayerKilled", OnPlayerKilled);
        EventManager.AddEventListener("OnKaeferSummen", OnKaeferSummen);
        EventManager.AddEventListener("OnWin",OnWin);
        EventManager.AddEventListener("OnPlayerGehen", OnPlayerGehen);
        EventManager.AddEventListener("OnPlayerStay", OnPlayerStay);
    }

    public void OnDisable()
    {
        EventManager.RemoveEventListener("OnGameStarted", OnGameStarted);
        EventManager.RemoveEventListener("OnPlayerDied", OnPlayerDied);
        EventManager.RemoveEventListener("OnPlayerJump", OnPlayerJump);
        EventManager.RemoveEventListener("OnPlayerKilled", OnPlayerKilled);
        EventManager.RemoveEventListener("OnKaeferSummen", OnKaeferSummen);
        EventManager.RemoveEventListener("OnWin", OnWin);
        EventManager.RemoveEventListener("OnPlayerGehen", OnPlayerGehen);
        EventManager.RemoveEventListener("OnPlayerStay", OnPlayerStay);
    }

    private void OnPlayerStay(object sender, object eventArgs)
    {
        gehenSFX.Stop();
    }

    private void OnPlayerDied(object sender, object eventArgs)
    {
            sterbenSFX.Play();
    }

    private void OnGameStarted(object sender, object eventArgs)
    {
        backgroundMusic.Play();
    }
    private void OnPlayerJump(object sender, object eventArgs)
    {
        gehenSFX.Stop();
        springenSFX.Play();
    }
    private void OnPlayerKilled(object sender, object eventArgs)
    {
        Debug.Log("PlayerKilled");
        toetenSFX.PlayOneShot(toetenSFX.clip);
    }
    private void OnKaeferSummen(object sender, object eventArgs)
    {
        kaeferSummen.Play();
    }
    private void OnWin(object sender, object eventArgs)
    {
        winSFX.Play();
    }
    private void OnPlayerGehen(object sender, object eventArgs)
    {
        gehenSFX.Play();
    }
}
