using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BattleMgr : DataTools {
    public static BattleMgr instance;
    public enum ObjectCategory { WALL, NOMAL, NOHOOK };

    public GameObject gameMenu;
    public bool activeMenu;
    GameObject spawnPoint;
    public GameObject playerObject;
    public Transform target = null;

    PlayerData _playerData;
    string _fileLocation;
    string loadData;

    void Awake()
    {
        instance = this;
    }

	// Use this for initialization
	void Start () {
        // Cursor.visible = false;
        //GeneratePlayer();
        _fileLocation = "Assets/Data";
        activeMenu = false;
        _playerData = new PlayerData();
        _playerData = LoadPlayerData(_playerData);
        playerObject.GetComponent<PlayerStatus>();
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

    PlayerData LoadPlayerData(PlayerData _pData)
    {
        loadData = LoadXML(loadData, "PlayerData.xml", _fileLocation);
        if (loadData.ToString() != "")
        {
            _pData = (PlayerData)DeserializeObject(loadData, "player");
        }
        return _pData;
    }

    PartData LoadPartData(PartData _pData)
    {
        loadData = LoadXML(loadData, "PartData.xml", _fileLocation);
        if (loadData.ToString() != "")
        {
            _pData = (PartData)DeserializeObject(loadData, "part");
        }
        return _pData;
    }

    void PlayerPartsLoad(PlayerData _data, PlayerStatus _status)
    {
        
    }
    void PlayerDeckLoad(PlayerData _data, PlayerStatus _status)
    {
        List<string> dummy = new List<string>();
        dummy = _data._user._IMDeck;
        for ( int i = 0; i<30; i++)
        {
        }       

    }
}
