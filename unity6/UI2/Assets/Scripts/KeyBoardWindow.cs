using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using static System.Net.Mime.MediaTypeNames;
using UnityEngine.Windows;
using Unity.VisualScripting;

public class KeyBoardWindow : GenericWindow
{
    public TextMeshProUGUI inputs;
    public int maxStringLength = 6;

    private string underBar = "_";
    private string stringField;

    private bool isBlink = true;

    public float blinkTime = 1.5f;
    public float lastTime = 0f;

    private void Start()
    {
        stringField = string.Empty;
        Open();
    }

    public override void Open()
    {
        if (!gameObject.activeSelf) 
        {
            gameObject.SetActive(true);
        }
        
        if (gameObject.activeInHierarchy)
        {
            StartCoroutine(Blinking());
        }
        
        base.Open();
    }

    public override void Close()
    {
        //stringField = string.Empty;
        StopCoroutine(Blinking());
        
        base.Close();
    }

    IEnumerator Blinking()
    {
        Debug.Log("start co");
        //inputs.text = stringField + underBar;
        //yield return new WaitForSeconds(.5f);
        
        ////yield return new WaitForSeconds(.5f);
        //inputs.text = stringField;

        while (isBlink)
        {
            yield return new WaitForSeconds(.5f);
            inputs.text = stringField + underBar;
           
            yield return new WaitForSeconds(.5f);
            inputs.text = stringField;

            yield return new WaitForSeconds(.5f);
        }

    }

    public void OnKeyButton(string key)
    {
        if (stringField.Length > maxStringLength) 
        {
            return;
        }

        stringField = stringField + key;
    }

    public void OnCancel()
    {
        stringField = string.Empty;
        OnPrevWindow();
    }

    public void OnDelete()
    {
        if (stringField.Length <= 0) 
        {
            return;
        }
        stringField = stringField.Remove(stringField.Length - 1);
    }

    public void OnAccept()
    {
        stringField = string.Empty;
        OnNextWindow();
        
    }

}
