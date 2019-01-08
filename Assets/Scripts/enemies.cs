using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class enemies : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float followDistance;
    
    private Transform player;

    private Rigidbody2D rigidbody2d;

    void Start ()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rigidbody2d = GetComponent<Rigidbody2D>();
	}

	void Update ()
	{

		if (Vector2.Distance(transform.position, player.position) < followDistance)
        {
            rigidbody2d.velocity = new Vector2(player.position.x - transform.position.x, 0) * speed;
        }
        else
        {
            rigidbody2d.velocity = new Vector2(0, rigidbody2d.velocity.y);
        }
       
	}
    
}
