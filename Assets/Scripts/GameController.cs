using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [SerializeField]
    GameObject player;

    [SerializeField]
    private List<Image> weaponIcons;

    [SerializeField]
    private List<Weapon> weaponSet;

    int weaponIndex;

    Color tempColor;

    public Weapon currentPower;

    AudioManager audioManager;

    private FirePower firePower;

    private IcePower icePower;

    private ElectricPower electricPower;


    void Start()
    {
        player = this.gameObject;

        firePower = new FirePower();

        icePower = new IcePower();

        electricPower = new ElectricPower();

        weaponSet = new List<Weapon>();

        audioManager = GameObject.FindObjectOfType<AudioManager>();
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Fire")
        {
            weaponIndex++;
            weaponSet.Add(Resources.Load<Weapon>("Data/Fire"));
            CheckForWeapon(weaponIndex, "FirePower");
            Destroy(other.gameObject);
        }

        else if (other.gameObject.tag == "Ice")
        {
            weaponIndex++;
            weaponSet.Add(Resources.Load<Weapon>("Data/Ice"));
            CheckForWeapon(weaponIndex, "IcePower");
            Destroy(other.gameObject);
        }

        else if (other.gameObject.tag == "Electricity")
        {
            weaponIndex++;
            weaponSet.Add(Resources.Load<Weapon>("Data/Electric"));
            CheckForWeapon(weaponIndex, "ElectricPower");
            Destroy(other.gameObject);

        }
        else if (other.gameObject.tag == "BFG")
        {
            weaponIndex++;
            weaponSet.Add(Resources.Load<Weapon>("Data/BFG"));
            CheckForWeapon(weaponIndex, "BFGPower");
            Destroy(other.gameObject);

        }
    }

    public void CheckForWeapon(int i, string weaponName)
    {
        audioManager.collect.Play();

        weaponIcons[i - 1].sprite = Resources.Load<Sprite>("Icons/" + weaponName);
        tempColor = weaponIcons[i - 1].color;
        tempColor.a = 0.7f;
        weaponIcons[i - 1].color = tempColor;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            audioManager.weaponChange.Play();
            currentPower = weaponSet[0];

            tempColor.a = 1f;
            weaponIcons[0].color = tempColor;

            tempColor.a = 0.7f;
            weaponIcons[1].color = tempColor;
            weaponIcons[2].color = tempColor;
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            audioManager.weaponChange.Play();
            currentPower = weaponSet[1];

            tempColor.a = 1f;
            weaponIcons[1].color = tempColor;

            tempColor.a = 0.7f;
            weaponIcons[0].color = tempColor;
            weaponIcons[2].color = tempColor;
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            audioManager.weaponChange.Play();
            currentPower = weaponSet[2];

            tempColor.a = 1f;
            weaponIcons[2].color = tempColor;

            tempColor.a = 0.7f;
            weaponIcons[0].color = tempColor;
            weaponIcons[1].color = tempColor;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            this.GetComponent<Animator>().SetBool("isAttacking", true);
            StartCoroutine(Attacking());
        }
    }

    IEnumerator Attacking()
    {
        this.GetComponent<Animator>().SetBool("isAttacking", true);
        yield return new WaitForSeconds(0.3f);
        audioManager.shoot.Play();
        currentPower.Activate();
        yield return new WaitForSeconds(1f);
        this.GetComponent<Animator>().SetBool("isAttacking", false);
    }

}
