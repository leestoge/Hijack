using UnityEngine;

public class WeaponSwitching : MonoBehaviour
{

    public int selectedWeapon;

	// Use this for initialization
	void Start ()
	{
	    SelectWeapon();
	}

    // Update is called once per frame
    void Update ()
    {
        int previousSelectedWeapon = selectedWeapon;

        if (Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            if (selectedWeapon >= transform.childCount - 1)
            {
                selectedWeapon = 0; // sword
            }
            else
            {
                selectedWeapon++; // 1 - machinegun, 2 - shotgun.
            }
        }

        if (Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            if (selectedWeapon <= 0)
            {
                selectedWeapon = transform.childCount - 1;
            }
            else
            {
                selectedWeapon--;
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha1)) // sword
        {
            selectedWeapon = 0;
            FindObjectOfType<AudioManager>().Play("equipSword");
        }

        if (Input.GetKeyDown(KeyCode.Alpha2) && transform.childCount >=2) // gun
        {
            selectedWeapon = 1;
            FindObjectOfType<AudioManager>().Play("equipGun");
        }

        if (Input.GetKeyDown(KeyCode.Alpha3) && transform.childCount >= 3) // shotgun
        {
            selectedWeapon = 2;
            FindObjectOfType<AudioManager>().Play("equipShotgun");
        }

        if (Input.GetKeyDown(KeyCode.Alpha4) && transform.childCount >= 4) // ??
        {
            selectedWeapon = 3;
        }

        if (previousSelectedWeapon != selectedWeapon)
        {
            SelectWeapon();
        }

        //if (selectedWeapon != 0)
        //{
        //    FindObjectOfType<AudioManager>().Play("equipSword");
        //}
        //if (selectedWeapon != 1) // not equal to works for some reason no idea why.
        //{
        //    FindObjectOfType<AudioManager>().Play("equipGun");
        //}
        //if (selectedWeapon != 2)
        //{
        //    FindObjectOfType<AudioManager>().Play("equipShotgun");
        //}
    }

    void SelectWeapon()
    {
        int i = 0;

        foreach (Transform weapon in transform)
        {
            if (i == selectedWeapon)            
            {
                weapon.gameObject.SetActive(true);
            }
            else
            {
                weapon.gameObject.SetActive(false);
            }
            i++;
        }
    }
}
