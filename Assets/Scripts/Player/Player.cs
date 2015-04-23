using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
 
    public float hookRate;
    public enum PLAYERSTATE  {
        IDLE,
        RUN,
        JUMP,
        WALLJUMP,
        BUSTER,
        CLIMB,
        HOOKING,
        LATTACK,
        SATTACK,
        GUARD,
        DAMAGED
    }
    public PLAYERSTATE currentPlayerState;
    public PLAYERSTATE beforePlayState;
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
    public float pVelocity = 15.0f;             //다리속도 = 각파츠의 총합

    public float pHp = 100;                          //파츠의 총합
    public float pHpDamaged;
    //부스터용
    public float pBuster = 60.0f;                                   //백팩의 수치= 부스터의 속도
    public float pBssterRate = 15.0f;                                //부스터가 소비되는 단위
    public float pBusterCoolingRate = 10.0f;                         //쿨링시간
    public float pBusterGage  = 100.0f;                              //부스터의 총량          
   

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
        currentPlayerState = PLAYERSTATE.IDLE;
         isHooking = false;
         pHpDamaged = pHp;
       
   
    }

	// Update is called once per frame
	void Update () {
       if(Input.GetButton("UseInventory"))
       {
           UseInventory();
       }
       
 
    
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
    void UseInventory()
    {
        Debug.Log("useInvetory");
    }
    //플레이어가 피격당함
    void Ondemaged()
    {

    }
    
  

}
