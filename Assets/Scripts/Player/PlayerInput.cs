using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private PlayerMovement movement;
    private PlayerJump jump;

    private void Awake()
    {
        movement = GetComponent<PlayerMovement>();
        jump = GetComponent<PlayerJump>();
    }
    private void Update()
    {
        //Input.GetAxisRaw("Horizontal");
        movement.setDirection(Input.GetAxisRaw("Horizontal"));

        if (Input.GetKey(KeyCode.Space))
        {
            jump.Jump();
        }
    }
}
