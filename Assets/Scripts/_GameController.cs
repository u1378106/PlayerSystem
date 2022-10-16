//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.UI;

//public class _GameController : MonoBehaviour
//{
//    [SerializeField]
//    GameObject player;

//    [SerializeField]
//    private List<Image> weaponIcons;

//    [SerializeField]
//    private List<WeaponData> weaponSet;

//    int weaponIndex;

//    Color tempColor;

//    AudioManager audioManager;
//    private void Start()
//    {
//        audioManager = GameObject.FindObjectOfType<AudioManager>();

//        weaponSet = new List<WeaponData>();

//        player = this.gameObject;
//    }

//    private void OnCollisionEnter(Collision other)
//    {
//        if(other.gameObject.tag == "Fire")
//        {     
//            weaponIndex++;
//            weaponSet.Add(Resources.Load("Data/FirePower") as WeaponData);        
//            CheckForWeapon(weaponIndex, "FirePower");
//            Destroy(other.gameObject);
//        }

//        else if (other.gameObject.tag == "Ice")
//        {
//            weaponIndex++;
//            weaponSet.Add(Resources.Load("Data/IcePower") as WeaponData);    
//            CheckForWeapon(weaponIndex, "IcePower");
//            Destroy(other.gameObject);
//        }

//        else if (other.gameObject.tag == "Electricity")
//        {
//            //CheckForWeapon("ElectricPower");
//            weaponIndex++;
//            weaponSet.Add(Resources.Load("Data/ElectricPower") as WeaponData);
//            CheckForWeapon(weaponIndex, "ElectricPower");
//            Destroy(other.gameObject);
            
//        }
//    }

//    public void CheckForWeapon(int i, string weaponName)
//    {
//        audioManager.collect.Play();

//        weaponIcons[i - 1].sprite = Resources.Load<Sprite>("Icons/" + weaponName);
//        tempColor = weaponIcons[i-1].color;
//        tempColor.a = 0.7f;
//        weaponIcons[i - 1].color = tempColor;            
//    }

//        private void Update()
//    {
//        if(Input.GetKeyDown(KeyCode.Alpha1))
//        {
//            audioManager.weaponChange.Play();
//            player.GetComponent<Weapon>().weaponData = weaponSet[0];

//            tempColor.a = 1f;
//            weaponIcons[0].color = tempColor;

//            tempColor.a = 0.7f;
//            weaponIcons[1].color = tempColor;
//            weaponIcons[2].color = tempColor;
//        }

//        if (Input.GetKeyDown(KeyCode.Alpha2))
//        {
//            audioManager.weaponChange.Play();
//            player.GetComponent<Weapon>().weaponData = weaponSet[1];

//            tempColor.a = 1f;
//            weaponIcons[1].color = tempColor;

//            tempColor.a = 0.7f;
//            weaponIcons[0].color = tempColor;
//            weaponIcons[2].color = tempColor;
//        }

//        if (Input.GetKeyDown(KeyCode.Alpha3))
//        {
//             audioManager.weaponChange.Play();
//            player.GetComponent<Weapon>().weaponData = weaponSet[2];

//            tempColor.a = 1f;
//            weaponIcons[2].color = tempColor;

//            tempColor.a = 0.7f;
//            weaponIcons[0].color = tempColor;
//            weaponIcons[1].color = tempColor;
//        }
//    }
//}
