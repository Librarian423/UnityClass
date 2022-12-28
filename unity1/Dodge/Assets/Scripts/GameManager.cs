using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameObject centerMessage;
    public TextMeshProUGUI textTime;
    public TextMeshProUGUI textRecord;

    private float surviveTime;
    private bool isGameOver;


    public float SurviveTime
    {
        get
        {
            return surviveTime;
        }
        set
        {
            surviveTime = value;
            textTime.text = $"Time: {surviveTime:F1}";
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        surviveTime = 0f;
        isGameOver = false;
        centerMessage.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (!isGameOver)
        {
            SurviveTime += Time.deltaTime;
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                var activeScene = SceneManager.GetActiveScene();
                SceneManager.LoadScene(activeScene.name);
            }
        }
        
    }

    public void EndGame()
    {
        isGameOver = true;
        centerMessage.SetActive(true);

        var bestRecord = PlayerPrefs.GetFloat("BEST_RECORD", 0f);

        if (surviveTime > bestRecord) 
        {
            bestRecord = surviveTime;
            PlayerPrefs.SetFloat("BEST_RECORD", bestRecord);
        }
        textRecord.text = $"Best Time: {bestRecord:F1}";
    }
}
