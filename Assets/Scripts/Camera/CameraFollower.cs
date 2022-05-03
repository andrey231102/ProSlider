using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    private Vector3 _offset;

    private void Start()
    {
        _offset = transform.position;
    }

    void LateUpdate()
    {
        transform.position = new Vector3(_offset.x, _offset.y, transform.position.z);
    }
}
