using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public WeaponData weaponData;

    [SerializeField]
    private Transform weaponModelTransformParent;

    private GameObject model;

    private void OnEnable()
    {
        //if (model != null)
        //    Destroy(model);

        if(weaponData.weapon != null)
        {
            //model = Instantiate(weaponData.model);
            //model.transform.SetParent(weaponModelTransformParent, false);
        }
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            this.GetComponent<Animator>().SetBool("isAttacking", true);
            StartCoroutine(Attacking());
        }

        if (Input.GetKey(KeyCode.W))
        {
            this.GetComponent<Animator>().SetBool("isWalking", true);
            //StartCoroutine(Attacking());
        }
        else if (Input.GetKeyUp(KeyCode.W))
        {
            this.GetComponent<Animator>().SetBool("isWalking", false);
            //StartCoroutine(Attacking());
        }
    }

    IEnumerator Attacking()
    {

        this.GetComponent<Animator>().SetBool("isAttacking", true);
        yield return new WaitForSeconds(0.3f);
        AttackNow();
        yield return new WaitForSeconds(1f);
        this.GetComponent<Animator>().SetBool("isAttacking", false);
    }

    public void AttackNow()
    {
        GameObject projectile = Instantiate(weaponData.weapon, this.transform.position, Quaternion.identity);
        //GameObject particle = Instantiate(weaponData.particleEffect, projectile.transform);
        GameObject trail = Instantiate(weaponData.weaponTrailEffect, projectile.transform);
        projectile.GetComponent<Rigidbody>().AddForce(transform.forward * 1000);
    }

    public void Attack(Target target)
    {
        if (weaponData.Damage > 0)
            target.TakeDamage(weaponData.Damage);

        if (weaponData.stunDuration > 0)
            target.Stun(weaponData.stunDuration);

        if (weaponData.freezeDuartion > 0)
            target.Freeze(weaponData.freezeDuartion);

        string message = string.IsNullOrEmpty(weaponData.message) ? "hit" : weaponData.message;
            Debug.Log("You " + message + "" + target.name);
    }
}
