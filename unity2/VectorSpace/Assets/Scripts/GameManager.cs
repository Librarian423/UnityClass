using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //private GameObject[] balls;
    private GameObject cube;

    // Start is called before the first frame update
    void Start()
    {
        //balls = GameObject.FindGameObjectsWithTag("Ball");
        cube = GameObject.FindGameObjectWithTag("Shapes");
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
