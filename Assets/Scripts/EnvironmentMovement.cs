using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentMovement : MonoBehaviour {
    public float engineSpeed = 10.0f;
    private float zDestroyBounds = -5.0f;

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
