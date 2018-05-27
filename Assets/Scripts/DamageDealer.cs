using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : MonoBehaviour {

    public int damage;
    public string targetTag;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(targetTag))
        {
            ObjectLives objectLives = collision.gameObject.GetComponent<ObjectLives>();

            if(objectLives)
            {
                objectLives.DealDamage(damage);
            }
        }
    }
}
