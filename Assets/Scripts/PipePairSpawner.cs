using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipePairSpawner : MonoBehaviour
{
    public GameObject pipePrefab;
    public float minTime;
    public float maxTime;
    public float minHeight;
    public float maxHeight;
    public float heightDifPerSecond;

    public bool paused;
    
    List<PipePair> pipes = new List<PipePair>();

    void Start()
    {
        paused = false;
    }

    void OnEnable()
    {
        PipePair.PipeDead += RemovePipe;
    }

    void OnDisable()
    {
        PipePair.PipeDead -= RemovePipe;
    }

    IEnumerator spawn()
    {
        float lastWait = 0f;
        float lastHeight = -6f;
        while (true)
        {
            float wait = Random.Range(minTime, maxTime);
            float rawHeight = Random.Range(lastHeight - (lastWait * heightDifPerSecond), lastHeight + (lastWait * heightDifPerSecond));
            float height = Mathf.Clamp(rawHeight, minHeight, maxHeight);

            GameObject pipe = Instantiate(pipePrefab, new Vector3(19, height, 0), Quaternion.identity);
            pipes.Add(pipe.GetComponent<PipePair>());

            lastWait = wait;
            lastHeight = height;
            yield return new WaitForResume(wait);
        }
    }

    void RemovePipe(PipePair pipe)
    {
        pipes.Remove(pipe);
    }

    public void SetPipes(bool set)
    {
        foreach (PipePair pipe in pipes)
        {
            pipe.inPlay = set;
        }
    }

    public void ClearPipes()
    {
        foreach (PipePair pipe in pipes)
        {
            Destroy(pipe.gameObject);
        }
        pipes.Clear();
    }
}
