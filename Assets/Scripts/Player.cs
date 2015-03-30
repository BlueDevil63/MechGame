using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
 
    public float hookRate;
    //-----상태 체크------
    public bool jumping = false;
    public bool busterOn = false;
    public bool isHooking = false;
    //-------hook관련---
    public GameObject hook;
    public Transform hookSpawn0;
    public Transform hookSpawn1;
    public GameObject hookPoint;
    int hookCount = 2;
    float hookDist = 0.0f;
    int hookPower;
    float hookVelocity = 300;
   
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

    void Awake()
    {
        _animator = GetComponent<Animator>();
    }

	// Use this for initialization
    void Start()
    {

    }

	
	// Update is called once per frame
	void Update () {
     if(Input.GetKeyDown(KeyCode.F))
     {
         if (hookCount != 0)
         {
             if (hookCount < 2)
             { hookCount++; }

             Instantiate(hook, hookSpawn0.position, hookSpawn1.rotation);
             hookCount--;
         }
     }
	
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
    //근잡공격
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
