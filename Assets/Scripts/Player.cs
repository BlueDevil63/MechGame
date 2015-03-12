using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
    public Player instance;
    public GameObject hook;
    int hookCount = 2;
    public float hookDist = 0.0f;
    
	// Use this for initialization
    void Awake()
    {
        instance = this;
    }
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    //이동-애니메이션
    void Movement()
    {

    }
    //부스터의 사용
    void OnBuster()
    {

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
