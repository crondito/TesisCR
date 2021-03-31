using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TestManager : MonoBehaviour
{
    public List<QuestionsAndAnswers> QnA;
    public GameObject[] options;
    public int currentQuestion;

    public GameObject MainPanel;
    public GameObject GameOverPanel;
    public GameObject WrongAnswerPanel;

    public Text QuestionTxt;
    public Text ScoreTxt;
    public Text WrongAnswerTxt;

    private int totalQuestions = 0;
    private int score;

    void Start()
    {
        totalQuestions = QnA.Count;
        MainPanel.SetActive(false);
        WrongAnswerPanel.SetActive(false);
        MainPanel.SetActive(true);
        GenerateQuestion();
    }

    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void GameOver()
    {
        MainPanel.SetActive(false);
        GameOverPanel.SetActive(true);
        ScoreTxt.text = score + " / " + totalQuestions;
    }

    public void Correct()
    {
        score += 1;
        QnA.RemoveAt(currentQuestion);
        GenerateQuestion();
    }

    public void Wrong()
    {
        WrongAnswerTxt.text = QnA[currentQuestion].Correction;
        WrongAnswerPanel.SetActive(true);
    }

    public void WrongCheck()
    {
        WrongAnswerPanel.SetActive(false);
        QnA.RemoveAt(currentQuestion);
        GenerateQuestion();
    }

    void SetAnswers()
    {
        for (int i = 0; i < options.Length; i++)
        {
            options[i].GetComponent<AnswerScript>().isCorrect = false;
            options[i].transform.GetChild(0).GetComponent<Text>().text = QnA[currentQuestion].Answers[i];

            if (QnA[currentQuestion].CorrectAnswer == i)
            {
                options[i].GetComponent<AnswerScript>().isCorrect = true;
            }
        }
    }

    void GenerateQuestion()
    {
        if(QnA.Count > 0)
        {
            currentQuestion = Random.Range(0, QnA.Count);
            QuestionTxt.text = QnA[currentQuestion].Question;
            SetAnswers();
        }
        else
        {
            // Debug.Log("Out of Questions");
            GameOver();
        }

    }
}
