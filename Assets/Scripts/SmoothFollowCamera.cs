using UnityEngine;
using System.Collections;

public class SmoothFollowCamera : MonoBehaviour {

   // public float smooth = 1.0f;
    Transform _transform;
    public Transform targetObject;
    public float height = 4.0f;
    public float dist = 9.0f;
    public float damping = 6.0f;
    public float heightDamping = 2.0f;
    public float targtYPos = 2.0f;
    Vector3 lookAtTarget;

 

	// Use this for initialization
    void Awake()
    {
        _transform = transform;
     
        
    }
    void Start()
    {
       
        
    }

	void LateUpdate()
    {
        if (targetObject == null)
            return;
       
        Vector3 mousePose = Input.mousePosition;
        mousePose.x -= Screen.width / 2;
        mousePose.y -= Screen.height / 2;
        float dist2 = dist*dist;
        float roPositionX = _transform.position.x * transform.position.x;
        float roPositionY = _transform.position.y * transform.position.y;
        float roPositionZ = _transform.position.z * transform.position.z;
        float mMousePose = 2 * mousePose.x - mousePose.x * mousePose.x;
     
        
        float wantedHeight = targetObject.position.y + height; // 원하는 높이
        float currentHeight = transform.position.y;    //현재 카메라 높이
       
        currentHeight = Mathf.Lerp(currentHeight, wantedHeight, heightDamping * Time.deltaTime);
       // x-z평면에 대한 거리를 캐릭터 기준 뒤로 이동
        _transform.position = targetObject.position;
        _transform.position -= Vector3.forward * dist;
        //float wantedxXpos = targetObject.position.x - dist;
        //float currentXpos = transform.position.x;
       // currentXpos = Mathf.Lerp(currentXpos, wantedxXpos, mousePose.x * Time.deltaTime);

           

        //카메라 높이 설정
        Vector3 cameraPos = _transform.position;
        cameraPos.y = currentHeight;
       


        //카메라 회전

      //  cameraPos.x = ((dist2 - roPositionY - roPositionZ ) / (dist2 - roPositionY - roPositionZ + 2 ));//* (mousePose.x / 50);
        //cameraPos.y = ((dist2 - roPositionZ - roPositionX) / (dist2 - roPositionZ - roPositionX)) * (mousePose.y / 50);
        _transform.position = cameraPos;



        //카메라가 타겟을 보게 설정
        lookAtTarget = targetObject.position;
        lookAtTarget.y = lookAtTarget.y + targtYPos;

        transform.LookAt(lookAtTarget);

    //    Quaternion rotation = Quaternion.LookRotation(targetObject.position - _transform.position);
    //    _transform.rotation = Quaternion.Slerp(_transform.rotation, rotation, Time.deltaTime * damping);
        
        
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
