using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;

public class MainMgr: DataTools {
	// Use this for initialization
    public PlayerData newPlayer;
    string _fileLocation;
    string _fileName;
    string _data;
    public GameObject menu;
    public GameObject newGame;
    public Animator openAni;
    private int m_OpenParameterId;
    private Animator m_Open;
    private GameObject m_PreviouslySelected;

    public Text playerName;


    const string k_OpenTransitionName = "Open";
    const string k_CloseStateName = "Close";

	void Start () {
        newPlayer = new PlayerData();
      _fileLocation = "Assets/Data";
      _fileName = "NewPlayerData.xml";
	}
	
	// Update is called once per frame
	void Update () {
       
	
	}
    public void OnEnable()
    {
        m_OpenParameterId = Animator.StringToHash(k_OpenTransitionName);

        if(openAni == null)
        {
            return;
        }
        
    }
    public void NewGame()
    {
        menu.SetActive(false);
        newGame.SetActive(true);
        //Application.LoadLevel("MapScene");
    }
    public void menuCancle()
    {
        menu.SetActive(true);
        newGame.SetActive(false);
    }
    public void menuAccept()
    {
        if (playerName.text != "")
        {
            newPlayer._user.name = playerName.text;
            newPlayer._user.money = 20000;
            newPlayer._user.energy = 10;
            newPlayer._user.food = 7;
            newPlayer._user.chapter = 0;
            newPlayer._user.residence = "Atena";
            newPlayer._user.location = "Atena";
            newPlayer._user.head = "Elpida Head";
            newPlayer._user.body = "Elpida Body";
            newPlayer._user.arm = "Elpida Arm";
            newPlayer._user.leg = "Elpida Leg";
            newPlayer._user.backpack = "Elpida BackPack";
            newPlayer._user.weapon1 = "ProtoGun";
            newPlayer._user.weapon2 = "none";

            _data = SerlializeObject(newPlayer, "player");
            CreateXML(_data, _fileName, _fileLocation);
            Application.LoadLevel("MapScene");
        }
    }


    public void Continue()
    {
        Application.LoadLevel("MapScene");
    }
    public void Option()
    {

    }
    public void Quit()
    {
       
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
             Application.Quit();
#endif

    }


   
}
