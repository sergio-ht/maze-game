using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GoalController : MonoBehaviour
{
    [SerializeField]
    ParticleSystem particles;

    [SerializeField]
    private GameObject winPanel;

    [SerializeField]
    private AudioSource winSound;

    [SerializeField]
    private TextMeshProUGUI score;

    private DateTime _startTime;

    void Start()
    {
        _startTime = DateTime.Now;
        Debug.Log("Started on: " + _startTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            particles.Play();
            winSound.Play();
            
            TimeSpan endTime = DateTime.Now - _startTime;
            int totalSeconds = (int)endTime.TotalSeconds;

            Debug.Log("Finished on: " + (int)endTime.TotalSeconds);
            score.text = totalSeconds.ToString();

            Invoke("ShowWinScene", 0.5f);
            Debug.Log("You win 123");
        }
    }

    private void ShowWinScene()
    {
        winPanel.SetActive(true);
    }
}
