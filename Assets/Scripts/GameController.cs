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
    private List<WeaponData> weaponSet;

    int weaponIndex;

    private void Start()
    {
        weaponSet = new List<WeaponData>();

        player = this.gameObject;
    }

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Fire")
        {
            weaponIndex++;
            weaponSet.Add(Resources.Load("Data/FirePower") as WeaponData);        
            CheckForWeapon(weaponIndex, "FirePower");
            Destroy(other.gameObject);
        }

        else if (other.gameObject.tag == "Ice")
        {
            weaponIndex++;
            weaponSet.Add(Resources.Load("Data/IcePower") as WeaponData);    
            CheckForWeapon(weaponIndex, "IcePower");
            Destroy(other.gameObject);
        }

        else if (other.gameObject.tag == "Electricity")
        {
            //CheckForWeapon("ElectricPower");
            weaponIndex++;
            weaponSet.Add(Resources.Load("Data/ElectricPower") as WeaponData);
            CheckForWeapon(weaponIndex, "ElectricPower");
            Destroy(other.gameObject);
            
        }
    }

    public void CheckForWeapon(int i, string weaponName)
    {
        weaponIcons[i - 1].sprite = Resources.Load<Sprite>("Icons/" + weaponName);
        Color tempColor = weaponIcons[i-1].color;
        tempColor.a = 1f;
        weaponIcons[i - 1].color = tempColor;            
    }

        private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            player.GetComponent<Weapon>().weaponData = weaponSet[0];
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            player.GetComponent<Weapon>().weaponData = weaponSet[1];
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            player.GetComponent<Weapon>().weaponData = weaponSet[2];
        }
    }
}
