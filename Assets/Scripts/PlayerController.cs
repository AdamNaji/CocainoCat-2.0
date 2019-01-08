using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float jumpForce = 1.0f;
    [SerializeField] private int maxAvailableJumps = 1;
    [SerializeField] private float moveForce = 1.0f;

    [SerializeField] private AudioSource jumpSound;
    SpriteRenderer playerRenderer;

    private int jumpCounter = 0;
    private Rigidbody2D playerRigidbody2D;
    bool JumpKeyPressed = false;

	void Start ()
	{
        playerRigidbody2D = GetComponent<Rigidbody2D>();
        playerRenderer = GetComponentInChildren<SpriteRenderer>();
	}

    void Update () {

        float moveX = Input.GetAxisRaw("Horizontal");
        playerRigidbody2D.AddForce(new Vector2(moveX, 0) * moveForce * Time.deltaTime);

        if (moveX > 0)
	    {
            playerRenderer.flipX = false;
	    }

        else if (moveX < 0)
        {
            playerRenderer.flipX = true;
        }

        if (Input.GetButtonDown("Jump") && jumpCounter < maxAvailableJumps)
	    {
            jumpCounter += 1;
            JumpKeyPressed = true;
            jumpSound.PlayOneShot(jumpSound.clip);
	    }
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        jumpCounter = 0;
    }

    private void FixedUpdate()
    {
        if (JumpKeyPressed)
        {
            playerRigidbody2D.AddForce(Vector2.up * jumpForce);
            JumpKeyPressed = false;
        }
    }
}
