using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatePowerup : MonoBehaviour
{
    [SerializeField] float rotateSpeed = 150;
    // Start is called before the first frame update
    void Awake()
    {
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, 1 * Time.deltaTime * rotateSpeed, 0));
    }
}
