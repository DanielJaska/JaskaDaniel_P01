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

    //public void AdjustCameraHeight(float y)
    //{
    //    StartCoroutine(MoveCamera(y));
    //}

    //IEnumerator MoveCamera(float y)
    //{
    //    for(int i = 0; i < y; i++)
    //    {
    //        if(y > 0)
    //        {
    //            _objectOffset.y += .1f;
    //        } else
    //        {
    //            _objectOffset.y += -.1f;
    //        }
            
    //        yield return new WaitForSeconds(.01f);
    //    }
    //}
}
