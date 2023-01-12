using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndicatorManager : MonoBehaviour
{
    public static IndicatorManager instance;

    public RectTransform prefab;
    public RectTransform container;

    private Dictionary<TrackedObject, RectTransform> indicators = new Dictionary<TrackedObject, RectTransform>();

    private void Awake()
    {
        Debug.Log(1);
        instance = this;
    }

    private void LateUpdate()
    {
        foreach (var pair in indicators)
        {
            pair.Value.anchoredPosition = GetCanvasPosition(pair.Key);
        }
    }

    private Vector2 GetCanvasPosition(TrackedObject target)
    {
        var point = Camera.main.WorldToViewportPoint(target.transform.position);
        point.x = Mathf.Clamp01(point.x);
        point.y = Mathf.Clamp01(point.y);

        if (point.z < 0f) 
        {
            point.y = 0f;
            point.x = 1f - point.x;
        }

        var size = container.sizeDelta;
        point.Scale(size);

        return point;
    }

    public void Add(TrackedObject trackedObj)
    {
        if (indicators.ContainsKey(trackedObj)) 
        {
            return;
        }

        var indicator = Instantiate(prefab, container);
        indicator.anchoredPosition = GetCanvasPosition(trackedObj);
        indicators.Add(trackedObj, indicator);
    }

    public void Remove(TrackedObject trackedObj)
    {
        indicators.Remove(trackedObj);
        Destroy(trackedObj.gameObject);
    }
}
