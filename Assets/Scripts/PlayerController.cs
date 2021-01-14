using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour{

    private Rigidbody playerRigidBody;
    private float speed = 2.0f;
    private float turnAngle = 45.0f;
    public bool invertYAxis = true;
    private int invertedState;

    public float horizontalInput;
    public float verticalInput;

    private void Start() {
        playerRigidBody = GetComponent<Rigidbody>();
        
        setCameraInversionState();
    }

    private void Update() {
        applyEngineForce();
    }

    private void setCameraInversionState() {
        if (invertYAxis) {
            invertedState = -1;
        } else {
            invertedState = 1;
        }
    }

    private void applyEngineForce() {
        // Get current input values
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        // Calculate and apply translation
        float xTranslation = horizontalInput * speed *  Time.deltaTime;
        float yTranslation = verticalInput * speed * invertedState * Time.deltaTime; 
        transform.Translate(xTranslation, yTranslation, 0);

        // Calculate and apply rotation
        float yRotation = horizontalInput * turnAngle * Time.deltaTime;
        transform.Rotate(Vector3.up, yRotation);
    }
}
