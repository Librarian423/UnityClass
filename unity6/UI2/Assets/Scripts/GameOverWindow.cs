using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameOverWindow : GenericWindow
{
    public TextMeshProUGUI leftLabel;
    public TextMeshProUGUI leftValue;

    public TextMeshProUGUI rightLabel;
    public TextMeshProUGUI rightValue;

    public TextMeshProUGUI totalScore;

    private int step = 0;
    public int totalStep = 7;

    public override void Open()
    {
        ClearText();
        base.Open();

        var score = new int[] { 1, 2, 3, 4, 5, 6, 999999999 };

        StartCoroutine(CoScoreEffect(score, 1f));
    }

    IEnumerator CoScoreEffect(int[] score, float delay)
    {
        int currentStep = 0;
        while (currentStep < totalStep - 1) 
        {
            switch (currentStep)
            {
                case 0:
                case 1:
                case 2:
                    leftLabel.text += $"Stats {currentStep + 1}{(currentStep < 2 ? "\n" : "")}";
                    leftValue.text += $"{score[currentStep]:D4}{(currentStep < 2 ? "\n" : "")}";
                    break;
                case 3:
                case 4:
                case 5:
                    rightLabel.text += $"Stats {currentStep + 1}{(currentStep < 5 ? "\n" : "")}";
                    rightValue.text += $"{score[currentStep]:D4}{(currentStep < 5 ? "\n" : "")}";
                    break;
            }
            currentStep++;
            yield return new WaitForSeconds(delay);
        }

        float time = 2f;
        float accumTime = 0f;

        while (accumTime < time) 
        {
            accumTime += Time.deltaTime;
            int s = Mathf.FloorToInt(Mathf.Lerp(0, score[6], accumTime / time));

            totalScore.text = $"{s:D9}";
            yield return 0;
        }
        totalScore.text = $"{score[6]:D9}";
    }

    public void OnNext()
    {
        //Debug.Log("OnNext");
        OnNextWindow();
    }

    public void ClearText()
    {
        leftLabel.text = string.Empty;
        leftValue.text = string.Empty;
        rightLabel.text = string.Empty;
        rightValue.text = string.Empty;
        totalScore.text = string.Empty;
    }

    
}
