using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    public GameObject ballPrefab;
    public int ballCount;
    public float range = 10;

    private List<GameObject> balls = new List<GameObject>();

    public int BallCount
    {
        set
        {
            ballCount--;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        ballCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (balls.Count <= 0) 
        {
            CreateBalls();
        }
        
    }

    private void CreateBalls()
    {
        ballCount = Random.Range(5, 10);
        
        for (int i = 0; i < ballCount; i++)
        {
            var pos = Random.insideUnitCircle * range;
            balls.Add(Instantiate(ballPrefab, Random.insideUnitSphere * range, Quaternion.identity));
        }
        balls[0].tag = "Target";
        balls[0].GetComponent<MeshRenderer>().material.color = Color.green;
    }

    private void SetTarget()
    {
        bool isTag = false;
        for (int i = 0; i < balls.Count; i++)
        {
            if (balls[i].tag == "Target") 
            {
                break;
            }
        }

        if (isTag)
        {
            //balls[]
        }
    }
}
