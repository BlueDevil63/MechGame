using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;

public class CustomizePlayer : MonoBehaviour {

   public void CustomHead()
    {

    }
   public void CustomBody()
    {

    }
   public void CustomArm()
    {


    }
   public void CustomLeg( string legPartname)
    {
        GameObject cPoint = CustomizeManager.instance.spawnPoint;
        Transform[] pChildren = CustomizeManager.instance.playerModelChildren;
        GameObject swapLegMesh = Instantiate( Resources.Load<GameObject>("Parts/" + legPartname),cPoint.transform.position, cPoint.transform.rotation) as GameObject;

        Transform[] swapChilds = swapLegMesh.GetComponentsInChildren<Transform>();
        List<Transform> destroyObjects = new List<Transform>();
        foreach(Transform sChild in swapChilds)
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
                    if(sChild.name =="Bip001 Pelvis")
                    {
                        pChild.transform.parent = sChild;
                    }
                }
            }
        }

        for(int i = 0; i<destroyObjects.Count; i++)
        {
            Destroy(destroyObjects[i].gameObject);
        }
        Destroy(swapLegMesh.gameObject);

    }
   public void CustomBackPack()
    {

    }

}
