using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitForResume : CustomYieldInstruction
{
    float startTime;
    float waitTime;
    bool paused;

    public WaitForResume(float wait)
    {
        startTime = Time.time;
        waitTime = wait;
        paused = false;
    }

    public override bool keepWaiting
    {
        get
        {
            if (Input.GetButtonDown("Pause"))
            {
                paused = !paused;
            }
            if (paused)
            {
                startTime += Time.deltaTime;
            }

            return (Time.time - startTime) < waitTime;
        }
    }
}
