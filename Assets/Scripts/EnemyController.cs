using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    private Transform target;

    [SerializeField] GameObject art;
    [SerializeField] ParticleSystem particles;

    [SerializeField] AudioClip clip;

    private BoxCollider boxCollider;

    // Start is called before the first frame update
    void Awake()
    {
        boxCollider = GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<NavMeshAgent>().SetDestination(target.position);
        if(PlayerShip.playerState != PlayerShip.PlayerState.PLAYING)
        {
            Destroy(gameObject);
        }
    }

    public void SetTarget(Transform player)
    {
        target = player;
    }

    public void DisabeObject()
    {
        art.SetActive(false);
        boxCollider.enabled = false;

        AudioController.PlayClip(clip);

        particles.Play();
    }

    private void OnTriggerEnter(Collider other)
    {
        PlayerShip playerShip = other.gameObject.GetComponent<PlayerShip>();

        if (playerShip != null)
        {
            DisabeObject();
        }
    }
}
