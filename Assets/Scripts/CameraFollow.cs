using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Transform _objectToFollow = null;

    Vector3 _objectOffset;

    // Start is called before the first frame update
    void Awake()
    {
        _objectOffset = this.transform.position - _objectToFollow.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        this.transform.position = _objectToFollow.position + _objectOffset;
    }
}
