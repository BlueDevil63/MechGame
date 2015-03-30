using UnityEngine;
using System.Collections;

public class TPSCamera2 : MonoBehaviour {

    public Transform CameraTarget;
    private float x = 0.0f;
    private float y = 0.0f;

    private int mouseXSpeedMod = 5;
    private int mouseYSpeedMod = 5;

    public float MaxViewDistance = 15f;
    public float MinViewDistance = 1f;
    public int ZoomRate = 20;
    private int lerpRate = 5;
    private float distance = 3f;
    private float desireDistance;
    private float correctedDistance;
    private float currentDistance;

    public float cameraTargetHeight = 1.0f;

    //checks if first person mode is on
    private bool click = false;
    //stores cameras distance from player
    private float curDist = 0;

    // Use this for initialization
    void Start()
    {
        Vector3 Angles = transform.eulerAngles;
        x = Angles.x;
        y = Angles.y;
        currentDistance = distance;
        desireDistance = distance;
        correctedDistance = distance;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (Input.GetMouseButton(1))
        {/*0 mouse btn izq, 1 mouse btn der*/
            x += Input.GetAxis("Mouse X") * mouseXSpeedMod;
            y += Input.GetAxis("Mouse Y") * mouseYSpeedMod;
        }
        else if (Input.GetAxis("Vertical") != 0 || Input.GetAxis("Horizontal") != 0)
        {
            float targetRotantionAngle = CameraTarget.eulerAngles.y;
            float cameraRotationAngle = transform.eulerAngles.y;
            x = Mathf.LerpAngle(cameraRotationAngle, targetRotantionAngle, lerpRate * Time.deltaTime);
        }

        y = ClampAngle(y, -15, 25);
        //회전값
        Quaternion rotation = Quaternion.Euler(y, x, 0);
        //타겟과의 원하는 거리 계산

        desireDistance -= Input.GetAxis("Mouse ScrollWheel") * Time.deltaTime * ZoomRate * Mathf.Abs(desireDistance);
        desireDistance = Mathf.Clamp(desireDistance, MinViewDistance, MaxViewDistance);
        correctedDistance = desireDistance;
        //위치 = 타겟의 위치 - 회전된각 * vector3(0,0,1) * 원하는 거리
        Vector3 position = CameraTarget.position - (rotation * Vector3.forward * desireDistance);

        RaycastHit collisionHit;
        //타겟 위치 = (타겟의 위치x, 타겟의 위치y+ 원하는 높이값, 타겟의 위치z)
        Vector3 cameraTargetPosition = new Vector3(CameraTarget.position.x, CameraTarget.position.y + cameraTargetHeight, CameraTarget.position.z);

        bool isCorrected = false;
        //타겟(start)의 위치(end)가 충돌 여부
        //충돌할 경우 true를 반환
        if (Physics.Linecast(cameraTargetPosition, position, out collisionHit))
        {
            //충돌하면 카메라의 위치는 충돌한 부분
            position = collisionHit.point;
            //맞는 거리 = 타겟과 카메라의 거리
            correctedDistance = Vector3.Distance(cameraTargetPosition, position);
            
            isCorrected = true;
        }

        //?
        //condicion ? first_expresion : second_expresion;
        //(input > 0) ? isPositive : isNegative;
        //                      조건                      ?            참                                   :  거짓
        //조건이 참이면 참을 거짓이면 거짓을
        //맞는 거리 = (!맞았는지 or 맞는 거리 > 현재거리 )? (현거리와 맞는 거리사이를 델타 * 줌값으로 보간) : 맞는 거리
        currentDistance = !isCorrected || correctedDistance > currentDistance ? Mathf.Lerp(currentDistance, correctedDistance, Time.deltaTime * ZoomRate) : correctedDistance;
        //위치  = 타겟 - (회전값 * vector(0,0,1) * 현재거리  + Vector3( 0, -카메라의 높이, 0));
        position = CameraTarget.position - (rotation * Vector3.forward * currentDistance + new Vector3(0, -cameraTargetHeight, 0));
        //카메라 회전 = 회전값
        transform.rotation = rotation;
        //카메라 위치값 
        transform.position = position;

        //CameraTarget.rotation = rotation;

        float cameraX = transform.rotation.x;
        //checks if right mouse button is pushed
        if (Input.GetMouseButton(1))
        {
            //오른족 버튼
            //sets CHARACTERS x rotation to match cameras x rotation
            CameraTarget.eulerAngles = new Vector3(cameraX, transform.eulerAngles.y, transform.eulerAngles.z);
        }
        //checks if middle mouse button is pushed down
        if (Input.GetMouseButtonDown(2))
        {
            //가운데 버튼
            //if middle mouse button is pressed 1st time set click to true and camera in front of player and save cameras position before mmb.
            //if mmb is pressed again set camera back to it's position before we clicked mmb 1st time and set click to false
            if (click == false)
            {
                click = true;
                curDist = distance;
                distance = distance - distance - 1;
            }
            else
            {
                distance = curDist;
                click = false;
            }
        }

    }

    private static float ClampAngle(float angle, float min, float max)
    {
        if (angle < -360)
        {
            angle += 360;
        }
        if (angle > 360)
        {
            angle -= 360;
        }
        return Mathf.Clamp(angle, min, max);
    }
}
