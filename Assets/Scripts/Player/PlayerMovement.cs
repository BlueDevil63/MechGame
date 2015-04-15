﻿using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {
    //변수
    //-----상태 체크------
    enum wallDirection
    {
        NONE,
        LEFT,
        RIGHT,
        CLIMB      
    }
    public bool jumping = false;
    public bool busterOn = false;
    public bool isMoving = false;
    public bool isHooking = false;
    bool hookPull = false;
    bool hookWall = false;
    wallDirection wDir;
    //관련 변수
    //------플레이어 관련-----
    public Vector3 moveDirection = Vector3.zero;
    public float gravity = 20.0f;
    float mVelocity;
    float mBust;
    float jumpSpeed = 20.0f;
    CharacterController pController;
    Animator mAni; 
	// Use this for initialization
    //hook 관련변수
    public Vector3 hookPoint;
    public static PlayerMovement instance;
    

    void Awake()
    {
        instance = this;
     //   pController = Player.instance.gController;
     
        
    }
    void Start()
    {
        mVelocity = Player.instance.pVelocity;
        mBust = Player.instance.pBuster;
        pController = Player.instance.gController;
        mAni = Player.instance._animator;
        wDir = wallDirection.NONE;
        
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        Player.instance.beforePlayState = Player.instance.currentPlayerState;
        PMovement();
        AniController(Player.instance.currentPlayerState);
	}
   // void Update()
   //// {
  //     
  //  }

    public void PMovement()
    {
        float x = 0;
        float z = 0;

        //부스터 체크;
        if (Input.GetButton("BustOn"))  //"BustOn = left shift  버튼이 눌려있다면 액션
        {
            busterOn = true;
            if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)    //부스터 온 상태에서 방향키가 입력되면(임시적으로 y값 제외) 빠른 속도로 움직임 
            {
                x += Input.GetAxis("Horizontal");
                z += Input.GetAxis("Vertical");
                moveDirection = new Vector3(x, 0, z);
                moveDirection = transform.TransformDirection(moveDirection);
                moveDirection *= mBust;
               // Player.instance.playState = Player.PLAYERSTATE.BUSTER;
            }
            else
            {
                moveDirection.y = PJumpBust(moveDirection.y, mBust);   
                
            }
            Player.instance.currentPlayerState = Player.PLAYERSTATE.BUSTER;
            Debug.Log("bustOn");
        }
        else if (Input.GetButton("HookPull"))
        {
            if (isHooking)
            {
                moveDirection = HookingPull(moveDirection);
            }
            Player.instance.currentPlayerState= Player.PLAYERSTATE.HOOKING;
        }
           //지면에서의 움직임, 
        else if (pController.isGrounded)        //지면에 닿아있는지 체크
            {
                busterOn = false;
                x += Input.GetAxis("Horizontal");
                z += Input.GetAxis("Vertical");
                  moveDirection = new Vector3(x, 0, z);
                 moveDirection = transform.TransformDirection(moveDirection);
                  moveDirection*=mVelocity;
                  if (Input.GetButton("Jump"))
                  {
                      moveDirection.y = PJumpBust(moveDirection.y, jumpSpeed);
                      Player.instance.currentPlayerState = Player.PLAYERSTATE.JUMP;
                  }
                  else if(x!= 0|| z != 0) 
                  {
                      Player.instance.currentPlayerState = Player.PLAYERSTATE.RUN;
                  }  
                  else
                  {
                      Player.instance.currentPlayerState = Player.PLAYERSTATE.IDLE;
                  }


             }
      
        else  if (Input.GetButton("Jump"))
            {           
                busterOn =false;
                if (wDir == wallDirection.LEFT)
                {
                    moveDirection = PWallJump(moveDirection, wDir);
                }
                else if (wDir == wallDirection.RIGHT)
                {
                    moveDirection = PWallJump(moveDirection, wDir);
                }
                wDir = wallDirection.NONE;
                jumping = true;

                Player.instance.currentPlayerState = Player.PLAYERSTATE.JUMP;
            }
        else
        {
            busterOn = false;
        }
            /*
        else
        {
           busterOn = false;
          
                jumping = false;
                Player.instance.currentPlayerState = Player.PLAYERSTATE.IDLE;
                //mAni.SetBool("run", false);
                //mAni
        }
        */
        //부스터가 켜져있으면 중력이 작용하지 않음
        if (!busterOn)
        {
            moveDirection.y = PGravity(moveDirection.y);
        }

        pController.Move(moveDirection * Time.deltaTime);
        //애니메이션
       /*
        if (x != 0 && z==0 && jumping==false)
        {
            if(x> 0)
            {
                mAni.SetBool("run", true);
                Debug.Log("run1" + x);
            }
            else if(x<0)
            {
                mAni.SetBool("run", true);
                Debug.Log("run2");
            }

        }
        else if(x != 0 || z!=0 &&jumping == false)
        {
            if (z > 0)
            {
                mAni.SetBool("run", true);
                Debug.Log("run3");
            }
            else if (z < 0)
            {
                mAni.SetBool("run", true);
                Debug.Log("run4");
            }
        }
        else if (x == 0 && z == 0&& pController.isGrounded)
        {
            mAni.SetBool("run", false);
            Debug.Log("Idle" +x +"   ,   " +z);
        }
        if (jumping)
        {
            mAni.SetBool("jump", true);
        }
        else { mAni.SetBool("jump", false); }
        */

        //_animator.SetBool("run", false);
        //return false;s
    }
    //중력 함수 ----------------------------------------
    float PGravity(float moveDirectionY)
    {
        moveDirectionY -= gravity * Time.deltaTime;
        return moveDirectionY;
    }

    /// 점프 함수-------------------------------------------------------------------------------
    public float PJumpBust(float moveDirectionY, float jSpeed)
    {
        if  (pController.isGrounded)
        {
            moveDirectionY += jSpeed;
            Debug.Log("juming1");                       
        }
       return moveDirectionY;
    }
    //벽 짚고 점프 -----------------------------------------
    Vector3 PWallJump(Vector3 moveDir, wallDirection wallD )
    {
        if(wDir == wallDirection.LEFT)
        { 
            moveDir =  new Vector3(10, jumpSpeed, 10);       
        }
        if (wDir == wallDirection.RIGHT)
        {
            moveDir = new Vector3(-10, jumpSpeed, 10);
        }

        moveDir = transform.TransformDirection(moveDir);
        return moveDir;
    }
    Vector3 HookingPull(Vector3 moveDir)
    {
        Vector3 hookingShift = hookPoint - transform.position;
        hookingShift *= 3;
        //transform.GetComponent<Rigidbody>().velocity = hookingShift.normalized * 5;             
        //transform.Translate(hookingShift.normalized*Time.deltaTime*30); 
        //pController.Move(hookingShift * Time.deltaTime * 6);
        Debug.Log("hooking");


        return hookingShift;
    }
   Vector3 HookingRotation(Vector3 movedir, float x, float z)
    {
       /*
        if (x != 0 && !hookPull)
        {
            Debug.Log("Rotate");
            //  Debug.Log(x);
            Quaternion hookRotation;   
            hookRotation = Quaternion.Euler(z, -x, 0);
            Vector3 hookPosition = hookPoint - hookRotation * Vector3.forward * Hdist;
            if (jumping)
            {
                transform.position = new Vector3(Vector3.Lerp(transform.position, hookPosition, Time.deltaTime * 3).x, jumpSpeed * Time.deltaTime, Vector3.Lerp(transform.position, hookPosition, Time.deltaTime * 3).z);
            }
            else
            {
                //transform.position = Vector3.Lerp(transform.position, hookPosition, Time.deltaTime * 3);
                transform.position = new Vector3(Vector3.Lerp(transform.position, hookPosition, Time.deltaTime * 3).x, 0, Vector3.Lerp(transform.position, hookPosition, Time.deltaTime * 3).z);
                // transform.position = Vector3.Lerp(transform.position, Vector3.down, Time.deltaTime * 3);
                // jumping = true;
            }

        }
       */
        return movedir;
      
    }
    //충돌체크 벽인지 아닌지
    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        float dist = 6.0f;
        // Rigidbody body = hit.collider.attachedRigidbody;
        if (hit.gameObject.tag == "WALL")
        {
            if(isHooking)
            {
                hookWall = true;
            }
            Vector3 directionR = transform.TransformDirection(Vector3.right);
            Vector3 directionL = transform.TransformDirection(Vector3.left);
            Vector3 directionUp = transform.TransformDirection(new Vector3(0, 1, 1));
            RaycastHit wallHit;
            Debug.Log("Wall");

            if (Physics.Raycast(transform.position, directionR, out wallHit, dist))
            {
                if (wallHit.transform.gameObject.tag == "WALL")
                {                 
                    Debug.Log("RightWall");
                    wDir = wallDirection.RIGHT;                  
                }
            }
            if (Physics.Raycast(transform.position, directionL, out wallHit, dist))
            {
                if (wallHit.transform.gameObject.tag == "WALL")
                {
                    Debug.Log("LeftWall");
                    wDir = wallDirection.LEFT;
                } 
            }
            if (Physics.Raycast(transform.position, directionL, out wallHit, dist*6))
            {
                if (wallHit.transform.gameObject.name == "ClimbPoint")
                {
                    Debug.Log("ClimbPoin");
                    wDir = wallDirection.CLIMB;
                }
            }
        }

        else { wDir = wallDirection.NONE; }
        // Vector3 wallJump = new Vector3(hit.moveDirection.x, 0, hit.moveDirection.z);
        // body.velocity = wallJump * jumpSpeed;
    }

    void AniController(Player.PLAYERSTATE state)
    {
        switch(state)
        {
            case  Player.PLAYERSTATE.IDLE :               
                if (Player.instance.beforePlayState == Player.PLAYERSTATE.RUN)
                    mAni.SetBool("run", false);
                if (Player.instance.beforePlayState == Player.PLAYERSTATE.JUMP)
                    mAni.SetBool("jump", false);
                mAni.SetBool("idle", true);
                break;
            case Player.PLAYERSTATE.RUN :                
                if (Player.instance.beforePlayState == Player.PLAYERSTATE.IDLE)
                    mAni.SetBool("idle", false);
                if (Player.instance.beforePlayState == Player.PLAYERSTATE.JUMP)
                    mAni.SetBool("jump", false);
                mAni.SetBool("run", true);
                break;
            case Player.PLAYERSTATE.JUMP:
                if (Player.instance.beforePlayState == Player.PLAYERSTATE.IDLE)
                    mAni.SetBool("idle", false);
                if (Player.instance.beforePlayState == Player.PLAYERSTATE.RUN)
                    mAni.SetBool("run", false);
                mAni.SetBool("jump", true);
                break;

        }
    }

    //HOOK 관련 함수
 
}
