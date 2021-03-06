using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float _speed = 5;
    private float _forwardInput, _horizontalInput;

    [SerializeField]
    GameObject winPanel;

    // Update is called once per frame
    void Update()
    {
        _horizontalInput = Input.GetAxis("Horizontal");
        _forwardInput = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(_horizontalInput, _forwardInput);
        transform.Translate(movement * _speed * Time.deltaTime);

    }
}
