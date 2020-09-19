using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreaseTime : MonoBehaviour
{
    [SerializeField] GameController controller;

    [SerializeField] AudioClip clip;

    [SerializeField] float rotateSpeed;

    private void Update()
    {
        transform.Rotate(0f, rotateSpeed, 0f);
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
