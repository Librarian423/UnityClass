using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GenericWindow : MonoBehaviour
{
    public GameObject firstSelected;

    public Windows nextWindow = Windows.None;
    public Windows prevWindow = Windows.None;

    public void OnNextWindow()
    {
        WindowManager.instance.Open(nextWindow);
    }

    public void OnPrevWindow()
    {
        WindowManager.instance.Open(prevWindow);
    }

    protected virtual void Awake()
    {
        Close();
    }

    public void OnFocus()
    {
        EventSystem.current.SetSelectedGameObject(firstSelected);
    }

    protected void Display(bool active)
    {
        gameObject.SetActive(active);
    }

    public virtual void Open()
    {
        Display(true);
        OnFocus();
    }

    public virtual void Close()
    {
        Display(false);
    }
}
