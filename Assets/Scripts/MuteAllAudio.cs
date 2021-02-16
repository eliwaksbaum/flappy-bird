using UnityEngine;

public class MuteAllAudio : MonoBehaviour
{
    AudioSource[] players;

    void OnEnable()
    {
        Mute.MuteEvent += MuteAll;
    }

    void OnDisable()
    {
        Mute.MuteEvent -= MuteAll;
    }

    void Start()
    {
        players = GetComponents<AudioSource>();
    }

    void MuteAll(bool on)
    {
        foreach (AudioSource player in players)
        {
            player.mute = on;
        }
    }
}