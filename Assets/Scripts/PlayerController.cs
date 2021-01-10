using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour{
    private float engineSpeed = 10.0f;

    void Start() {
        
    }

    private void Update() {
        applyEnginePower();
    }

    private void applyEnginePower() {
        float z = engineSpeed * Time.deltaTime;
        transform.Translate(0, 0, z);
    }
}
