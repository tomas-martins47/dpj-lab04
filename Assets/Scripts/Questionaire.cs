using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Questionaire : MonoBehaviour
{
    [SerializeField] private QuestionSO questionSO;
    [SerializeField] private TextMeshProUGUI questionText;
    [SerializeField] private int correctAnswerIndex;
    [SerializeField] private GameObject[] answerButtons;
    [SerializeField] private Image timerImage;

    private Timer timer;
    private bool hasAnsweredEarly;

    private void Start()
    {
        timer = FindFirstObjectByType<Timer>();
        GetNextQuestion();
    }

    private void Update()
    {
        timerImage.fillAmount = timer.fillFraction;

        if (timer.loadNextQuestion)
        {
            GetNextQuestion();
            timer.loadNextQuestion = false;
        }
        else if (!hasAnsweredEarly && !timer.isAnsweringQuestion)
        {
            hasAnsweredEarly = true;
            DisplayAnswer(-1);
            SetButtonState(false);
        }
    }

    private void DisplayQuestion()
    {
        questionText.text = questionSO.GetQuestion();
        correctAnswerIndex = questionSO.GetCorrectAnswerIndex();

        for (int i = 0; i < answerButtons.Length; i++)
        {
            TextMeshProUGUI buttonText = answerButtons[i].GetComponentInChildren<TextMeshProUGUI>();
            buttonText.text = questionSO.GetAnswer(i);
        }
    }

    private void DisplayAnswer(int index)
    {
        if (index == correctAnswerIndex)
        {
            questionText.text = "Correct!";
        }
        else
        {
            string correctAnswer = questionSO.GetAnswer(correctAnswerIndex);
            questionText.text = "Sorry, the correct answer is: " + correctAnswer;
        }
    }

    public void OnAnswerSelected(int index)
    {
        hasAnsweredEarly = true;

        DisplayAnswer(index);
        SetButtonState(false);
        timer.CancelTimer();
    }

    private void SetButtonState(bool state)
    {
        for (int i = 0; i < answerButtons.Length; i++)
        {
            Button button = answerButtons[i].GetComponent<Button>();
            button.interactable = state;
        }
    }
    
    private void GetNextQuestion()
    {
        SetButtonState(true);
        DisplayQuestion();
        hasAnsweredEarly = false;
    }
}
