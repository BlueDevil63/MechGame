using UnityEngine;
using System.Collections;

public class TPSCamera : MonoBehaviour {
    public GameObject target;
    public GameObject targetHead;
    public float rotateSpeed = 4;
    Vector3 offset;


	// Use this for initialization
	void Start () {
        //타겟의 위치값 - 카메라의 위치값 
        offset = target.transform.position - transform.position;
	}
	
	// Update is called once per frame
	void LateUpdate () {
        float horizontal = Input.GetAxis("Mouse X") * rotateSpeed;
        float vertical = Input.GetAxis("Mouse Y") * (rotateSpeed/2);
        target.transform.Rotate(0, horizontal, 0);
        targetHead.transform.Rotate(vertical, 0, 0);

        float desiredAngle = target.transform.eulerAngles.y;
        float desiredAngle2 = targetHead.transform.eulerAngles.x;
        Quaternion rotation = Quaternion.Euler(0, desiredAngle, 0);
        Quaternion rotationHead = Quaternion.Euler(desiredAngle2, 0, 0);
        transform.position = target.transform.position - (rotation * offset);
        //offset = target.transform.position - transform.position;
        transform.position = targetHead.transform.position - (rotationHead * offset);

        transform.LookAt(target.transform);
    }
}
