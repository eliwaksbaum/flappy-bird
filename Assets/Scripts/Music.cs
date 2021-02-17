using UnityEngine;

public class Music : MonoBehaviour
{
    public Sprite[] sprites;
    public BoolValue muted;
    
    AudioSource music;
    SpriteRenderer sr;
    int swap = 1;

    void Start()
    {
        music = GetComponent<AudioSource>();
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (muted.Value && !music.mute)
        {
            MuteMusic();
        }
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
}