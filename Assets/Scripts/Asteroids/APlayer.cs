using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class APlayer : MonoBehaviour
{
    public float acceleration;
    public float maxSpeed;
    public float drag;
    public float angularSpeed;

    private Rigidbody2D rb;
    private float vertical;
    private float horizontal;
    private bool shooting;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.drag = drag;
    }

    private void Update()
    {
        vertical = AInputManager.Vertical;
        horizontal = AInputManager.Horizontal;
        shooting = AInputManager.Fire;

        Rotate();
    }

    private void FixedUpdate()
    {
        var forwardMotor = Mathf.Clamp(vertical, 0f, 1f);
        rb.AddForce(transform.up * acceleration * forwardMotor);
        if (rb.velocity.magnitude > maxSpeed)
        {
            rb.velocity = rb.velocity.normalized * maxSpeed;
        }
    }

    private void Rotate()
    {
        if(horizontal == 0)
        {
            return;
        }
        transform.Rotate(0, 0, -angularSpeed * horizontal * Time.deltaTime);
    }
}
