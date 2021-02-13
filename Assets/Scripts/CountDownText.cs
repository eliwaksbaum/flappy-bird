using System.Collections;
using System;
using TMPro;
using UnityEngine;

public class CountDownText : MonoBehaviour
{
    TextMeshPro textMesh;
    public static event Action CountDone;

    public AudioClip countClip;
    public AudioClip playClip;

    AudioSource countSound;
    AudioSource playSound;

    void Awake()
    {
        textMesh = GetComponent<TextMeshPro>();
        countSound = AddAudio(countClip, 1);
        playSound = AddAudio(playClip, 1);
    }

    void Start()
    {
        //countSound = AddAudio(countClip, 1);
        //playSound = AddAudio(playClip, 1);
    }

    AudioSource AddAudio(AudioClip clip, float volume)
    {
        AudioSource audio = gameObject.AddComponent<AudioSource>();
        audio.clip = clip;
        audio.volume = volume;
        audio.playOnAwake = false;
        return audio;
    }

    IEnumerator CountDown()
    {
        textMesh.fontSize = 36f;
        for (int i = 3; i > 0; i--)
        {
            textMesh.text = i.ToString();
            countSound.Play();
            yield return new WaitForSeconds(.75f);
        }
        textMesh.text = "Play!";
        textMesh.fontSize = 16f;
        playSound.Play();
        yield return new WaitForSeconds(0.4f);
        CountDone();
    }
}
