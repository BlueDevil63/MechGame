using UnityEngine;
using System.Collections;

public class HookBullet : MonoBehaviour {
    public Vector3 hBulletPos;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	
	}

   void OnCollisionEnter(Collision coll)
   {
     //  if (coll.gameObject.GetComponent<MapObjcet>().objCategory == GameManager.ObjectCategory.WALL)
       if(coll.gameObject.tag == "WALL")
       {
           Debug.Log("col!!");
           // hBulletPos = coll.transform.position;
           GetComponent<Rigidbody>().
           transform.position = coll.transform.position;
           Player.instance.hookPoint = coll.transform.position;
           Player.instance.isHooking = true;
       }
   }

}
