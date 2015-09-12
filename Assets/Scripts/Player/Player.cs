using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player : MonoBehaviour {
 
    
     enum PLAYERSTATE  {
        IDLE,
        RUN,
        JUMP,
        WALLJUMP,
        BUSTER,
        CLIMB,
        HOOKING,
        LATTACK,
        SATTACK,
        PUNCH,
        GUARD,
        DAMAGED
    }
    PLAYERSTATE currentPlayerState;
    PLAYERSTATE beforePlayState;

    //-----벽 관련 상태 체크------
    enum wallDirection
    {
        NONE,
        LEFT,
        RIGHT,
        CLIMB
    }
    wallDirection wDir;
    //-------hook관련---

    /*
    public int hookCount = 2;               //남은 hook의 개수
    float hookDist = 0.0f;
   int hookPower;
    float hookVelocity = 300;
     
    
    Quaternion hookRotation;             //회전값
   float horizontal;                       //회전 상수
    bool hookdistB;                        //회전값을 계산했는지
   public float hookDist;                      //hook과의 거리
    */
    //
    //TPS에 의한 상체 회전
    public Transform[] bodySpineBone;



    //hook 관련변수
    public Vector3 hookPoint;       //hook이 충돌한 지점
    public float hookRate;
    public bool hookPull = false;   //당기기
    public bool isHooking = false;
   
    //플레이어 능력치
    public int pWeight;
    public int pPower;
    public float pVelocity = 15.0f;             //다리속도 = 각파츠의 총합

    public float pHp = 100;                          //파츠의 총합
    public float pHpDamaged;
    //-----부스터용
    public float pBoost;                                        //변화되는값
    public  float pBoostGage = 60.0f;                             //백팩의 수치= 부스터의 속도
    public float pBoostRate = 15.0f;                                //부스터가 소비되는 단위
    public float pBoostCoolingRate = 5.0f;                         //쿨링시간
   // public  float pBoosterGage  = 100.0f;                              //부스터의 총량          
    public float pBoostStateTime;
    //-----변수
    public bool jumping = false;
    public bool busterOn = false;
    public bool isMoving = false;
  
    bool hookWall = false;
    bool isGround = false;
 
    //관련 변수
    //------플레이어 관련-----
    public Vector3 moveDirection = Vector3.zero;
    //중력관련
    private Vector3 grav;
    private float gravity = 100.0f;

    private float jumpSpeed = 20.0f;
    //--------이펙트
    public GameObject boosterEffect;


    //-------컴포넌트
    CharacterController pController;
    Animator mAni;
    private CollisionFlags collisionFlags;
   

    //-----기타 개수 체크용-----
    public int selectMemory;
    public List<string> iMemorys  = new List<string>();
    //int optionModule;
    Vector3 inMemoryPoint;
    //IMData imStruct;
    public static Player instance;

    
    void Awake()
    {
        instance = this;
        mAni = GetComponent<Animator>();
        pController = GetComponent<CharacterController>();
    }

	// Use this for initialization
    void Start()
    {
        currentPlayerState = PLAYERSTATE.IDLE;
         isHooking = false;
         pHpDamaged = pHp;
         pBoost = pBoostGage;

         iMemorys.Add("memory0");
         iMemorys.Add("memory1");
         iMemorys.Add("memory2");
         iMemorys.Add("memory2");
        pController.Move(Vector3.zero);
    }
  
   void LateUpdate()
    {
        foreach(Transform spine in bodySpineBone)
        {
            spine.RotateAround(spine.position, transform.right, TPSCamera.instance.cameraY/bodySpineBone.Length);
        }
        
    }
   
    void Update()
    {
        
        beforePlayState = currentPlayerState;
        PMovement();
        if(Input.GetButton("Fire2"))
        {
          //  mAni.SetBool("punch", true);
           currentPlayerState = PLAYERSTATE.PUNCH;
            mAni.SetTrigger("punch");
        }
        AniController(currentPlayerState);
        if (busterOn == false)
        {
            if (pBoostStateTime < pBoostCoolingRate && pBoost== 0)
            {
                pBoostStateTime += Time.deltaTime / 2;
            }
            else
            {
                pBoost= BusterRating(pBoost, pBoostRate, pBoostCoolingRate, false);
                pBoostStateTime = 0;
            }
        }
        if (Input.GetButton("UseInventory"))
            UseInventory();
    }

    void ShortAttack()
    {

    }
    //손및 기타 부분에 달린 장거리 무기의 사용
    void LongAttack()
    {
        mAni.SetBool("attack", true);
    }
    void UseInventory()
    {
        inMemoryPoint = new Vector3(transform.position.x, transform.position.y, transform.localPosition.z + 4.0f);
        switch(selectMemory)
        {

            case 1:
                GameObject cube = Instantiate(Resources.Load<GameObject>("InventoryMemoryItem/iCube"),inMemoryPoint, transform.rotation) as GameObject;
                break;
            case 2:
                inMemoryPoint.y += 5;
                GameObject wall= Instantiate(Resources.Load<GameObject>("InventoryMemoryItem/iWall"),inMemoryPoint, transform.rotation) as GameObject;
                break;
            case 3:
                GameObject dummy =Instantiate(Resources.Load<GameObject>("InventoryMemoryItem/iDummy"),inMemoryPoint, transform.rotation) as GameObject;
                break;

        }
        Debug.Log("useInvetory number"+ selectMemory);
    }
    //플레이어가 피격당함
    void Ondemaged()
    {

    }

    // void Update()
    //// {
    //     
    //  }

    public void PMovement()
    {
        Debug.Log("isGrouded =" + pController.isGrounded);
        Debug.Log((IsGrounded()&&isGround) +" = ( 함수 "+ IsGrounded() +") * (변수" + isGround);
        float x = 0;
        float z = 0;

        //부스터 체크;

        if (Input.GetButton("BustOn") && pBoost > 0)  //"BustOn = left shift  버튼이 눌려있다면 액션
        {
            pBoost = BusterRating(pBoost, pBoostRate, pBoostCoolingRate, true);
            if (pBoost <= 0)
            {
               pBoost = 0;
                return;
            }
            x += Input.GetAxis("Horizontal");
            z += Input.GetAxis("Vertical");
            busterOn = true;
            if (x != 0 || x != 0)    //부스터 온 상태에서 방향키가 입력되면(임시적으로 y값 제외) 빠른 속도로 움직임 
            {
                moveDirection = new Vector3(x, 0, z);
                moveDirection = transform.TransformDirection(moveDirection);
                moveDirection *= pBoostGage;

            }
            else
            {
                moveDirection.y = PJumpBust(moveDirection.y, pBoostGage);
            }
            currentPlayerState = PLAYERSTATE.BUSTER;
            boosterEffect.SetActive(true);
        }

        else if (Input.GetButton("HookPull"))
        {
            busterOn = false;
            if (isHooking)
            {
                moveDirection = HookingPull(moveDirection);
            }
        }


        //지면에서의 움직임, 
       
   else if (pController.isGrounded)        //지면에 닿아있는지 체크
      // else if(IsGrounded()&&isGround)
        {
            busterOn = false;
            x += Input.GetAxis("Horizontal");
            z += Input.GetAxis("Vertical");
            moveDirection = new Vector3(x, 0, z);
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= pVelocity;
            if (Input.GetButton("Jump"))
            {
                moveDirection.y = PJumpBust(moveDirection.y, jumpSpeed);
                currentPlayerState = PLAYERSTATE.JUMP;
            }
            else if (x != 0 || z != 0)
            {
                currentPlayerState = PLAYERSTATE.RUN;
            }
            else if (x == 0 && z == 0)
            {
                currentPlayerState = PLAYERSTATE.IDLE;
            }
        }
        else if (Input.GetButton("Jump"))
        {

            busterOn = false;
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

            currentPlayerState = PLAYERSTATE.JUMP;
        }
        else
        {
            busterOn = false;
        }

        //부스터가 켜져있으면 중력이 작용하지 않음
        if (pBoost< 1)
        {
            busterOn = false;
        }
        if (!busterOn)
        {
            moveDirection.y = PGravity(moveDirection.y);
            boosterEffect.SetActive(false);

        }

        pController.Move(moveDirection * Time.deltaTime);

    }

    //중력 함수 ----------------------------------------
    float PGravity(float moveDirectionY)
    {
        moveDirectionY -= gravity * Time.deltaTime * 3;
        return moveDirectionY;
    }

    /// 점프 함수-------------------------------------------------------------------------------
    public float PJumpBust(float moveDirectionY, float jSpeed)
    {
        //if (pController.isGrounded)
        if(IsGrounded()&&isGround)
        {
            moveDirectionY += jSpeed;

        }
        return moveDirectionY;
    }
    //벽 짚고 점프 -----------------------------------------
    Vector3 PWallJump(Vector3 moveDir, wallDirection wallD)
    {
        if (wDir == wallDirection.LEFT)
        {
            moveDir = new Vector3(15, jumpSpeed, 15);
        }
        if (wDir == wallDirection.RIGHT)
        {
            moveDir = new Vector3(-15, jumpSpeed, 15);
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
        Vector3 directionR = transform.TransformDirection(Vector3.right);
        Vector3 directionL = transform.TransformDirection(Vector3.left);
        Vector3 directionUp = transform.TransformDirection(new Vector3(0, 1, 1));
        Vector3 directionDown = transform.TransformDirection(new Vector3(0, -1, 0));
        RaycastHit wallHit;
        // Rigidbody body = hit.collider.attachedRigidbody;
        if (hit.gameObject.tag == "WALL")
        {
            if (isHooking)
            {
                hookWall = true;
            }


            if (Physics.Raycast(transform.position, directionR, out wallHit, dist))
            {
                if (wallHit.transform.gameObject.tag == "WALL")
                {
                    wDir = wallDirection.RIGHT;
                }
            }
            if (Physics.Raycast(transform.position, directionL, out wallHit, dist))
            {
                if (wallHit.transform.gameObject.tag == "WALL")
                {
                    wDir = wallDirection.LEFT;
                }
            }
            if (Physics.Raycast(transform.position, directionL, out wallHit, dist * 6))
            {
                if (wallHit.transform.gameObject.name == "ClimbPoint")
                {
                    wDir = wallDirection.CLIMB;
                }
            }

        }
        else if (hit.controller.detectCollisions)
        {
            if (Physics.Raycast(transform.position, directionDown, out wallHit, dist / 10))
            {
                isGround = true;
            }

        }
        else
        {
            wDir = wallDirection.NONE;
            isGround = false;
        }
        // Vector3 wallJump = new Vector3(hit.moveDirection.x, 0, hit.moveDirection.z);
        // body.velocity = wallJump * jumpSpeed;
    }

    void AniController(PLAYERSTATE state)
    {
        switch (state)
        {
            case PLAYERSTATE.IDLE:
                if (beforePlayState == PLAYERSTATE.RUN)
                    mAni.SetBool("run", false);
                if (beforePlayState == PLAYERSTATE.JUMP)
                    mAni.SetBool("jump", false);
                if (beforePlayState == PLAYERSTATE.BUSTER)
                    mAni.SetBool("jump", false);
               // if (beforePlayState == PLAYERSTATE.PUNCH)
              //      mAni.SetBool("punch", false);
                mAni.SetBool("idle", true);
                break;
            case PLAYERSTATE.RUN:
                if (beforePlayState == PLAYERSTATE.IDLE)
                    mAni.SetBool("idle", false);
                if (beforePlayState == PLAYERSTATE.JUMP)
                    mAni.SetBool("jump", false);
                if (beforePlayState == PLAYERSTATE.BUSTER)
                    mAni.SetBool("jump", false);
               // if (beforePlayState == PLAYERSTATE.PUNCH)
               //     mAni.SetBool("punch", false);
                mAni.SetBool("run", true);
                break;
            case PLAYERSTATE.JUMP:
                if (beforePlayState == PLAYERSTATE.IDLE)
                    mAni.SetBool("idle", false);
                if (beforePlayState == PLAYERSTATE.RUN)
                    mAni.SetBool("run", false);
              //  if (beforePlayState == PLAYERSTATE.PUNCH)
               //     mAni.SetBool("punch", false);
                mAni.SetBool("jump", true);
                break;
            case PLAYERSTATE.BUSTER:
                if (beforePlayState == PLAYERSTATE.IDLE)
                    mAni.SetBool("idle", false);
                if (beforePlayState == PLAYERSTATE.RUN)
                    mAni.SetBool("run", false);
                if (beforePlayState == PLAYERSTATE.JUMP)
                    mAni.SetBool("jump", false);
               // if (beforePlayState == PLAYERSTATE.PUNCH)
                //    mAni.SetBool("punch", false);
                mAni.SetBool("jump", true);
                break;
                 
            case PLAYERSTATE.PUNCH:
               
                if (beforePlayState == PLAYERSTATE.IDLE)
                    mAni.SetBool("idle", false);
                if (beforePlayState == PLAYERSTATE.RUN)
                    mAni.SetBool("run", false);
                if (beforePlayState == PLAYERSTATE.JUMP)
                    mAni.SetBool("jump", false);
                if (beforePlayState == PLAYERSTATE.BUSTER)
                   mAni.SetBool("jump", false);
               // mAni.SetBool("punch", true);
                 
                break;

                
        }
    }
    float BusterRating(float bust, float bRate, float bCool, bool bustOn)
    {
        //float bustRateing = 0;

        if (bust <= pBoostGage && (bustOn == false))
        {
            if (bust == pBoostGage)
            {
                return bust;
            }
            bust += bCool / 2 * Time.deltaTime;
        }
        if (bust > 0 && (busterOn == true))
        {
            bust -= Time.deltaTime * 5 * bRate;

        }
        return bust;
    } 
    public bool IsGrounded()
    {
        return (CollisionFlags.CollidedBelow) != 0;
    }
  bool GroundHit()
    {
        float dist = 0.18f;
        RaycastHit hit;
        Vector2 startRay = transform.position;
        startRay.y += 4.0f;
        Vector3 directionDown = transform.TransformDirection(new Vector3(0, -1, 0));
        Debug.DrawRay(transform.position, directionDown* dist, Color.red );
        if (Physics.Raycast(startRay, directionDown, out hit, dist ))
        {

            return true;
        }
        else
        {
            return false;
        }
     

    }

}
