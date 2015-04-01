﻿using UnityEngine;
using System.Collections;

public class TPSCamera : MonoBehaviour {
    public Transform target;

    public float rotateSpeed = 5;
    private  float cameraX;
    private float cameraY;

    private float lerpRate = 5.0f;
    private float zoomRate = 20;

    public float minZoomDistance = 5f;
    public float maxZommDistance = 10f;

    private float desireDistance;
    public float distance = 6.0f;

    private float currentDistance;
    private float correctedDistance;
    public float cameraTargetHeight = 5.0f;





	// Use this for initialization
	void Start () {

        Vector3 Angles = transform.eulerAngles;
        cameraX = Angles.x;
        cameraY = Angles.y;

        currentDistance = distance;
        correctedDistance = distance;
        desireDistance = distance;

	}
	
	// Update is called once per frame
	void LateUpdate () {

        cameraX += Input.GetAxis("Mouse X") * rotateSpeed;
        cameraY += Input.GetAxis("Mouse Y") * rotateSpeed;
        
      // if(Input.GetAxis("Vertical") !=0 || Input.GetAxis("Horizontal") != 0)
        if(Input.GetKeyDown(KeyCode.C))
       {
           float targetRotationAngle = target.eulerAngles.y;
           float CameraRotationAngle = transform.eulerAngles.y;
           cameraX = Mathf.Lerp(targetRotationAngle, CameraRotationAngle, lerpRate * Time.deltaTime);
        }
        // 원하는 거리 = 원하는거리 -  =  zoomrate * Mathf.Abs(desireDistance);
     //  desireDistance -=  zoomRate * Mathf.Abs(desireDistance);
     //  Debug.Log(desireDistance);
     //  desireDistance = Mathf.Clamp(desireDistance, minZoomDistance, maxZommDistance);
      // Debug.Log(desireDistance);
       correctedDistance = desireDistance;
       cameraY = ClampAngle(cameraY, -15, 25);
       Quaternion rotation = Quaternion.Euler(cameraY, cameraX, 0);
       Vector3 position = target.position - rotation * Vector3.forward * desireDistance;
       bool isCorrected = false;
       RaycastHit colisionHit;
       Vector3 cameraTargetPosition = new Vector3(target.position.x, target.position.y + cameraTargetHeight, target.position.z);

        if(Physics.Linecast(cameraTargetPosition, position, out colisionHit))
        {
            position = colisionHit.point;
            correctedDistance = Vector3.Distance( target.position, position);
            isCorrected = true;
           // Debug.Log("true");
        }

        currentDistance = !isCorrected || correctedDistance >  currentDistance ?Mathf.Lerp(currentDistance, correctedDistance, Time.deltaTime) : correctedDistance;
        position = target.position - (rotation * Vector3.forward * currentDistance + new Vector3(0, -cameraTargetHeight, 0));

        transform.rotation = rotation;
        transform.position = position;

        float targetCameraX = transform.rotation.x;
        target.eulerAngles = new Vector3(targetCameraX, transform.eulerAngles.y, transform.eulerAngles.z);

       

        
    }


    private static float ClampAngle( float value, float min, float max)
    {
        if (value > 360)
            value -= 360;
        if (value < -360)
            value += 360;


        return Mathf.Clamp(value, min, max);
    }
}