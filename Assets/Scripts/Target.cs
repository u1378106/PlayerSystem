using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Target : MonoBehaviour
{
    [SerializeField]
    private int currentHealth = 10;

    [SerializeField]
    private GameObject damageParticle;
    [SerializeField]
    private GameObject destroyParticle;
    [SerializeField]
    private Image healthBar;
    [SerializeField]
    private int damageAmount;



    private void OnCollisionEnter(Collision other)
    {
        GameObject _damageParticle = Instantiate(damageParticle, this.transform.position, Quaternion.identity);
        Destroy(other.gameObject);
        TakeDamage(damageAmount);
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        healthBar.fillAmount -= 0.1f;

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
