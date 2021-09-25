using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Nvp.Events;
using System;

public class AudioManager : MonoBehaviour
{
    public AudioSource backgroundMusic;
    public AudioSource sterbenSFX;

    public void OnEnable()
    {
        EventManager.AddEventListener("OnGameStarted", OnGameStarted);
        EventManager.AddEventListener("OnPlayerDied", OnPlayerDied);
    }

    public void OnDisable()
    {
        EventManager.RemoveEventListener("OnGameStarted", OnGameStarted);
        EventManager.RemoveEventListener("OnPlayerDied", OnPlayerDied);
    }

    private void OnPlayerDied(object sender, object eventArgs)
    {
        sterbenSFX.Play();
    }

    private void OnGameStarted(object sender, object eventArgs)
    {
        backgroundMusic.Play();
    }

}
