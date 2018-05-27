using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidController : MonoBehaviour {

    public float appliedForce = 20f;
    public float angularSpeed = 5f;

    void Start()
    {
        //The Asteroid Manager will handle all movement of the asteroids
        AsteroidsManager.Instance.RegisterAsteroid(gameObject);

        RadomizeDirection(transform.position);
    }

    private float nextActionTime = 0.0f;
    public float shootingPeriod = 2.0f;

    void Update()
    {
        Shooter shooter = GetComponent<Shooter>();

        if(shooter)
        {
            if (Time.time > nextActionTime)
            {
                nextActionTime += shootingPeriod;

                shooter.FireProjectile();
            }
        }
    }

    private void OnDestroy()
    {
        AsteroidsManager.Instance.UnregisterAsteroid(gameObject);
    }

    public void RadomizeDirection(Vector3 newPosition)
    {
        transform.position = newPosition;
        transform.rotation = Quaternion.Euler(new Vector3(0, Random.Range(0, 360), 0));

        Vector3 newDirection = new Vector3(Random.Range(-1f, 1f), 0, Random.Range(-1f, 1f));
        newDirection.Normalize();

        //Caching the Rigid Body to avoid the slowness of getting it every time
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        rb.AddForce(newDirection * appliedForce);
        RandomizeAngularVelocity();
    }
    private void RandomizeAngularVelocity()
    {
        Rigidbody rigidBody = GetComponent<Rigidbody>();
        float rotationInRad = angularSpeed * Mathf.Deg2Rad;
        Vector3 angularVelocity = new Vector3(0f, Random.Range(-rotationInRad, rotationInRad), 0);
        rigidBody.angularVelocity = angularVelocity;
    }
}
