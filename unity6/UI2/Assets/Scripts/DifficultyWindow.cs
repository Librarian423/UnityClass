using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DifficultyWindow : GenericWindow
{
    public int defaultToggle = 1; //0, 1, 2
    public Toggle[] toggles;

    public float interval = 0.25f;

    private float timer;

    private int currentToggle;

    public override void Open()
    {
        timer = interval;
        base.Open();
        currentToggle = defaultToggle;
        toggles[defaultToggle].isOn = true;

    }
    public override void Close()
    {
        base.Close();
    }

    private void Update()
    {
        timer += Time.deltaTime;
        var h = Input.GetAxisRaw("Horizontal");
        if (timer > interval && h != 0) 
        {
            timer = 0f;
            currentToggle += (int)h;

            if (currentToggle < 0)
            {
                currentToggle = toggles.Length - 1;
            }
            if (currentToggle >= toggles.Length)
            {
                currentToggle = 0;
            }

            toggles[currentToggle].isOn = true;
        }
    }

    public void OnToggleChange(bool isOn)
    {
        if (isOn)
        {
            for (int i = 0; i < toggles.Length; i++)
            {
                if (toggles[i].isOn)
                {
                    currentToggle = i;
                    break;
                }
            }
        }
    }
}
