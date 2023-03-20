using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Quiz Quesion", fileName = "New Question")]
public class QuestionSO : ScriptableObject
{
    [TextArea(2, 6)]
    [SerializeField]
    string question = "Enter Question Text Here";

    [SerializeField]
    string[] answers = new string[4];

    [SerializeField]
    int correctAnswer;

    public string GetQuestion()
    {
        return question;
    }

    public string GetAnswer(int index)
    {
        return answers[index];
    }

    public int GetCorrectAnswerIndex()
    {
        return correctAnswer;
    }
}
