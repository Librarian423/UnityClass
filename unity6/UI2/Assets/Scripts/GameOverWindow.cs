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

    protected override void Awake()
    {

    }

    private void Start()
    {
        Open();
    }

    public override void Open()
    {
        ClearText();
        base.Open();
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
