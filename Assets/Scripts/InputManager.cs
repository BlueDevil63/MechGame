using UnityEngine;
using System.Collections;

public class InputManager : MonoBehaviour {
    public GameObject player;
    public float moveSpeed = 4.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        PlayerControl();
	
	}

    void PlayerControl()
    {
        if (Input.GetKey(KeyCode.W))
        {
            player.transform.Translate(0.0f, 0.0f, Time.deltaTime * 4.0f);
            Debug.Log("w");
        }
        if (Input.GetKey(KeyCode.A))
        {
            player.transform.Translate(Time.deltaTime * -4.0f, 0.0f, 0.0f);
        }
        if (Input.GetKey(KeyCode.S))
        {
            player.transform.Translate(0.0f, 0.0f, Time.deltaTime * -4.0f);
        }
        if (Input.GetKey(KeyCode.D))
        {
            player.transform.Translate(Time.deltaTime * 4.0f, 0.0f, 0.0f);
        }


    }
}
