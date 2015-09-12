using UnityEngine;
using System.Collections;

public class ControllerTest : MonoBehaviour {

    CharacterController capController;
    Vector3 moveDirection;
    public float pVelocity = 15.0f;

    void Awake()
    {
        
    }

	// Use this for initialization
	void Start () {
        capController = GetComponent<CharacterController>();
    }
	
	// Update is called once per frame
	void Update () {
        capController.Move(moveDirection * Time.deltaTime);
        float x = 0;
        float z = 0;
        if(capController.isGrounded)
        {
            x += Input.GetAxis("Horizontal");
            z += Input.GetAxis("Vertical");
            moveDirection = new Vector3(x, 0, z);
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= pVelocity;

        }
      
        Debug.Log(capController.isGrounded);
    }
}
