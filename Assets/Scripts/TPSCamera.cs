using UnityEngine;
using System.Collections;

public class TPSCamera : MonoBehaviour {
    public GameObject target;
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
        target.transform.Rotate(0, horizontal, 0);

        float desiredAngle = target.transform.eulerAngles.y;
        Quaternion rotation = Quaternion.Euler(0, desiredAngle, 0);
        transform.position = target.transform.position - (rotation * offset);

        transform.LookAt(target.transform);
    }
}
