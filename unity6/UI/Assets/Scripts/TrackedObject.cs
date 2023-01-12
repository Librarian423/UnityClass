using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackedObject : MonoBehaviour
{
    private void OnEnable()
    {
        Debug.Log(2);
        IndicatorManager.instance.Add(this);
    }

    private void OnDisable()
    {
        IndicatorManager.instance.Remove(this);
    }
}
