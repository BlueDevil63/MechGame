using UnityEngine;
using System.Collections;

public class SmoothFollowCamera : MonoBehaviour {

   // public float smooth = 1.0f;
    Transform _transform;
    public Transform targetObject;
    public float Height = 4.0f;
    public float dist = 7.0f;
    public float heightDamping = 2.0f;
    public float targtYPos = 2.0f;
    Vector3 lookAtTarget;
	// Use this for initialization
    void Awake()
    {
        _transform = transform;
     
        
    }

	void LateUpdate()
    {
        if (targetObject == null)
            return;
        float wantedHeight = targetObject.position.y + Height;
        float currentHeight = transform.position.y;

        currentHeight = Mathf.Lerp(currentHeight, wantedHeight, heightDamping * Time.deltaTime);
        //x-z평면에 대한 거리를 캐릭터 기준 뒤로 이동
        _transform.position = targetObject.position;
        _transform.position -= Vector3.forward * dist;

        //카메라 높이 설정
        Vector3 cameraPos = _transform.position;
        cameraPos.y = currentHeight;
        _transform.position = cameraPos;
        //카메라가 타겟을 보게 설정
        Vector3 lookAtTarget = targetObject.position;
        lookAtTarget.y = lookAtTarget.y + targtYPos;
        
        transform.LookAt(lookAtTarget);
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
