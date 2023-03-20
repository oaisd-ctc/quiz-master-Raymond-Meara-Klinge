using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField]
    float questionTime = 5f;

    [SerializeField]
    float answerTime = 3f;

    public bool loadNext;

    public bool answering = false;

    public float fillFrac;

    float timerVal;

    void Update()
    {
        TimerUpdate();
    }

    public void CancelTime()
    {
        timerVal = 0;
    }

    void TimerUpdate()
    {
        timerVal -= Time.deltaTime;

        if (answering == true)
        {
            if (timerVal > 0)
            {
                fillFrac = timerVal / questionTime;
            }
            else
            {
                answering = false;
                timerVal = answerTime;
            }
        }
        else
        {
            if (timerVal > 0)
            {
                fillFrac = timerVal / answerTime;
            }
            else
            {
                answering = true;
                timerVal = questionTime;
                loadNext = true;
            }
        }
        Debug.Log(answering + "-" + timerVal +"=" +fillFrac);
    }
}
