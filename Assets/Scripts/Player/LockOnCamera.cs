using UnityEngine;
using System.Collections;

public class LockOnCamera : MonoBehaviour {
    public GameObject target;
    public GameObject player;
    public Transform target2;

    public float dist = 5f;
    public float height = 6f;
	// Use this for initialization
	void Start () {
	
        if(player == null)
        {
           player = GameObject.Find("Player");
        }
        if(target ==null )
        {
            target = GameObject.Find("Enemy");
        }
    }
	
	// Update is called once per frame
	void Update () {
        Vector3 tPos = target.transform.position;
        Vector3 pPos = player.transform.position;
        Vector3 cPos = transform.position;
       tPos.y += height ;
       // pPos.z -= 10;
        pPos.y += height;

        float dx = tPos.x - pPos.x;
        float dy = tPos.y - pPos.y;
        float dz = tPos.z - pPos.z;
        //각각
        float a = dx * dx + dy * dy + dz * dz;
        float t = -dist/ Mathf.Sqrt((a));

        cPos.x = pPos.x + t * dx;
        cPos.y = pPos.y + t * dy;
        cPos.z = pPos.z + t * dz;

        transform.position = new Vector3(cPos.x, cPos.y,cPos.z);
        transform.LookAt(target2);
     // player.transform.LookAt(target2);
    }

}
