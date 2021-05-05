using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetMovementController : MonoBehaviour
{
    public Rigidbody rb;

    private Vector3 initVel;

    public AudioClip spawn;

    public AudioSource hit;

    private void Start()
    {
        AudioSource.PlayClipAtPoint(spawn, gameObject.transform.position);

        hit = GameObject.Find("FirstPersonController").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void setInitVel(Vector3 vel)
    {
        initVel = vel;
        rb.AddForceAtPosition(initVel, transform.position, ForceMode.Impulse);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Projectile"))
        {
            hit.Play();
            Destroy(gameObject);
        }
    }
}
