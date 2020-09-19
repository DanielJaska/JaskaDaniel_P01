using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectKey : MonoBehaviour
{
    [SerializeField] float _rotateSpeed = 0f;

    [SerializeField] AudioClip clip;

    private GameController controller;

    private void Awake()
    {
        controller = FindObjectOfType<GameController>();
    }

    private void Update()
    {
        transform.Rotate(0, _rotateSpeed, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            controller.CollectKey();
            AudioController.PlayClip(clip);
            Destroy(gameObject);
        }
    }
}
