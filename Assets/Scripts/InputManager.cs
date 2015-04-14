using UnityEngine;
using System.Collections;

public class InputManager : MonoBehaviour {
    public GameObject player;
    public float moveSpeed = 20.0f;
    //bool isMoving;

	// Use this for initialization
	void Start () {
       //isMoving = false;
	
	}
	
	// Update is called once per frame
	void Update () {
       PlayerControl();
	
	}

    void PlayerControl()
    {
        /*
              // if(Input.GetKey(KeyCode.None))
               if (!(Input.GetKey(KeyCode.W)) 
                   && !(Input.GetKey(KeyCode.A))
                   && !(Input.GetKey(KeyCode.S))
                   && !(Input.GetKey(KeyCode.D)))
               {
                   Player.instance.isMoving = false;
               }
               //방향키(십자키 제외)
               if (Input.GetKey(KeyCode.W))
               {
            
                   if (Player.instance.isHooking == false)
                   {
                       Player.instance.isMoving = true;
                       Player.instance.transform.Translate(0.0f, 0.0f, Time.deltaTime * moveSpeed);
                     //  Player.instance.isMoving = false;
                   }
                
                  if(Player.instance.isHooking == true)
                   {
                     //  Player.instance.keyDowns = true;
                   }
                  // Debug.Log("w");
               }
       //
               //------------------------------------
               if (Input.GetKey(KeyCode.A))
               {
            
                   if (Player.instance.isHooking == false)
                   {
                      // isMoving = true;
                       Player.instance.isMoving = true;
                       Player.instance.transform.Translate(Time.deltaTime * -moveSpeed, 0.0f, 0.0f);
                     // isMoving = player.GetComponent<Player>().Movement(isMoving);
                     // player.GetComponent<Player>().Movement(isMoving);
                   }
                
                   if (Player.instance.isHooking == true)
                   {
                      // Player.instance.keyDowns = true;
                   }

               }
       //---------------------------------------------------------------------------
               if (Input.GetKey(KeyCode.S))
               {
            
                   if (Player.instance.isHooking == false)
                   {
                       //isMoving = true;
                       Player.instance.isMoving = true;
                       Player.instance.transform.Translate(0.0f, 0.0f, Time.deltaTime * -moveSpeed);
                       //isMoving = player.GetComponent<Player>().Movement(isMoving);
                      // player.GetComponent<Player>().Movement(isMoving);
                   }
               
                   if (Player.instance.isHooking == true)
                   {
                     //  Player.instance.keyDowns = true;
                   }

               }
       //----------------------------
               if (Input.GetKey(KeyCode.D))
               {   
                   if (Player.instance.isHooking == false)
                   {
                      // isMoving = true;
                       Player.instance.isMoving = true;
                       Player.instance.transform.Translate(Time.deltaTime * moveSpeed, 0.0f, 0.0f);
                      // isMoving = player.GetComponent<Player>().Movement(isMoving);
                       //player.GetComponent<Player>().Movement(isMoving);
                   }
            
                   if (Player.instance.isHooking == true)
                   {
                      // Player.instance.keyDowns = true;
                   }
               }

               //부스터(점프)-> 스페이스바
               //부스터 중 방향키 입력으로 이동, 
               //부스터 시간 제한

       //---------------------------------------------------------------------------------------------------------
               if(Input.GetKeyDown(KeyCode.Space))
               {
                   bool jumping = true;
                   Player.instance.Jump(jumping);
                   //player.GetComponent<Player>().
               }
               
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            Debug.Log("buster");
            Player.instance.busterOn = true;
            // Player.instance.transform.Translate(0, 10 * Time.deltaTime, 0);
            // Player.instance.jumping = true;



            // player.GetComponent<Rigidbody>().velocity = new Vector3(0, 30, 0);
            // player.GetComponent<Player>().jumping = true;
        }


        // hook
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {

        }
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {

        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            if (Player.instance.isHooking == true)
            {
                if (Player.instance.hookPull == false)
                {
                    Player.instance.hookPull = true;
                }
                else
                {
                    Player.instance.hookPull = false;
                    if (Player.instance.hookDist <= 10)
                    { Player.instance.isHooking = false; }
                }
            }
        }*/
    }
    
}
