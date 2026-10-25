using System;
using TMPro;
using UnityEngine;

[CreateAssetMenu(fileName = "New Question", menuName = "Scriptable Objects/QuestionSO")]
public class QuestionSO : ScriptableObject
{
    [TextArea(2, 5)]
    [SerializeField] private string question;
    [SerializeField] private string[] answers = new string[4];
    [SerializeField] private int correctAnswerIndex;


    public string GetQuestion() { return question; }

    public int GetCorrectAnswerIndex() { return correctAnswerIndex; }

    public string GetAnswer(int index) { return answers[index]; }
}
