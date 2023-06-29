using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimerX : MonoBehaviour
{
    private GameManagerX gameManager;

    [SerializeField] float startTime;
    [SerializeField] TMP_Text timerText;

    float currentTime;

    bool timerStarted = false;

    public void StartTimer()
    {
        gameManager = FindObjectOfType<GameManagerX>();

        currentTime = startTime;

        timerText.text = currentTime.ToString();

        timerStarted = true;
    }

    void Update()
    {
        if(timerStarted)
        {
            currentTime -= Time.deltaTime;

            if(currentTime <= 0)
            {
                Debug.Log("Time Over");
                timerStarted = false;
                currentTime = 0;
                gameManager.GameOver();
            }

            timerText.text = "Timer : " + Mathf.Round(currentTime).ToString();
        }
    }
}
