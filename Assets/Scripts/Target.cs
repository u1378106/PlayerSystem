using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField]
    private int currentHealth = 10;

    [SerializeField]
    private GameObject damageParticle;
    [SerializeField]
    private GameObject destroyParticle;



    private void OnCollisionEnter(Collision other)
    {
        GameObject _damageParticle = Instantiate(damageParticle, this.transform.position, Quaternion.identity);
        Destroy(other.gameObject);
        TakeDamage(10);
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;

        if (currentHealth <= 0)
        {
            GameObject _destroyParticle = Instantiate(destroyParticle, this.transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }

    internal void Stun(int seconds)
    {
        Debug.Log("Stun for : " + seconds);
    }

    internal void Freeze(int seconds)
    {
        Debug.Log("Frozen for : " + seconds);
    }
}
