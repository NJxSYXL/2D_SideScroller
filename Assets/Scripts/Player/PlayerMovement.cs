using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    
    [SerializeField] private float speed = 10f;
    private Rigidbody2D rb2d;
    private SpriteRenderer sr;
    private Animator animator;
    private groundCheck gc;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        gc = transform.Find("groundCheck").GetComponent<groundCheck>();
    }


    public void setDirection(float Direction)
    {
        if (Direction != 0)
            sr.flipX = Direction < 0f;

        animator.SetFloat("Direction", Mathf.Abs(Direction));

        if (!gc.IsGrounded() || Direction == 0)
            AudioManager.instance.StopSFXLoop();
        else
            AudioManager.instance.PlaySFXLoop("Walk");


        Vector2 velocity = rb2d.velocity;
        velocity.x = Direction * speed;
        rb2d.velocity = velocity;
    }
}
