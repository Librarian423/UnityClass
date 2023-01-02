using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sphere : MonoBehaviour
{
    private MeshRenderer sphere;
    private bool isTarget = false;

    public bool IsTarget
    {
        get { return isTarget; }
        set
        {
            isTarget = value;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        sphere = GetComponent<MeshRenderer>();
        //SetColor();
    }

    // Update is called once per frame
    void Update()
    {
        if (tag == "Target")
        {
            SetColor();
            IsTarget = true;
        }
    }

    public void Erase()
    {
        gameObject.SetActive(false);
        var spawner = GetComponent<BallSpawner>();
        spawner.ballCount--;
    }

    public void SetColor()
    {
        
        sphere.material.color = Color.green;
    }
}
