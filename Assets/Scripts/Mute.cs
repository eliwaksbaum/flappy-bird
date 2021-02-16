using UnityEngine;
using System;

public class Mute : MonoBehaviour
{
    public static event Action<bool> MuteEvent;
    public Sprite[] sprites;

    bool on = false;
    SpriteRenderer sr;
    int swap = 1;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    void OnMouseDown()
    {
        Debug.Log("mute");
        MuteEvent(!on);
        on = !on;

        sr.sprite = sprites[swap%2];
        swap += 1;
    }
}