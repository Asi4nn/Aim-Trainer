using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetMovementController : MonoBehaviour
{
    public Rigidbody rb;

    private Vector3 initVel;

    public AudioClip spawn;

    private AudioSource hit;

    private void Start()
    {
        hit = GameObject.Find("FirstPersonController").GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        rb.AddForceAtPosition(initVel, transform.position, ForceMode.Impulse);
    }

    public void setInitVel(Vector3 vel)
    {
        initVel = vel;
        AudioSource.PlayClipAtPoint(spawn, gameObject.transform.position);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Projectile"))
        {
            hit.Play();
            gameObject.SetActive(false);
        }
        if (collision.gameObject.CompareTag("Environment"))
        {
            gameObject.SetActive(false);
        }
    }
}
