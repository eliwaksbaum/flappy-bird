using System;
using UnityEngine;

public class PipePair : MonoBehaviour
{
    public float speed;
    public bool inPlay;

    new SpriteRenderer renderer;
    float halfWidth;

    public static event Action<PipePair> PipeDead;

    void Start()
    {
        inPlay = true;
        renderer = GetComponentInChildren<SpriteRenderer>();
        halfWidth = renderer.bounds.extents.x;
    }

    void Update()
    {
        if (inPlay)
        {
            transform.Translate(new Vector3(-speed, 0, 0) * Time.deltaTime);
        }
        
        if (transform.position.x < -1.25)
        {
            PipeDead(this);
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "bird")
        {
            Bird bird = collision.gameObject.GetComponent<Bird>();
            bird.Hit();
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "bird")
        {
            if (other.transform.position.x > transform.position.x + halfWidth)
            {
                Bird bird = other.GetComponent<Bird>();
                bird.UpScore();
            }
        }
    }
}