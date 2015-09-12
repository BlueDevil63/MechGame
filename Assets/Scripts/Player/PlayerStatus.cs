using UnityEngine;
using System.Collections;

public class PlayerStatus : MonoBehaviour {

    //플레이어의 능력치
    public struct pStatus
    {
        public float hp;                                //체력
        public float velocity;                          //속도
        public float power;                             //출력, 힘
        public float Weight;                            //무게
        public float jumpPower;                         //점프력

        public float boostAmount;                        //부스트 양 
        public float boostTransfom;                     //부스트 변화값
        public float boostVelocity;                     //부스트의 속도
        public float boostRate;
        public float boostCoolinRate;
        public float boostStateTime;
    }

    public struct ExtraWeapon
    {
        //Head
        GameObject[] HeadExtra;
        //Body
        GameObject[] bodyExtra;
        //Arm
        GameObject[] ArmExtra;
        //Leg
        GameObject[] LegExtra;
        //BackBack
        GameObject[] BakcPackExtra;
    }


    public pStatus status;

    public GameObject booster;
    // Use this for initialization
    void Start () {

        status.velocity = 15;
        status.jumpPower = 30;
        status.boostVelocity = 50;
        status.hp = 100;

	}
	
	// Update is called once per frame
	void Update () {

	}
    void LoadPartsData()
    {

    }

    void CalculateParts()
    {

    }
    

 


}
