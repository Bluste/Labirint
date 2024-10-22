using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed = 12f;
    Vector3 velocity;
    CharacterController characterController;
    public Transform groundCheck;
    public LayerMask groundMask;

    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMove();
    }

    void PlayerMove()
    {
        RaycastHit hit;
        if (Physics.Raycast(groundCheck.position, transform.TransformDirection(Vector3.down), out hit, 1f, groundMask)) {
            string terrainType;
            terrainType = hit.collider.gameObject.tag;
            switch (terrainType) {
                default:
                    speed = 12f;
                    break;
                case "Low":
                    speed = 3f;
                    break;
                case "High":
                    speed = 20f;
                    break;
            }
        }


        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        characterController.Move(move * speed * Time.deltaTime);
    }
}
