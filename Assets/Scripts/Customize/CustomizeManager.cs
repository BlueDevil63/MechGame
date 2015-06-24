using UnityEngine;
using UnityEditor;
using System.Collections;

public class CustomizeManager : MonoBehaviour {
	// Use this for initialization

    public GameObject spawnPoint;
    public Transform[] playerModelChildren;
   // GameObject playerModel;
    public GameObject playerObject;
    public Transform target = null;
    public static Object emptyObj;
    public static CustomizeManager instance;
    CustomizePlayer Customizing;

    void Awake()
    {
        instance = this;
        Customizing = this.gameObject.AddComponent<CustomizePlayer>();
    }


	void Start () {
        GeneratePlayer();   
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.E))
        {
            GameObject prefabPlayer = GameObject.Find("Player");
            emptyObj = PrefabUtility.CreateEmptyPrefab("Assets/Resources/CPlayer.prefab");
            PrefabUtility.ReplacePrefab(prefabPlayer, emptyObj, ReplacePrefabOptions.ConnectToPrefab);
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            Customizing.CustomLeg("legPart5");
            StartCoroutine(SavePrefab());
        }
	}

    void GeneratePlayer()
    {
        spawnPoint = GameObject.Find("SpawnPoint");
        //플레이어의 형태를 불러옴
        GameObject playerObject = Resources.Load<GameObject>("Player");
        playerObject = Instantiate(playerObject, spawnPoint.transform.position, spawnPoint.transform.rotation) as GameObject;
        playerObject.name = "Player";
        // target = playerObject.transform;
        playerModelChildren = playerObject.GetComponentsInChildren<Transform>();
    }

    public IEnumerator SavePrefab()
    {
        GameObject prefabPlayer = GameObject.Find("Player");
        emptyObj = PrefabUtility.CreateEmptyPrefab("Assets/Resources/CPlayer.prefab");
        PrefabUtility.ReplacePrefab(prefabPlayer, emptyObj, ReplacePrefabOptions.ConnectToPrefab);
        // GameObject playerModel = GameObject.Find("Player");
        playerModelChildren = prefabPlayer.GetComponentsInChildren<Transform>();

        yield return null;
    }
}
