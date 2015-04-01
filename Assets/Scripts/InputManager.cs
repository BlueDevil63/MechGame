using UnityEngine;
using System.Collections;

public class InputManager : MonoBehaviour {
    public GameObject player;
    public float moveSpeed = 20.0f;
    bool isMoving;

	// Use this for initialization
	void Start () {
        isMoving = false;
	
	}
	
	// Update is called once per frame
	void Update () {
        PlayerControl();
	
	}

    void PlayerControl()
    {
        //방향키(십자키 제외)
        if (Input.GetKey(KeyCode.W))
        {
            if (Player.instance.isHooking == false)
            {
                isMoving = true;
                Player.instance.transform.Translate(0.0f, 0.0f, Time.deltaTime * moveSpeed);
                isMoving = player.GetComponent<Player>().Movement(isMoving);
                isMoving = player.GetComponent<Player>().Movement(isMoving);
            }
            else if(Player.instance.isHooking == true)
            {
                Player.instance.hookZ += 3;
            }
           // Debug.Log("w");
        }
        if (Input.GetKey(KeyCode.A))
        {
            if (Player.instance.isHooking == false)
            {
                isMoving = true;
                Player.instance.transform.Translate(Time.deltaTime * -moveSpeed, 0.0f, 0.0f);
                isMoving = player.GetComponent<Player>().Movement(isMoving);
                isMoving = player.GetComponent<Player>().Movement(isMoving);
            }
            else if (Player.instance.isHooking == true)
            {
                Player.instance.hookX -= 3;
            }

        }
        if (Input.GetKey(KeyCode.S))
        {
            if (Player.instance.isHooking == false)
            {
                isMoving = true;
                Player.instance.transform.Translate(0.0f, 0.0f, Time.deltaTime * -moveSpeed);
                isMoving = player.GetComponent<Player>().Movement(isMoving);
                isMoving = player.GetComponent<Player>().Movement(isMoving);
            }
            else if (Player.instance.isHooking == true)
            {
                Player.instance.hookZ -= 3;
            }

        }
        if (Input.GetKey(KeyCode.D))
        {
            if (Player.instance.isHooking == false)
            {
                isMoving = true;
                Player.instance.transform.Translate(Time.deltaTime * moveSpeed, 0.0f, 0.0f);
                isMoving = player.GetComponent<Player>().Movement(isMoving);
                isMoving = player.GetComponent<Player>().Movement(isMoving);
            }
            else if (Player.instance.isHooking == true)
            {
                Player.instance.hookX += 3;
            }
        }
        if(Input.GetKeyDown(KeyCode.F))
        {
            
        }


        //부스터(점프)-> 스페이스바
        //부스터 중 방향키 입력으로 이동, 
        //부스터 시간 제한
        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            //player.GetComponent<Player>().
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("space");
            player.GetComponent<Rigidbody>().velocity = new Vector3(0, 30, 0);
            player.GetComponent<Player>().jumping = true;
        }
        // hook
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {

        }
        if( Input.GetKeyDown(KeyCode.Mouse1))
        {

        }


    }
}
