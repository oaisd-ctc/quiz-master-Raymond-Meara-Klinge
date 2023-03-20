using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Quiz : MonoBehaviour
{
    [Header("Questions")]
    [SerializeField]
    QuestionSO question;

    [SerializeField]
    TextMeshProUGUI qText;

    [SerializeField]
    List<QuestionSO> questions = new List<QuestionSO>();

    [Header("Answers")]
    [SerializeField]
    GameObject[] answerArray;

    bool earlyAnswer = true;

    int correctAnswerIndex;

    [Header("Button Colors")]
    [SerializeField]
    Sprite defaultBox;

    [SerializeField]
    Sprite correctBox;

    [Header("Timer")]
    [SerializeField]
    Image timerImage;

    Timer timer;

    [Header("Score")]
    [SerializeField]
    TextMeshProUGUI scoreText;

    ScoreKeeper scoreKeeper;

    [Header("Progress Bar")]
    [SerializeField]
    Slider progressBar;

    public bool complete = false;

    void Awake()
    {
        timer = FindObjectOfType<Timer>();
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
        progressBar.maxValue = questions.Count;
        progressBar.value = 0;
    }

    void Update()
    {
        timerImage.fillAmount = timer.fillFrac;
        if (timer.loadNext)
        {
            if (progressBar.value == progressBar.maxValue)
            {
                complete = true;
                return;
            }

            earlyAnswer = false;
            GetNext();
            timer.loadNext = false;
        }
        else if (!earlyAnswer && !timer.answering)
        {
            AnsDisplay(-1);
            ButtState(false);
        }
    }

    void qDisplay()
    {
        qText.text = question.GetQuestion();

        for (int i = 0; i < answerArray.Length; i++)
        {
            TextMeshProUGUI buttonText =
                answerArray[i].GetComponentInChildren<TextMeshProUGUI>();
            buttonText.text = question.GetAnswer(i);
        }
    }

    public void OnSelection(int index)
    {
        earlyAnswer = true;
        AnsDisplay (index);
        ButtState(false);
        timer.CancelTime();
        scoreText.text = $"Score: {scoreKeeper.Score()}%";
    }

    void AnsDisplay(int index)
    {
        if (index == question.GetCorrectAnswerIndex())
        {
            qText.text = "That's right!";
            Image defaultBox = answerArray[index].GetComponent<Image>();
            defaultBox.sprite = correctBox;
            scoreKeeper.IncCorrect();
        }
        else
        {
            correctAnswerIndex = question.GetCorrectAnswerIndex();
            string correctAnswer = question.GetAnswer(correctAnswerIndex);
            qText.text = $"Idiot... \n The answer was {correctAnswer}";
            Image defaultBox =
                answerArray[correctAnswerIndex].GetComponent<Image>();
            defaultBox.sprite = correctBox;
        }
    }

    void GetNext()
    {
        if (questions.Count > 0)
        {
            ButtState(true);
            DefaultButt();
            GetRandom();
            qDisplay();
            progressBar.value++;
            scoreKeeper.IncSeen();
        }
    }

    void GetRandom()
    {
        int index = UnityEngine.Random.Range(0, questions.Count);
        question = questions[index];

        if (questions.Contains(question))
        {
            questions.Remove (question);
        }
    }

    void ButtState(bool state)
    {
        {
            for (int i = 0; i < answerArray.Length; i++)
            {
                Button butts = answerArray[i].GetComponent<Button>();
                butts.interactable = state;
            }
        }
    }

    void DefaultButt()
    {
        for (int i = 0; i < answerArray.Length; i++)
        {
            Image booton = answerArray[i].GetComponent<Image>();
            booton.sprite = defaultBox;
        }
    }
}
