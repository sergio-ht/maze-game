using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalController : MonoBehaviour
{
    [SerializeField]
    ParticleSystem particles;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            particles.Play();
            Debug.Log("You win 123");
        }
    }
}
