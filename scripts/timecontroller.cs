using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class timecontroller : MonoBehaviour
{
	int countDownStartValue = 30;
	public Text timer;
    // Start is called before the first frame update
    void Start()
    {
		countDownTimer();
    }
	void countDownTimer()
	{
		if(countDownStartValue>0)
		{
			TimeSpan SpanTime = TimeSpan.FromSeconds(countDownStartValue);
			timer.text = "Time: " + SpanTime.Minutes + ":" + SpanTime.Seconds;
			countDownStartValue--;
			Invoke("countDownTimer", 1.0f);
		}
		else
		{
			timer.text = "Game Over! ";
			GameOverReload();
		}
	}
	public void GameOverReload()
	{
		SceneManager.LoadScene(0);
	}

    // Update is called once per frame
    void Update()
    {
        
    }
}
