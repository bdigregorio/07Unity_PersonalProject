using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentMovement : MonoBehaviour {
    public float engineSpeed = 10.0f;

    private void Update() {
        transform.Translate(Vector3.back * engineSpeed * Time.deltaTime);
    }
}
