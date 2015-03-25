using UnityEngine;
using System.Collections;

public class InputManager : MonoBehaviour {
    public GameObject player;
    public float moveSpeed = 20.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        PlayerControl();
	
	}

    void PlayerControl()
    {
        //방향키(십자키 제외)
        if (Input.GetKey(KeyCode.W))
        {
            player.transform.Translate(0.0f, 0.0f, Time.deltaTime * moveSpeed);
           // Debug.Log("w");
        }
        if (Input.GetKey(KeyCode.A))
        {
            player.transform.Translate(Time.deltaTime * -moveSpeed, 0.0f, 0.0f);
        }
        if (Input.GetKey(KeyCode.S))
        {
            player.transform.Translate(0.0f, 0.0f, Time.deltaTime * -moveSpeed);
        }
        if (Input.GetKey(KeyCode.D))
        {
            player.transform.Translate(Time.deltaTime * moveSpeed, 0.0f, 0.0f);
        }
        if(Input.GetKeyDown(KeyCode.F))
        {
            
        }


        //부스터(점프)-> 스페이스바
        //부스터 중 방향키 입력으로 이동, 
        //부스터 시간 제한
        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            //player.GetComponent<Player>().
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
           // player.transform.Translate(0.0f, Time.deltaTime * 4.0f, 0.0f);
            player.GetComponent<Player>().jumping = true;
        }
        // hook
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {

        }
        if( Input.GetKeyDown(KeyCode.Mouse1))
        {

        }


    }
}
