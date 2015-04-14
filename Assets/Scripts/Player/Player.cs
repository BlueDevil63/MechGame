using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
 
    public float hookRate;

    //-------hook관련---

    public Vector3 hookPoint;               //hook이 충돌한 지점
    public bool isHooking;
  //  public int hookCount = 2;               //남은 hook의 개수
    /*차후 사용
   // float hookDist = 0.0f;
    //int hookPower;
   // float hookVelocity = 300;
     
     */
   //  Quaternion hookRotation;             //회전값
  //  float horizontal;                       //회전 상수
  //  bool hookdistB;                        //회전값을 계산했는지
   // public float hookDist;                      //hook과의 거리
    //당기기
    public bool hookPull = false;
   
    //플레이어 능력치
    int weight;
    int pPower;
    float pHp;                                //파츠의 총합
   public float pBuster = 60.0f;                             //백팩의 수치
    public float pVelocity = 15.0f;            //다리속도 = 각파츠의 총합
    /*
    //--------buster-------
    int busterPower;
    float busterVelocity;
    float coolingRate;
    //-----기타 개수 체크용-----
    int inventoryMemory;
    int optionModule;
    */
   public  CharacterController gController;
   public Animator _animator;
    public static Player instance;

    
    void Awake()
    {
        instance = this;
        _animator = GetComponent<Animator>();
        gController = GetComponent<CharacterController>();
    }

	// Use this for initialization
    void Start()
    {
        
         isHooking = false;
      //   Vector3 Angles = transform.eulerAngles;
        // horizontal = Angles.x;
       // isHooking = false;
      //  hookdistB = false;       
   
    }

	// Update is called once per frame
	void Update () {
       
   /*
        if (isHooking == true)
        {
            horizontal += Input.GetAxis("Horizontal") * 5;
            if(hookdistB != true )
            {
                hookDist = Vector3.Distance(hookPoint, transform.position);
                hookdistB = true;

            }
            if (Vector3.Distance(hookPoint, transform.position) < 0.5)
            {
                isHooking = false;
                Debug.Log("거리가 가까우므로 hook제거");
            }
            HookingRotation(horizontal, hookDist);
           //hookPull =  
               HookingPull(hookPull);
           // jumping = true;
        }  
        if(isHooking == false)
        {
          //  Vector3 Angles = transform.eulerAngles; 
             horizontal = 0;
            // vertical = 0;
        }
	
       // Jump(jumping);
       
      //  Movement(isMovig);
        */
    
	}
    void SumSatetus()
    {

    }
    void ShortAttack()
    {

    }
    //손및 기타 부분에 달린 장거리 무기의 사용
    void LongAttack()
    {
        _animator.SetBool("attack", true);
    }
    void useInventory()
    {

    }
    //플레이어가 피격당함
    void Ondemaged()
    {

    }
    /*
    //이동-애니메이션
   public void PMovement(bool isMovig)
    {

        if (isMovig)
            _animator.SetBool("run", true);
        else
       {
           _animator.SetBool("run", false);
       }
        //_animator.SetBool("run", false);
       //return false;s
    }
    //중력 함수 ----------------------------------------
   float PGravity(float moveDirectionY)
   {

       // Debug.Log(GController.isGrounded);
       // if(GController.isGrounded)
       // {
       //      moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
       //      moveDirection = transform.TransformDirection(moveDirection);
       //      moveDirection*=pVelocity;
       //     if(Input.GetButton("Jump"))
       //         moveDirection.y = jumpSpeed;
       // }
       moveDirection.y -= gravity * Time.deltaTime;
       // GController.Move(moveDirection * Time.deltaTime * 2);

       return moveDirectionY;
   }

    /// 점프 함수-------------------------------------------------------------------------------
   public float PJump(float moveDirectionY)
    {
        if  GController.isGrounded)
        {
            moveDirection.y = jumpSpeed;
         //   GController.Move(moveDirection * Time.deltaTime);
           // GetComponent<Rigidbody>().velocity = new Vector3(0, -9.8f*2, 0);
            Debug.Log("juming1");
          //  _animator.SetBool("jump", true);
           
                
        }

       jumping = false;
       return moveDirection.y;
    }
    Vector3 PWallJump(Vector3 moveDir)
   {
       if (jumping && wallJump)
       {
           //   moveDirection.z = pVelocity;
           //   moveDirection = transform.TransformDirection(moveDirection);
           moveDir.y= jumpSpeed;

           // GController.Move(moveDirection * Time.deltaTime);
           wallJump = false;
       }

       return moveDir;
   }
 

    //부스터의 사용
    void OnBuster()
    {
        
      //  busterOn = false;
    }
    */
    //근접공격

    //후크로 매달린 상태인가?
/*
 

    void HookingRotation(float x, float Hdist)
    {
        if (x != 0 && !hookPull)
        {
            Debug.Log("Rotate");
          //  Debug.Log(x);
            hookRotation = Quaternion.Euler(0, -x, 0);
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
        else if(hookPull)
        {
            HookingPull(hookPull);
        }
      }
    */
    //인벤토리메모리(왼쪽하단창)을 사용





    

}
