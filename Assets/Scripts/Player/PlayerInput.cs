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
       
	}

    void Movement(float x, float z)
    {
     
        if (_controler.onGround)
        {
            _controler.Move(x, z);
        }
   
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

}
