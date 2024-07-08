using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    private Rigidbody2D rb2d;
    public float jumpPower = 5f;
    private groundCheck gc;
    private Animator anim;

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        gc = transform.Find("groundCheck").GetComponent<groundCheck>();
    }

    public void Jump()
    {
        if (!gc.IsGrounded()) return;

        anim.SetTrigger("jump");
        AudioManager.instance.PlaySFX("Jump");

        Vector2 velocity = rb2d.velocity;
        velocity.y = jumpPower;
        rb2d.velocity = velocity;
    }

    private void Update()
    {
        anim.SetBool("isGrounded", gc.IsGrounded());
        anim.SetFloat("velocity", rb2d.velocity.y);
    }
}
