using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidController : MonoBehaviour {

    public float appliedForce = 20f;
    void Start()
    {
        //The Asteroid Manager will handle all movement of the asteroids
        AsteroidsManager.Instance.RegisterAsteroid(gameObject);

        RadomizeDirection(transform.position);
    }

    private float nextActionTime = 0.0f;
    public float period = 2.0f;

    private GameObject enemyProjectile;

    void Update()
    {
        if (Time.time > nextActionTime)
        {
            nextActionTime += period;

            enemyProjectile = (GameObject)Instantiate(Resources.Load("EnemyProjectile"));
            FireProjectile();
        }
    }

    public float enemyProjectileSpeed = 1.5f;

    void FireProjectile()
    {
        enemyProjectile.GetComponent<Rigidbody>().position = transform.position;
        enemyProjectile.GetComponent<Rigidbody>().rotation = transform.rotation;
        enemyProjectile.GetComponent<Rigidbody>().velocity = transform.forward * enemyProjectileSpeed;
    }

    private void OnDestroy()
    {
        AsteroidsManager.Instance.UnregisterAsteroid(gameObject);
    }

    public void RadomizeDirection(Vector3 newPosition)
    {
        //newPosition.y = 0;
        transform.position = newPosition;
        transform.rotation = Quaternion.Euler(new Vector3(0, Random.Range(0, 360), 0));

        Vector3 newDirection = new Vector3(Random.Range(0f, 1f), 0, Random.Range(0f, 1f));
        newDirection.Normalize();

        //Caching the Rigid Body to avoid the slowness of getting it every time
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        rb.AddForce(newDirection * appliedForce);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
        }
    }
}
