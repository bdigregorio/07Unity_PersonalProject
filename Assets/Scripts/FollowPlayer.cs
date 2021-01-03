using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject player;
    
    private readonly Vector3 _cameraOffset = new Vector3(0, 3, -5);

    private void Update()
    {
        transform.position = player.transform.position + _cameraOffset;
    }
}
