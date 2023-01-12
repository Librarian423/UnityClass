using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FirstPanel : MonoBehaviour
{
    private int percentage = 100;
    public TextMeshProUGUI howCool;

    // Start is called before the first frame update
    void Start()
    {
        howCool.text = percentage.ToString() + "%";
    }

    // Update is called once per frame
    void Update()
    {
        howCool.text = percentage.ToString() + "%";
    }

    
    public void Increase()
    {
        if (percentage >= 100) 
        {
            return;
        }
        else
        {
            percentage++;
            
        }
    }

    public void Decrease()
    {
        if (percentage <= 0)
        {
            return;
        }
        else
        {
            percentage--;
            
        }
    }
}
