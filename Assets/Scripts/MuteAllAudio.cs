using UnityEngine;

public class MuteAllAudio : MonoBehaviour
{
    public BoolValue muted;

    AudioSource[] players;
    bool status;

    void Start()
    {
        players = GetComponents<AudioSource>();
    }

    void Update()
    {
        if (status != muted.Value)
        {
            MuteAll(muted.Value);
            status = muted.Value;
        }
    }

    void MuteAll(bool on)
    {
        foreach (AudioSource player in players)
        {
            player.mute = on;
        }
    }
}