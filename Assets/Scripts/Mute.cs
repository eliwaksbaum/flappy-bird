using UnityEngine;

public class Mute : MonoBehaviour
{
    public BoolValue muted;
    public Sprite[] sprites;

    SpriteRenderer sr;
    int swap = 1;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        muted.Value = false;
    }

    void OnMouseDown()
    {
        muted.Value = !muted.Value;

        sr.sprite = sprites[swap%2];
        swap += 1;
    }
}