using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour {
    public GameObject projectile;
    public float projectileSpeed;
    public float timeToLive = 3f;

    public void FireProjectile()
    {
        GameObject projectileClone = Instantiate(projectile, transform.position, transform.rotation);        
        projectileClone.GetComponent<Rigidbody>().velocity = transform.forward * projectileSpeed;

        Physics.IgnoreCollision(gameObject.GetComponent<Collider>(), projectileClone.GetComponent<Collider>());

        Destroy(projectileClone, timeToLive);
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
