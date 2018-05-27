using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectLives : MonoBehaviour {

    private int health;

    public int publicHealth;

    public string objectType;

    public GameObject asteroidDebris;
    public int asteroidDebrisCount;

	// Use this for initialization
	void Start () {
        health = publicHealth;
	}
	
	public void DealDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            if (objectType.Equals("asteroid"))
            {
                for (int i = 0; i < asteroidDebrisCount; i++)
                {
                    Instantiate(asteroidDebris, transform.position, transform.rotation);
                }
            }

            Destroy(gameObject);
        }
    }
}
