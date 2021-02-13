using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroller : MonoBehaviour
{
    public float scrollSpeed;
    public float resetPoint; 
    public bool inPlay; 

    void Start()
    {
        inPlay = true;
    }

    void Update()
    {
        if (inPlay)
        {
            if (transform.position.x < resetPoint)
            {
                transform.position = new Vector3(0, transform.position.y, 0);
            }
            else
            {
                transform.Translate(new Vector3(-scrollSpeed, 0, 0) * Time.deltaTime);
            }
        }
    }
}
