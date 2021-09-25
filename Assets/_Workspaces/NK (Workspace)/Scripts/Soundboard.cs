using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soundboard : MonoBehaviour
{
    public AudioClip hintergrundSound_Kueken;
    public AudioClip verzweifelt_Pipsen;
    public AudioClip kueken_WinSound;
    public AudioClip kaeferSummen;
    public AudioClip springen;
    public AudioClip froehliches_Pipsen;


    // Start is called before the first frame update
    void Start()
    {
        AudioSource audio = GetComponent<AudioSource>();

        audio.clip = hintergrundSound_Kueken;
        audio.Play();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void SoundSterben()
    {
        AudioSource audio = GetComponent<AudioSource>();

        audio.clip = verzweifelt_Pipsen;
        audio.PlayOneShot(verzweifelt_Pipsen, 1);
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

        audio.clip = froehliches_Pipsen;
        audio.PlayOneShot(froehliches_Pipsen, 1);
    }

}
