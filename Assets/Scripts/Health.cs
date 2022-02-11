using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int health = 100;
    [SerializeField] private GameObject deathVFX;
    [SerializeField] private float durationOfExplosion;
    public void DealDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            TriggerDeathVFX();
            Destroy(gameObject);
        }
    }

    private void TriggerDeathVFX()
    {
        GameObject explosion = Instantiate(deathVFX, transform.position, transform.rotation);
        Destroy(explosion, durationOfExplosion);
    }
}
