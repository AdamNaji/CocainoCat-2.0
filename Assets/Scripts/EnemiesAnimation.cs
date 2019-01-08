using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesAnimation : MonoBehaviour
{
    private Animator enemiesAnimator;
    SpriteRenderer enemiesRenderer;
    Rigidbody2D enemiesRigidbody2D;
    
    void Start()
    {
        enemiesRigidbody2D = GetComponentInParent<Rigidbody2D>();
        enemiesAnimator = gameObject.GetComponent<Animator>();
        enemiesRenderer = GetComponent<SpriteRenderer>();
    }
    
    void Update()
    {
        if (enemiesRigidbody2D.velocity.x < 0)
        {
            enemiesAnimator.SetBool("isMoving", true);
            enemiesRenderer.flipX = true;
        }
        if (enemiesRigidbody2D.velocity.x > 0)
        {
            enemiesAnimator.SetBool("isMoving", true);
            enemiesRenderer.flipX = false;
        }
        if (enemiesRigidbody2D.velocity.x == 0)
        {
            enemiesAnimator.SetBool("isMoving", false);
        }
    }
}