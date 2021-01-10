using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject player;
    
    private readonly Vector3 cameraOffset = new Vector3(0, 1.45f, -4);

    private void Update()
    {
        transform.position = player.transform.position + cameraOffset;
    }
}
