using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
    public static GameManager instance;
    public enum ObjectCategory { WALL, NOMAL, NOHOOK };

    public GameObject gameMenu;
    public bool activeMenu;
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
        //GeneratePlayer();
        activeMenu = false;
	}
	
	// Update is called once per frame
	void Update () {

        CursorVisible(activeMenu);
        if(Input.GetKeyDown(KeyCode.Escape) && (activeMenu == false))
        {
            gameMenu.SetActive(true);
            activeMenu = true;
        }
        else if(Input.GetKeyDown(KeyCode.Escape) && (activeMenu == true))
        {
            gameMenu.SetActive(false);
            activeMenu = false;
        }
	}
    public void RetireGame()
    {
        Application.LoadLevel("MapScene");
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
    void CursorVisible(bool activeMenu)
    {
        if(activeMenu == false)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        if(activeMenu == true)
        {
           // Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = true;
        }
    }
}
