using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupSpeed : MonoBehaviour
{
    [Header("Powerup Settings")]
    [SerializeField] float _speedIncreaseAmount = 20;
    [SerializeField] float _powerupDuration = 5;
    //[SerializeField] float _cameraZoomOutDistance = 20;

    [Header("Setup")]
    [SerializeField] GameObject _visualsToDeactivate = null;
    [SerializeField] ParticleSystem particles;
    //[SerializeField] CameraFollow cameraPosition;

    Collider _colliderToDeactivate = null;
    bool _poweredUp = false;

    private void Awake()
    {
        _colliderToDeactivate = GetComponent<Collider>();

        //cameraPosition = Camera.main.transform.GetComponentInParent<CameraFollow>();

        EnableObject();
    }

    private void OnTriggerEnter(Collider other)
    {
        PlayerShip playerShip = other.GetComponent<PlayerShip>();

        if(playerShip != null && _poweredUp == false)
        {
            StartCoroutine(PowerupSequence(playerShip));
        }
    }

    IEnumerator PowerupSequence(PlayerShip playerShip)
    {
        //is powered up
        _poweredUp = true;

        ActivatePowerup(playerShip);

        //simulate disable
        DisableObject();

        //timer
        yield return new WaitForSeconds(_powerupDuration);

        //respawn powerup
        DeactivatePowerup(playerShip);
        EnableObject();

        _poweredUp = false;
    }

    void ActivatePowerup(PlayerShip playerShip)
    {
        if(playerShip != null)
        {
            particles.Play();

            //cameraPosition.AdjustCameraHeight(_cameraZoomOutDistance);

            playerShip.SetSpeed(_speedIncreaseAmount);

            playerShip.SetBoosters(true);
        }
    }

    void DeactivatePowerup(PlayerShip playerShip)
    {
        playerShip?.SetSpeed(-_speedIncreaseAmount);

        //cameraPosition?.AdjustCameraHeight(-_cameraZoomOutDistance);

        playerShip?.SetBoosters(false);
    }

    public void DisableObject()
    {
        _colliderToDeactivate.enabled = false;

        _visualsToDeactivate.SetActive(false);
    }

    public void EnableObject()
    {
        _colliderToDeactivate.enabled = true;

        _visualsToDeactivate.SetActive(true);
    }
}
