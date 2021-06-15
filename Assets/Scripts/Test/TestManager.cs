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

    public int whichTest;

    private int totalQuestions = 0;
    private int score;

    private void Awake()
    {
        FindObjectOfType<Game>().LoadGame();
    }

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
        //ScoreTxt.text = score + " / " + totalQuestions;
        float puntuacionFinal = Mathf.Round(((((float)score / (float)totalQuestions) * 100) * 100f) / 100f);
        //Debug.Log(puntuacionFinal);

        if (whichTest == 0)
        {
            FindObjectOfType<Game>().califCVS = puntuacionFinal;
        }
        else if(whichTest == 1)
        {
            FindObjectOfType<Game>().califAbs = puntuacionFinal;
        }
        else if (whichTest == 2)
        {
            FindObjectOfType<Game>().califUML = puntuacionFinal;
        }
        else if (whichTest == 3)
        {
            FindObjectOfType<Game>().califDdC = puntuacionFinal;
        }

        FindObjectOfType<Game>().SaveGame();

        if (puntuacionFinal >= 70)
        {
            ScoreTxt.text = puntuacionFinal.ToString() + " %\n\n" + "Pasaste!";
            FindObjectOfType<SoundManagerScript>().Play("Success2");
        } else
        {
            ScoreTxt.text = puntuacionFinal.ToString() + " %\n\n" + "No Pasaste :C";
            FindObjectOfType<SoundManagerScript>().Play("Failure2");
        }
        
    }

    public void Correct()
    {
        score += 1;
        QnA.RemoveAt(currentQuestion);
        GenerateQuestion();
        FindObjectOfType<SoundManagerScript>().Play("Success");
    }

    public void Wrong()
    {
        WrongAnswerTxt.text = QnA[currentQuestion].Correction;
        WrongAnswerPanel.SetActive(true);
        FindObjectOfType<SoundManagerScript>().Play("Failure");
    }

    public void WrongCheck()
    {
        WrongAnswerPanel.SetActive(false);
        QnA.RemoveAt(currentQuestion);
        GenerateQuestion();
        FindObjectOfType<SoundManagerScript>().Play("Step");
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
