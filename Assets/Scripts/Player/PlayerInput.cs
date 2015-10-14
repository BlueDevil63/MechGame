using UnityEngine;
using System.Collections;

public class PlayerInput : MonoBehaviour {

    PlayerControl _controler;
    
	// Use this for initialization
	void Start () {
        _controler = GetComponent<PlayerControl>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        _controler.GroundCheck();

        float x = 0;
        float z = 0;

        x += Input.GetAxis("Horizontal");
        z += Input.GetAxis("Vertical");

        Boost(x, z);

        if(_controler.onBoost ==false)
            Movement(x, z);
        //무기 사용 
        WeaponSelect();
        Attack();
        //인벤토리 메모리
        SelectInventoryMemory();
        UseInventoryMemory();
        //Hook
        Hook();

    }

    void Movement(float x, float z)
    {
      _controler.Move(x, z);
    }
    void Boost(float x, float z)
    {
        if(Input.GetButton("Jump"))
        {
            _controler.BoostMove(x, z, true);
        }
        else 
        {
            _controler.BoostMove(x, z, false);
        }
    }
    void WeaponSelect()
    {
        
        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {

        }
        else if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {

        }
    }
    void Attack()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _controler.MainWeaponAttack();
        }
        if (Input.GetMouseButtonDown(1))
        {
            _controler.SubWeaponAttack();
        }
        if (Input.GetMouseButtonDown(2))
        {
            _controler.WeaponSwap();
        }
    }

    void SelectInventoryMemory()
    {
        if(Input.GetAxis("SelectInventoryMemory") > 0)
        {

        }
        if( Input.GetAxis("SelectInventoryMemory") < 0)
        {

        }
    }
    void UseInventoryMemory()
    {
        if(Input.GetButton("UseInventoryMemory"))
        {

        }
    }

    void Hook()
    {
        if (Input.GetButton("HookShot"))
        {
            _controler.HookShot();
        }
        if (Input.GetButton("HookPull"))
        {
            _controler.HookPull();
        }
    }

}
