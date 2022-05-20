using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalController : MonoBehaviour
{
    [SerializeField]
    ParticleSystem particles;

    [SerializeField]
    private GameObject winPanel;

    [SerializeField]
    private AudioSource winSound;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            particles.Play();
            winSound.Play();
            Invoke("ShowWinScene", 0.5f);
            Debug.Log("You win 123");
        }
    }

    private void ShowWinScene()
    {
        winPanel.SetActive(true);
    }
}
