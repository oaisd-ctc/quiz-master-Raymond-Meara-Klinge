using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    int correct = 0;

    int seen = 0;

    public int GetCorrect()
    {
        return correct;
    }

    public void IncCorrect()
    {
        correct++;
    }

    public int GetSeen()
    {
        return seen;
    }

    public void IncSeen()
    {
        seen++;
    }

    public int Score()
    {
        return Mathf.RoundToInt(correct / (float) seen * 100);
    }
}
