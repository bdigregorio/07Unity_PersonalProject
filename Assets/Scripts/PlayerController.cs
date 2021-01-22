using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour{

    public GameObject mainCamera;
    private Rigidbody playerRigidBody;
    public float horizontalInput;
    public float verticalInput;

    private Vector3 cameraOffset = new Vector3(0, 1, -4);
    private float speed = 2.0f;
    private float turnAngle = -45.0f;
    public bool invertYAxis = true;
    private int invertedState;
    private float xBounds = 4.0f;
    private float yMinBounds = -1.5f;
    private float yMaxBounds = 2.5f;

    private void Start() {
        playerRigidBody = GetComponent<Rigidbody>();
        setCameraInversionState();
    }

    private void Update() {
        MovePlayer();
        KeepPlayerInBounds();
        MoveCamera();
    }

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("PathTarget")) {
            CollideWithPathTarget(other);
        } else if (other.CompareTag("Powerup")) {
            CollideWithPowerup(other);
        } else if (other.CompareTag("Terrain")) {
            CollideWithTerrain(other);
        }
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

        // TODO Fix rotation logic: 
        // instead of invoking Rotate (which will keep rotating as long as we have input)
        // we shoud have a maxRotation amount and multiply it by the current vert/hor input
        // this will unwind the rotation when the input key is released
        // ========= broken implementation below
        // Calculate and apply rotation
        // float xRotation = verticalInput * turnAngle * Time.deltaTime;
        // float zRotation = horizontalInput * turnAngle * Time.deltaTime;
        // transform.Rotate(Vector3.right, xRotation);
        // transform.Rotate(Vector3.forward, zRotation);
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

    private void MoveCamera() {
        mainCamera.transform.position = transform.position + cameraOffset;
    }

    private void CollideWithPathTarget(Collider collider) {
        GameObject pathTarget = collider.gameObject;
        Debug.Log($"Collide with PathTarget: {pathTarget}");

        Destroy(pathTarget);
    }

    private void CollideWithPowerup(Collider collider) {
        GameObject powerup = collider.gameObject;
        Debug.Log($"Collide with Powerup: {powerup}");
        
        Destroy(powerup);    
    }

    private void CollideWithTerrain(Collider collider) {
        GameObject terrain = collider.gameObject;
        Debug.Log($"Collide with Terrain: {terrain}");

        Destroy(gameObject);
        // TODO trigger game over here
    }
}
