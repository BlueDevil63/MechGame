using UnityEngine;
using System.Collections;

public class WeaponSwitch : MonoBehaviour {

    public Transform weapon1;
    public Transform weapon2;
    public Transform bone;
    public Transform currentWeapon;
    //Quaternion rotation = Quaternion.EulerAngles(30, 0, 0);

	// Use this for initialization
	void Start () {
        currentWeapon = Instantiate(weapon1, bone.position, bone.rotation) as Transform;
        currentWeapon.parent = bone;
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButton("Fire2"))
        {
            if (currentWeapon != null)
            {
                if (currentWeapon.name == "weapon1(Clone)")
                {
                    removeCurrentWeapon(); currentWeapon = Instantiate(weapon2, bone.position, bone.rotation) as Transform;
                    currentWeapon.parent = bone;
                }
                else
                {
                    removeCurrentWeapon(); currentWeapon = Instantiate(weapon1, bone.position, bone.rotation) as Transform;
                    currentWeapon.parent = bone;
                }
            }
        }

	
	}
    void removeCurrentWeapon()
    {
        currentWeapon.parent = null;
        Destroy(currentWeapon.gameObject);

    }
}
