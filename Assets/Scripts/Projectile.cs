using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] float lifeTime = 0f;
    [SerializeField] float speed = 0f;
    [SerializeField] AudioClip clip;
    private Rigidbody _rb;

    // Start is called before the first frame update
    void Awake()
    {
        //transform.rotation = transform.parent.rotation;
        _rb = GetComponent<Rigidbody>();
        AudioController.PlayClip(clip);
        _rb.AddForce(_rb.transform.forward * speed);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //_rb.AddForce(Vector3.forward * 15f);
        //transform.position += Vector3.forward * 1;
        lifeTime -= Time.deltaTime;
        if(lifeTime <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.name == "EnemyShip(Clone)")
        {
            other.GetComponent<EnemyController>().DisabeObject();
            Destroy(gameObject);
            //Destroy(other.gameObject);
        }
    }
}
