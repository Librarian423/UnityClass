using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartWindow : GenericWindow
{
    public Button continueButton;
    public bool isContinue;

    public override void Open()
    {
        continueButton.gameObject.SetActive(isContinue);
        if (isContinue)
        {
            firstSelected = continueButton.gameObject;
        }

        base.Open();
    }

    public void OnContinue()
    {
        Debug.Log("OnContinue");
        OnNextWindow();
    }

    public void OnNewGame()
    {
        //Debug.Log("OnNewGame");
        OnPrevWindow();
    }

    public void OnOption()
    {
        Debug.Log("OnOption");
    }
}
