using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class groundCheck : MonoBehaviour
{
    [SerializeField] private bool isGrounded;
    [SerializeField] private LayerMask platformLayer;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Finish")) return;

        CheckTrigger(collision);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Finish")) return;

        CheckTrigger(collision);
    }

    private void CheckTrigger(Collider2D collision)
    {
        isGrounded = collision != null && (((1 << collision.gameObject.layer) & platformLayer) != 0);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isGrounded = false;
    }

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    isGrounded = true;
    //}

    public bool IsGrounded()
    {
        return isGrounded;
    }
}
