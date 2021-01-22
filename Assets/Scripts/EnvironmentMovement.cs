using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentMovement : MonoBehaviour {

    private GameObject ground;
    private float engineSpeed = 8.0f;
    private float zDestroyBounds = -5.0f;

    private void Start() {
        ground = GameObject.Find("Ground");
    }

    private void Update() {
        SimulateEngineMovement();
        RemoveOutOfBounds();
    }

    private void SimulateEngineMovement() {
        transform.Translate(Vector3.back * engineSpeed * Time.deltaTime);

    }

    private void RemoveOutOfBounds() {
        if (transform.position.z < zDestroyBounds) {
            Destroy(gameObject);
        }
    }
}
