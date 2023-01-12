using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListItem : MonoBehaviour
{
    public float delay = 2f;
    public float fadeTime = 0.25f;

    // Start is called before the first frame update
    IEnumerator Start()
    {
        yield return new WaitForSeconds(delay);

        var group = GetComponent<CanvasGroup>();
        var accumTime = 0f;

        while (accumTime < fadeTime) 
        {
            accumTime += Time.deltaTime;
            group.alpha = Mathf.Lerp(1f, 0f, accumTime / fadeTime);

            yield return 0;
        }

        Destroy(gameObject);
    }

   
}
