using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    Quiz quiz;

    EndScreen end;

    void Awake()
    {
        quiz = FindObjectOfType<Quiz>();
        end = FindObjectOfType<EndScreen>();
    }

    void Start()
    {
        quiz.gameObject.SetActive(true);
        end.gameObject.SetActive(false);
    }

    void Update()
    {
        if (quiz.complete == true)
        {
            quiz.gameObject.SetActive(false);
            end.gameObject.SetActive(true);
            end.ShowFinalScore();
        }
    }

    public void ReplayLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
