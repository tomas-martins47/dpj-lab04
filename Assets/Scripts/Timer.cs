using UnityEngine;

public class Timer : MonoBehaviour
{
    public bool isAnsweringQuestion = false;
    public bool loadNextQuestion;
    public float fillFraction; 
    
    [SerializeField] private float timeToCompleteQuestion = 10f;
    [SerializeField] private float timeToShowCorrectAnswer = 2f;
  
    private float timerValue;

    private void Update()
    {
        UpdateTimer();
    }

    // Conta o tempo para responder ou mostrar a resposta
    // Quando chega a zero, alterna entre as duas fases
    // Reinicia o tempo e carrega a próxima pergunta
    private void UpdateTimer()
    {
        if (isAnsweringQuestion)
        {
            timerValue -= Time.deltaTime;
            fillFraction = timerValue / timeToCompleteQuestion;

            if (timerValue <= 0f)
            {
                isAnsweringQuestion = false;
                timerValue = timeToShowCorrectAnswer;
            }
        }
        else
        {
            timerValue -= Time.deltaTime;
            fillFraction = timerValue / timeToShowCorrectAnswer;

            if (timerValue <= 0f)
            {
                isAnsweringQuestion = true;
                timerValue = timeToCompleteQuestion;
                loadNextQuestion = true;
            }
        }
    }

    public void CancelTimer()
    {
        timerValue = 0f;
    }
}
