using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
    public static GameManager instance;
    public enum ObjectCategory { WALL, NOMAL, NOHOOK };


    GameObject spawnPoint;
    public GameObject playerObject;
    public Transform target = null;
    void Awake()
    {
        instance = this;
       
    }

	// Use this for initialization
	void Start () {
       // Cursor.visible = false;
        GeneratePlayer();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void GeneratePlayer()
    {
        spawnPoint = GameObject.Find("SpawnPoint");
        //플레이어의 형태를 불러옴
        GameObject playerObject = Resources.Load<GameObject>("Player");
        playerObject = Instantiate(playerObject, spawnPoint.transform.position, spawnPoint.transform.rotation) as GameObject;
        playerObject.name = "Player";
       // target = playerObject.transform;
    }
}
