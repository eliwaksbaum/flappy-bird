using UnityEngine;

public class Music : MonoBehaviour
{
    public Sprite[] sprites;
    
    AudioSource music;
    SpriteRenderer sr;
    int swap = 1;

    void OnEnable()
    {
        Mute.MuteEvent += AllMute;
    }

    void OnDisable()
    {
        Mute.MuteEvent -= AllMute;
    }

    void Start()
    {
        music = GetComponent<AudioSource>();
        sr = GetComponent<SpriteRenderer>();
    }

    void MuteMusic()
    {
        music.mute = !music.mute;
        sr.sprite = sprites[swap%2];
        swap += 1;
    }

    void OnMouseDown()
    {
        MuteMusic();
    }

    void AllMute(bool on)
    {
        if (on && !music.mute)
        {
            MuteMusic();
        }
    }
}