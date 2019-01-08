using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour {

    private Animator playerAnimator;

	void Start ()
	{
        playerAnimator = gameObject.GetComponent<Animator>();
	}

    void Update()
    {
        if (Input.GetAxisRaw("Horizontal") < 0 || Input.GetAxisRaw("Horizontal") > 0)
        {
            playerAnimator.SetBool("isMoving", true);
        }
        if (Input.GetAxisRaw("Horizontal") == 0)
        {
            playerAnimator.SetBool("isMoving", false);
        }
    }
}
