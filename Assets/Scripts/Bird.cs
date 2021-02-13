using System;
using UnityEngine;
using TMPro;

public class Bird : MonoBehaviour
{
    public float jumpForce;
    public TextMeshPro scoreText;
    public AudioClip jumpClip;
    public AudioClip hitCliip1;
    public AudioClip hitClip2;
    public AudioClip scoreClip;

    AudioSource jumpSound;
    AudioSource hitSound1;
    AudioSource hitSound2;
    AudioSource scoreSound;

    Rigidbody2D rb;
    new Collider2D collider;
    public bool jumpPressed;

    public int score {get; set;}

    public static event Action OnHit;

    AudioSource AddAudio(AudioClip clip, float volume)
    {
        AudioSource audio = gameObject.AddComponent<AudioSource>();
        audio.clip = clip;
        audio.volume = volume;
        audio.playOnAwake = false;
        return audio;
    }

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        collider = GetComponent<Collider2D>();
    }

    void Start()
    {
        jumpSound = AddAudio(jumpClip, .4f);
        hitSound1 = AddAudio(hitCliip1, .6f);
        hitSound2 = AddAudio(hitClip2, .6f);
        scoreSound = AddAudio(scoreClip, 1);
    }

    void FixedUpdate()
    {
        if (jumpPressed)
        {
            rb.AddForce(new Vector2(0, jumpForce));
            jumpPressed = false;
            jumpSound.Play();
        }
    }

    public void UpScore()
    {
        score += 1;
        scoreText.text = "Score:" + score.ToString();
        scoreSound.Play();
    }

    public void SetFalling(bool falling)
    {
        rb.simulated = falling;
    }

    public void SetHitting(bool hitting)
    {
        collider.enabled = hitting;
    }

    public void Hit()
    {
        OnHit();
        SetHitting(false);
        rb.AddForce(new Vector2(0, 300));
        hitSound1.Play();
        hitSound2.Play();
    }

    public Bird Reset()
    {
       Bird bird = Instantiate(this, new Vector3(transform.position.x, -4.8f, 0), Quaternion.identity);
       bird.SetHitting(true);
       bird.SetFalling(false);
       bird.score = score;
       bird.gameObject.SetActive(false);
       return bird;
    }

    public void Clear()
    {
        Destroy(gameObject);
    }
}
