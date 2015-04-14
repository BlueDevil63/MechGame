using UnityEngine;
using System.Collections;

public class HookBullet : MonoBehaviour {
    public Vector3 hBulletPos;
    bool isColl = false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if(isColl)
        {
            Player.instance.hookPoint = transform.position;
        }
        //if(!isColl)
       // {
        //    transform.position = transform.position - Player.instance.transform.position;
           
       // }
        if(transform.position.y <= 0 || transform.position.y >= 40 )
        {
            Destroy(this);
        }
	
	}

   void OnCollisionEnter(Collision collision)
   {
       foreach (ContactPoint contact in collision.contacts)
       {
           if (collision.gameObject.tag == "WALL")
           {
               Debug.Log("col!!");
               Destroy(GetComponent<Rigidbody>());
               //대상 위치 = 충돌 위치;
               transform.position = collision.contacts[0].point;
               PlayerMovement.instance.hookPoint = transform.position;

               Debug.Log(Player.instance.hookPoint);
               PlayerMovement.instance.isHooking = true;
               isColl = true;

           }
           if (collision.gameObject.tag == "NOMALHOOK")
           {
               Debug.Log("col!!");
               Destroy(GetComponent<Rigidbody>());
               //대상 위치 = 충돌 위치;
               transform.position = collision.contacts[0].point;
               Player.instance.hookPoint = transform.position;
               Debug.Log(Player.instance.hookPoint);
               Player.instance.isHooking = true;
               isColl = true;

           }
       }
   }


}
