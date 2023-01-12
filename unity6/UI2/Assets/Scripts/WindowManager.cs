using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowManager : MonoBehaviour
{
    public static WindowManager instance;

    public GenericWindow[] windows;
    public int currentWndId;

    public int defaultWndId;

    public GenericWindow GetWindow(int id)
    {
        return windows[id];
    }

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    private void Start()
    {
        Open(defaultWndId);
    }

    private void ToggleWindow(int id)
    {
        for (int i = 0; i < windows.Length; i++)
        {
            if (i == id)
            {
                windows[i].Open();
            }
            else if (windows[i].gameObject.activeSelf)
            {
                windows[i].Close();
            }
            
        }
    }

    public GenericWindow Open(Windows id)
    {
        return Open((int)id);
    }

    public GenericWindow Open(int id)
    {
        if (id < 0 || id >= windows.Length) 
        {
            return null;
        }

        currentWndId = id;
        ToggleWindow(currentWndId);

        return GetWindow(currentWndId);
    }


}
