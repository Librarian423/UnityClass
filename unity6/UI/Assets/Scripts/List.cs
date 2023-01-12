using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class List : MonoBehaviour
{
    public GameObject itemPrefab;
    public RectTransform content;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) 
        {
            Instantiate(itemPrefab, content);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            if (content.childCount > 0) 
            {
                Destroy(content.GetChild(content.childCount - 1).gameObject);
            }
            
        }
    }
}
