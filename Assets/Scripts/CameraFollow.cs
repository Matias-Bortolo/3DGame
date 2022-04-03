using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform cameraTarget;
    private Vector3 _offset;

    // Start is called before the first frame update
    void Start()
    {
        _offset = transform.position - cameraTarget.transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 newPos = cameraTarget.transform.position + _offset;
        transform.position = newPos;
    }
}
