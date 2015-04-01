using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
 
    public float hookRate;
    //-----상태 체크------
    public bool jumping = false;
    public bool busterOn = false;
    public bool isHooking = false;
    //-------hook관련---
   // public Transform hook0;
   // public Transform hook1;
   // public Transform hookSpawn0;
   // public Transform hookSpawn1;
    public Vector3 hookPoint;
    int hookCount = 2;
    float hookDist = 0.0f;
    int hookPower;
    float hookVelocity = 300;
     Quaternion hookRotation;
    public float hookX;
    public float hookY;
    public float hookZ;
   
    //------플레이어 관련-----
    Vector3 pPosition;
    int weight;
    float pVelocity;
    int pPower;
    float pHp;
    float pBuster;
    //--------buster-------
    int busterPower;
    float busterVelocity;
    float coolingRate;
    //-----기타 개수 체크용-----
    int inventoryMemory;
    int optionModule;

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
        hookX = 0;
        hookY = 0;
        hookZ = 0;
        isHooking = false;
    }

	
	// Update is called once per frame
	void Update () {

        if (isHooking == true)
            Hooking();
	
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
       
       return false;
    }
    void Jump()
    {
       jumping = true;
       Debug.Log("juming1");
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
    bool Hooking()
    {

        Vector3 position = transform.position - (hookRotation * Vector3.forward );
        if(Input.GetKey(KeyCode.LeftShift))
        {
            Vector3 hookingShift = hookPoint - transform.position;
            //GetComponent<Rigidbody>().velocity = hookingShift * 5;
            transform.Translate(hookingShift/30);
            Debug.Log("hooking");
        }

        return false;
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
