using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
 
    public float hookRate;
    //-----상태 체크------
    public bool jumping = false;
    public bool busterOn = false;
    public bool isHooking = false;
    //-------hook관련---

    public Vector3 hookPoint;               //hook이 충돌한 지점
    public int hookCount = 2;               //남은 hook의 개수
    /*차후 사용
   // float hookDist = 0.0f;
    //int hookPower;
   // float hookVelocity = 300;
     
     */
       Quaternion hookRotation;             //회전값
    float horizontal;                       //회전 상수
    bool hookdistB;                        //회전값을 계산했는지
    float hookDist;                      //hook과의 거리
    //당기기
    public bool hookPull = false;

   
    //------플레이어 관련-----
    public Vector3 moveDirection = Vector3.zero;
    public float gravity = 20.0f;
    float pVelocity = 10.0f;
    float jumpSpeed = 30.0f;
   // int weight;
  //  int pPower;
   // float pHp;                                  //파츠의 총합
    //float pBuster;                              //백팩의 수치
    /*
    //--------buster-------
    int busterPower;
    float busterVelocity;
    float coolingRate;
    //-----기타 개수 체크용-----
    int inventoryMemory;
    int optionModule;
    */
    Animator _animator;

    public static Player instance;

    
    void Awake()
    {
        instance = this;
        _animator = GetComponent<Animator>();
    }

	// Use this for initialization
    void Start()
    {
         Vector3 Angles = transform.eulerAngles;
         horizontal = Angles.x;
        isHooking = false;
        hookdistB = false;
   
    }

	
	// Update is called once per frame
	void Update () {
        PlayerMove();
   
        if (isHooking == true)
        {
         
            if(hookdistB != true )
            {
                hookDist = Vector3.Distance(hookPoint, transform.position);
                hookdistB = true;

            }
            horizontal += Input.GetAxis("Horizontal") *5;
         //   Debug.Log(horizontal);
            HookingRotation(horizontal, hookDist);

       
            if (Vector3.Distance(hookPoint, transform.position) < 0.5)
            {
                isHooking = false;
                Debug.Log("거리가 가까우므로 hook제거");
            }
            HookingPull(hookPull);
           // jumping = true;
        }  
        if(isHooking == false)
        {
          //  Vector3 Angles = transform.eulerAngles; 
             horizontal = 0;
            // vertical = 0;
        }
	
        Jump(jumping);
       
      //  Movement(isMovig);
    
	}
    void PlayerMove()
    {
        CharacterController GController = GetComponent<CharacterController>();
        Debug.Log(GController.isGrounded);
        if(GController.isGrounded)
        {
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection*=pVelocity;
            if(Input.GetButton("Jump"))
                moveDirection.y = jumpSpeed;
        }
        moveDirection.y -= gravity * Time.deltaTime;
        GController.Move(moveDirection * Time.deltaTime);
    }

    //이동-애니메이션
   public bool Movement(bool isMovig)
    {

        if (isMovig)
            _animator.SetBool("run", true);
        else
       {
           _animator.SetBool("run", false);
       }
        //_animator.SetBool("run", false);
       return false;
    }
    void Jump(bool jumping)
    {
      // jumping = true;
        if (jumping == true)
        {
            GetComponent<Rigidbody>().velocity = new Vector3(0, -9.8f*2, 0);
            Debug.Log("juming1");
        }
    }

    //부스터의 사용
    void OnBuster()
    {
        
        busterOn = false;
    }
    //근접공격
    void ShortAttack()
    {

    }
    //손및 기타 부분에 달린 장거리 무기의 사용
    void LongAttack()
    {

    }
    //후크로 매달린 상태인가?

    bool HookingPull(bool pull)
    {
                   
        if (pull == true)
        {
            Vector3 hookingShift = hookPoint - transform.position;
            //transform.GetComponent<Rigidbody>().velocity = hookingShift.normalized * 5;           
            transform.Translate(hookingShift.normalized*Time.deltaTime*30);
            Debug.Log("hooking");
           // jumping = true;
          
        }
       
        return false;
    }

    void HookingRotation(float x, float Hdist)
    {
        if (x != 0 && !hookPull)
        {
            Debug.Log("Rotate");
          //  Debug.Log(x);
            hookRotation = Quaternion.Euler(0, -x, 0);
            Vector3 hookPosition = hookPoint - hookRotation * Vector3.forward * Hdist;

            //transform.position = Vector3.Lerp(transform.position, hookPosition, Time.deltaTime * 3);
            transform.position= new Vector3(  Vector3.Lerp(transform.position, hookPosition, Time.deltaTime * 3).x, 0,  Vector3.Lerp(transform.position, hookPosition, Time.deltaTime * 3).z);
            // transform.position = Vector3.Lerp(transform.position, Vector3.down, Time.deltaTime * 3);
           // jumping = true;
           
        }
        else if(hookPull)
        {
            HookingPull(hookPull);
        }
      }
    //인벤토리메모리(왼쪽하단창)을 사용
    void useInventory()
    {

    }
    //플레이어가 피격당함
    void Ondemaged()
    {

    }

    

}
