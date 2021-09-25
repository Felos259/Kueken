using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soundboard : MonoBehaviour
{
    public AudioClip hintergrundSound;
    public AudioClip sterben;
    public AudioClip kueken_WinSound;
    public AudioClip kaeferSummen;
    public AudioClip springen;
    public AudioClip toeten;
    public AudioClip gehen;
    private bool j = true;

    // Start is called before the first frame update
    void Start()
    {
        AudioSource audio = GetComponent<AudioSource>();

        audio.clip = hintergrundSound;
        audio.Play();
        beleben();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void SoundSterben()
    {
        if (j == true) {
            AudioSource audio = GetComponent<AudioSource>();

            audio.clip = sterben;
            audio.PlayScheduled(audio.clip.length);
            j = false;
        }
    }
    public void beleben() {
        if (j == false) {
            j = true;
        }
    }
    public void SoundGewinnen()
    {
        AudioSource audio = GetComponent<AudioSource>();

        audio.clip = kueken_WinSound;
        audio.Play();
    }
    public void SoundKaefer()
    {
        AudioSource audio = GetComponent<AudioSource>();

        audio.clip = kaeferSummen;
        audio.Play();
    }
    public void SoundSpringen()
    {
        AudioSource audio = GetComponent<AudioSource>();

        audio.clip = springen;
        audio.PlayOneShot(springen, 1);
    }
    public void SoundToeten()
    {
        AudioSource audio = GetComponent<AudioSource>();

        audio.clip = toeten;
        audio.PlayOneShot(toeten, 1);
    }
    public void SoundGehen() {
        AudioSource audio = GetComponent<AudioSource>();

        audio.clip = gehen;
        audio.PlayOneShot(gehen, 1);
    }

}
