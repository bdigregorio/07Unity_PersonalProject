using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentMovement : MonoBehaviour {

    private GameObject ground;
    private Vector3 groundStartPosition;
    private float groundDepth;
    private float engineSpeed = 8.0f;
    private float zDestroyBounds = -5.0f;

    private void Start() {
        ground = GameObject.Find("Ground");
        groundDepth = ground.GetComponent<BoxCollider>().size.z / 2;
        groundStartPosition = ground.transform.position;
    }

    private void Update() {
        SimulateEngineMovement();
        RemoveOutOfBounds();
    }

    private void SimulateEngineMovement() {
        transform.Translate(Vector3.back * engineSpeed * Time.deltaTime);
        if (transform.position.z < groundStartPosition.z - groundDepth - 200) {
            ground.transform.position = groundStartPosition;
        }
    }

    private void RemoveOutOfBounds() {
        if (transform.position.z < zDestroyBounds) {
            Destroy(gameObject);
        }
    }
}
