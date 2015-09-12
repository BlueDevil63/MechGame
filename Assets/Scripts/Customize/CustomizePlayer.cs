using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif
using System.Collections;
using System.Collections.Generic;

public class CustomizePlayer : MonoBehaviour {

    public GameObject swapPart;
    public GameObject player;
   public void CustomHead()
    {

    }
   public void CustomBody()
    {

    }
   public void CustomArm()
    {


    }
   public void CustomLeg( string legPartname, GameObject cPoint)
    {
        //붙일 파츠의 생성위치 지정
     
        //플레이어의 본 정보 입력
       
        player = GameObject.Find("Player");
        Transform[] pChildren = player.GetComponentsInChildren<Transform>();
        //교체 파츠 생성
        GameObject swapLegMesh = Instantiate( Resources.Load<GameObject>("Parts/" + legPartname),cPoint.transform.position, cPoint.transform.rotation) as GameObject;

        ///--추가 부분
        /// 
        SkinnedMeshRenderer[] BonedObject = swapLegMesh.GetComponentsInChildren<SkinnedMeshRenderer>();

        //교체 파츠의 본 정보
        Transform[] swapChilds = swapLegMesh.GetComponentsInChildren<Transform>();
        //교체되지 않은 부분을 제거하기 위한 리스트, 마지막에 모아서 제거
        List<Transform> destroyObjects = new List<Transform>();


        foreach (SkinnedMeshRenderer swapr in BonedObject)
        {
            swapPart = new GameObject(swapr.gameObject.name);
            swapPart.transform.parent = player.transform;
          
            SkinnedMeshRenderer newRenderer = swapPart.AddComponent(typeof(SkinnedMeshRenderer)) as SkinnedMeshRenderer;
            Transform[] myBone = new Transform[swapr.bones.Length];

            for (int i = 0; i <swapr.bones.Length; i++)
                myBone[i] = FindChildByName(swapr.bones[i].name, player.transform);
            /*
            foreach (Transform sChild in swapChilds)
            {

                foreach (Transform pChild in pChildren)
                {
                    if (sChild.name == "Bip001 Spine")
                        destroyObjects.Add(sChild);
                    
                    if (pChild.name == sChild.name)
                    {
                        if (pChild.name == "Bip001 Pelvis")
                        {
                            sChild.transform.parent = pChild.transform.parent;
                            pChild.name = "Old Bip001 Pelvis";
                            destroyObjects.Add(pChild);
                        }
                       
                       if (pChild.name == "Leg")
                        {
                            sChild.transform.parent = pChild.transform.parent;
                           pChild.name = "Old Leg";
                         destroyObjects.Add(pChild);
                       }
                     
                    }
                    if (pChild.name == "Bip001 Spine")
                    {
                        if (sChild.name == "Bip001 Pelvis")
                        {
                            pChild.transform.parent = sChild;
                        }
                   
                    }
                }
            }
            */
            newRenderer.bones = myBone;
            newRenderer.sharedMesh = swapr.sharedMesh;
            newRenderer.materials = swapr.materials;
            }
            foreach (Transform pChild in pChildren)
            {
                if (pChild.name == "Leg")
                {
                    destroyObjects.Add(pChild);
                }
            }
            for (int i = 0; i < destroyObjects.Count; i++)
            {
                Destroy(destroyObjects[i].gameObject);
            }
            Destroy(swapLegMesh.gameObject);
    
        


    }
   public void CustomBackPack()
    {

    }


    private void ProcessBonedObject( SkinnedMeshRenderer ThisRenderer)
    {
        player = GameObject.Find("Player");
        //서브 오브젝트 생성
        swapPart = new GameObject(ThisRenderer.gameObject.name);
        swapPart.transform.parent = player.transform;

        //렌더러 추가 
        SkinnedMeshRenderer newRenderer = swapPart.AddComponent(typeof(SkinnedMeshRenderer)) as SkinnedMeshRenderer;

        //합쳐진 본의 길이는 이 렌더러의 길이
        Transform[] myBone = new Transform[ThisRenderer.bones.Length];

        //뼈의 길이만큼 본을 찾음, 본의 이름을 통해 찾음
        for (int i = 0; i < ThisRenderer.bones.Length; i++)
            myBone[i] = FindChildByName(ThisRenderer.bones[i].name, player.transform);

        //렌더러 합치기
        newRenderer.bones = myBone;
        newRenderer.sharedMesh = ThisRenderer.sharedMesh;
        newRenderer.materials = ThisRenderer.materials;
    }
    private Transform FindChildByName(string ThisName, Transform ThisGObj)
    {
        Transform ReturnObj;

        // If the name match, we're return it
        if (ThisGObj.name == ThisName)
            return ThisGObj.transform;

        // Else, we go continue the search horizontaly and verticaly
        foreach (Transform child in ThisGObj)
        {
            ReturnObj = FindChildByName(ThisName, child);

            if (ReturnObj != null)
                return ReturnObj;
        }

        return null;
    }

}
