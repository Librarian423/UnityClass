using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spin : MonoBehaviour
{
    public float spinTime = 0.5f;
    public AnimationCurve curve = AnimationCurve.EaseInOut(0, 0, 1, 1);


    public void OnClick()
    {
        StartCoroutine(CoStartSpinning());
    }

    private IEnumerator CoStartSpinning()
    {
        var accumTime = 0f;

        while (accumTime < spinTime)
        {
            accumTime += Time.deltaTime;
            var t = accumTime / spinTime;
            var angle = curve.Evaluate(t) * 360f;

            transform.localRotation = Quaternion.AngleAxis(angle, Vector3.right);

            yield return null;
        }
        transform.localRotation = Quaternion.identity;
    }
}
