using UnityEngine;
using System.Collections;

public class WeaponManager : MonoBehaviour {

    public bool createWeapon = false;
    public GameObject defaultWeapon;

    private GameObject activeWeapon;
    public Shotgun weapon;

	// Use this for initialization
	void Start () {
        if (createWeapon)
        {
            activeWeapon = GameObject.Instantiate(defaultWeapon, Camera.main.transform.position, Camera.main.transform.rotation) as GameObject;
            activeWeapon.transform.SetParent(Camera.main.transform);
        }
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Fire1"))
        {
            if (weapon != null)
            {
                print("here");
                weapon.Fire();
            }
            else
                print("weapon is null");
        }
	}
}
