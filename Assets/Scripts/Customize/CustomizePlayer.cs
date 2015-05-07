using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;

public class CustomizePlayer : MonoBehaviour {

    GameObject customPoint;
    GameObject playerModel;
    public static Object emptyObj;
    Transform[] playerModelChilds;
    string legName = "legPart2";
	// Use this for initialization
	void Start () {
        InitCustom();
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.L))
        {
             CustomLeg();
             GameObject prefabPlayer = GameObject.Find("Player");
             emptyObj = PrefabUtility.CreateEmptyPrefab("Assets/Resources/CPlayer.prefab");
             PrefabUtility.ReplacePrefab(prefabPlayer, emptyObj, ReplacePrefabOptions.ConnectToPrefab);
        }
          
	}
    void InitCustom()
    {
       customPoint = GameObject.Find("CustomPoint");
      //플레이어의 형태를 불러옴
       GameObject playerObject = Resources.Load<GameObject>("Player");
       playerModel = Instantiate(playerObject, customPoint.transform.position, customPoint.transform.rotation) as GameObject;
       playerModel.name = "Player";
       
       playerModelChilds = playerModel.GetComponentsInChildren<Transform>();

    }

    void CustomHead()
    {

    }
    void CustomBody()
    {

    }
    void CustomArm()
    {


    }
    void CustomLeg()
    {
        //파츠를 비교하기 위한 리스트 생성

        /*
        List<string> legPartNames = new List<string>();
        List<Mesh> legPartMeshs = new List<Mesh>();
       // List<SkinnedMeshRenderer> legPartMeshs = new List<SkinnedMeshRenderer>();
        //파츠를 비교하기 위한 리스트 대입
        foreach( Mesh partMesh in Resources.LoadAll("Parts/" + legName, typeof(Mesh)))
        {
            legPartMeshs.Add(partMesh);
            legPartNames.Add(partMesh.name);
        }
        Debug.Log("legPartMeshs.Count = " + legPartMeshs.Count);

        */

        

        GameObject swapLegMesh = Instantiate( Resources.Load<GameObject>("Parts/" + legName), customPoint.transform.position, customPoint.transform.rotation) as GameObject;
       // GameObject legMesh = GameObject.Find("Leg");
      //  Destroy(legMesh);
        Transform[] swapChilds = swapLegMesh.GetComponentsInChildren<Transform>();
        List<Transform> destroyObjects = new List<Transform>();
        foreach(Transform sChilds in swapChilds)
        {
          
            foreach (Transform pChilds in playerModelChilds)
            {
                if (pChilds.name == sChilds.name)
                {
                    if (pChilds.name == "Bip001 Pelvis")
                    {
                        sChilds.transform.parent = pChilds.transform.parent;
                        pChilds.name = "Old Bip001 Pelvis";
                        destroyObjects.Add(pChilds);
                    }
                    if (pChilds.name == "Leg")
                    {
                         sChilds.transform.parent = pChilds.transform.parent;
                         pChilds.name = "Old Leg";
                         destroyObjects.Add(pChilds);
                    }
                }
                if (pChilds.name == "Bip001 Spine")
                {
                    if(sChilds.name =="Bip001 Pelvis")
                    {
                        pChilds.transform.parent = sChilds;
                    }
                }
               // Debug.Log("Pchilds ame : " + pChilds.name);
            }
          //  Debug.Log("Schilds name : " + sChilds.name);
        }

        for(int i = 0; i<destroyObjects.Count; i++)
        {
            Destroy(destroyObjects[i].gameObject);
        }
        Destroy(swapLegMesh.gameObject);


   

    }
    void CustomBackPack()
    {

    }
}
