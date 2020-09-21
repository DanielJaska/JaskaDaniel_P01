using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreaseTime : MonoBehaviour
{
    private GameController controller;

    [SerializeField] AudioClip clip;

    [SerializeField] Transform art;

    [SerializeField] float rotateSpeed;

    private void Awake()
    {
        controller = FindObjectOfType<GameController>();
    }

    private void Update()
    {
        transform.Rotate(0f, rotateSpeed, 0f, Space.World);
    }

    private void OnTriggerEnter(Collider other)
    {
        PlayerShip playerShip = other.GetComponent<PlayerShip>();

        if (playerShip != null)
        {
            controller.IncreaseTime();
            AudioController.PlayClip(clip);
            Destroy(gameObject);
        }
    }


}
