using UnityEngine;
using TMPro;

public class TextDisplayer : MonoBehaviour
{
    public GameObject start;
    public GameObject countdown;
    public GameObject play;
    public GameObject pause;
    public GameObject lose;

    GameObject currentText;
    GameObject[] textObjects;
    public enum Texts {Start, CountDown, Play, Pause, Lose}

    void Start()
    {
        textObjects = new GameObject[] {start, countdown, play, pause, lose};
    }

    public void DisplayText(Texts text, int score = 0)
    {
        currentText = Instantiate(textObjects[(int) text]);
        if (text == Texts.CountDown)
        {
            currentText.GetComponent<CountDownText>().StartCoroutine("CountDown");
        }
        if (text == Texts.Lose)
        {
            currentText.GetComponent<TextMeshPro>().text = "Your Score:" + score.ToString();
        }
    }

    public void DeleteText()
    {
        Destroy(currentText);
    }
}
