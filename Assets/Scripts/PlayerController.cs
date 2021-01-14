﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour{

    private Rigidbody playerRigidBody;
    public float horizontalInput;
    public float verticalInput;

    private float speed = 2.0f;
    private float turnAngle = 45.0f;
    public bool invertYAxis = true;
    private int invertedState;
    private float xBounds = 3.0f;
    private float yMinBounds = 0.0f;
    private float yMaxBounds = 3.0f;

    private void Start() {
        playerRigidBody = GetComponent<Rigidbody>();
        setCameraInversionState();
    }

    private void Update() {
        MovePlayer();
        KeepPlayerInBounds();
    }

    private void setCameraInversionState() {
        if (invertYAxis) {
            invertedState = -1;
        } else {
            invertedState = 1;
        }
    }

    private void MovePlayer() {
        // Get current input values
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        // Calculate and apply translation
        float xTranslation = horizontalInput * speed *  Time.deltaTime;
        float yTranslation = verticalInput * speed * invertedState * Time.deltaTime; 
        transform.Translate(xTranslation, yTranslation, 0, Space.World);

        // Calculate and apply rotation
        float yRotation = horizontalInput * turnAngle * Time.deltaTime;
        transform.Rotate(Vector3.up, yRotation);
    }

    private void KeepPlayerInBounds() {
        // Keep player in X bounds
        Vector3 playerPosition = transform.position;
        if (playerPosition.x < -xBounds) {
            transform.position = new Vector3(-xBounds, playerPosition.y, playerPosition.z);
            playerPosition.x = -xBounds;
        } 
        if (playerPosition.x > xBounds) {
            transform.position = new Vector3(xBounds, playerPosition.y, playerPosition.z);
            playerPosition.x = xBounds;
        }

        // Keep player in Y bounds
        if (playerPosition.y < yMinBounds) {
            transform.position = new Vector3(playerPosition.x, yMinBounds, playerPosition.z);
        } 
        if (playerPosition.y > yMaxBounds) {
            transform.position = new Vector3(playerPosition.x, yMaxBounds, playerPosition.z);
        }
    }
}
