using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerMovement : MonoBehaviour
{
    //public CharacterController controller;
    public Rigidbody rigid;
    public float speed = 12f;
    Vector3 velocity;
    public float gravity = -9.81f;
    public float jumpHeight = 10f;
    public float maxhealth, curHealth, ammoCount, totalAmmo;
    public Slider health, ammo;
    private bool grounded;
    #region Game Mode
    [SerializeField] int playersTeamID;
    public int TeamID { get { return playersTeamID; } }

    Rigidbody playerrigidbody;
    #endregion
    #region weapons
    public List<Weapon> weapons;
    int currentWeapon = 0;
    int lastWeapon = 0;
    public Vector2 dropoffset;
    public Text text;
    #endregion
    // Start is called before the first frame update
    void Start()
    {
        maxhealth = 100f;
        curHealth = maxhealth;
        foreach (Weapon weapon in weapons)
        {
            //weapon.gameObject.SetActive(false);
        }
        SwitchWeapon(currentWeapon);
    }
    public void SwitchWeapon(int weaponID, bool overrideLock = false)
    {
        if (!overrideLock && weapons[currentWeapon].isWeaponLocked == false)
        {
            return;
        }
        lastWeapon = currentWeapon;
        currentWeapon = weaponID;
        //text = weapons[currentWeapon].
    }
    public void PickUpWeapon(GameObject weaponObject, Vector3 originalLocation, int teamId, int weaponID, bool overrideLock = false)
    {
        SwitchWeapon(weaponID, overrideLock);
        weapons[weaponID].SetUp(teamId, weaponObject, originalLocation);
    }
    public void ReturnWeapon(int weaponID)
    {
        if (weapons[weaponID].isWeaponDropable)
        {
            Vector3 returnLocation = weapons[weaponID].originalLocation;
            weapons[weaponID].worldWeaponsGameObject.transform.position = returnLocation;
            weapons[weaponID].worldWeaponsGameObject.SetActive(true);
            SwitchWeapon(lastWeapon, true);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "ground")
        {
            grounded = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "ground")
        {
            grounded = false;
        }
    }
    // Update is called once per frame
    void Update()
    {
       
        if (health.value != curHealth/maxhealth)
        {
            health.value = curHealth / maxhealth;
        }
        if (ammo.value != ammoCount/totalAmmo)
        {
            ammo.value = ammoCount / totalAmmo;
        }
        
        if (grounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        velocity.x = Input.GetAxis("Horizontal");
        velocity.z = Input.GetAxis("Vertical");

        
        
        if (Input.GetKeyDown(KeyCode.J) && grounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
        velocity.y += gravity * Time.deltaTime;
        rigid.AddForce(velocity * Time.deltaTime);
    }
    private void FixedUpdate()
    {
        Vector3 move = transform.right * velocity.x + transform.forward * velocity.z;
        rigid.AddForce(move * speed * 10);
    }
    public bool IsHolding(int weaponID)
    {
        if (currentWeapon == weaponID)
        {
            return true;
        }
        return false;
    }
    public int GetWeaponTeamID()
    {
        return weapons[currentWeapon].teamID;
    }
}
