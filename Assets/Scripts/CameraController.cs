using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    [SerializeField] private GameObject player;
    private Vector3 cameraPosition;

    void Start()
    {
        cameraPosition = gameObject.transform.position;
    }

    void Update()
    {
        cameraPosition.x = player.transform.position.x;
        gameObject.transform.position = cameraPosition;
    }
}
