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
        if(!isColl)
        {
            transform.position = transform.position - Player.instance.transform.position;
           
        }
        if(transform.position.y <= 0 || transform.position.y >= 40 )
        {
            Destroy(this);
        }
	
	}

   void OnCollisionEnter(Collision coll)
   {
         if(coll.gameObject.tag == "WALL")
       {
           Debug.Log("col!!");
           Destroy(GetComponent<Rigidbody>());   
           //대상 위치 = 충돌 위치;
           transform.position = coll.contacts[0].point;
           Player.instance.hookPoint = transform.position;
     
           Debug.Log(Player.instance.hookPoint);
           Player.instance.isHooking = true;
           isColl = true;

       }
   }

}
