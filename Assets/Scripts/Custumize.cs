using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Custumize : MonoBehaviour
{
    public string modelDir = "Elpida_unity14";
    //public string modelDir = "Body0";
    public GameObject playerObject;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
            ChangePart();
    }
    //플레이어
    // -> 조립할 데이터 생성(플레이어의 위치에 생성)
    //-> 파츠, 본을 리스트에 채움)    -- 파츠는 폴더에서 불러오고, 본은 생성된 데이터채움
    //-> 
    //type in the folder that contains the exported bodypart meshes
    // 익스포트한 바디파츠 매쉬를 타입을 폴더안에서 파일 이름;
    public void ChangePart()
    {
        //There has to be a gameobject called "PlayerStart" somewhere in the scene as an indicator of where the player will start
        GameObject playerStart = GameObject.Find("PlayerStart");
        Debug.Log("find the PlayerStart");
        //현재 플레이어 위치를 호출

        //playerStart.GetComponent<MeshRenderer>().enabled = false;
      // playerStart.GetComponent<BoxCollider>().enabled = false;


        //instantiate the player object. 
        //플레이어 오브젝트를 생성
        //This would be the empty skeleton with all script like damage, weapon data etc. attached, as well as physics stuff 
        // 이것은 빈 스켈리톤을 생성할것이다. 
        //(or you could give each body paert it's own collider and rigidbody)
        GameObject newPlayer = Instantiate(playerObject, playerStart.transform.position, playerStart.transform.rotation) as GameObject;
        newPlayer.name = playerObject.name;


        //declare two lists: one that contains the meshes, and one that has the cooresponding names so they can be attached to the right bones. It's important that each bone that will receive a boydpart is named like it's mesh, with "Bone" added! This can of course be changed to your specifications.
        List<string> bodyPartNames = new List<string>();
        List<Mesh> bodyPartMeshes = new List<Mesh>();

        Mesh[] Part = Resources.LoadAll<Mesh>("Parts/" + modelDir);
        foreach(Mesh mesh in Part)
        {
            Debug.Log("Loaded Mesh" + mesh.name);
        }


        //Fill the bodypart lists
        //바디파츠의 리스트를 채운다.
        //Resources.LoadAll("폴더" + 이름, 타입);
       // foreach (Mesh mesh in Resources.LoadAll("Models/Actors/" + modelDir, typeof(Mesh)))//
        /*
        foreach(Mesh mesh in Resources.LoadAll("Parts/" + modelDir, typeof(Mesh)))
        {
            bodyPartMeshes.Add(mesh);
            bodyPartNames.Add(mesh.name);
            Debug.Log("Loaded Mesh:" + mesh.name);
        }

        //create an array of all the bones in the rig.
        Transform[] bones = newPlayer.GetComponentsInChildren<Transform>();


        //iterate through the bodypart list and instantiate the bodypart;
        //리스트를 통해서 생성
        //"BodyPart" is just gameobject prefab with nothing but a MeshRenderer and MeshCollider attached. Everything else will be done via script.
        
        for (int i = 0; i < bodyPartMeshes.Count; i++)
        {
            GameObject bodyPart = Instantiate(Resources.Load("Prefabs/legPart") as GameObject, playerStart.transform.position, Quaternion.identity) as GameObject;

            bodyPart.name = bodyPartNames[i];
            bodyPart.GetComponent<MeshFilter>().mesh = bodyPartMeshes[i];

            //the important part: go through the bones array and check if there's a bone that corresponds to the current mesh. if yes, attach it and set the position and rotation to zero. The mesh object's pivot has the be exactly like the bonem, otherwise you have to add an offset for pos and rot.
            foreach (Transform bone in bones)
            {

                if (bone.name == bodyPartNames[i])
                {
                    bodyPart.transform.parent = bone;
                    bodyPart.transform.localPosition = new Vector3(0, 0, 0);
                    bodyPart.transform.localEulerAngles = new Vector3(0, 0, 0);
                    Debug.Log("Parented Body Part: " + bodyPart);
                }
            }

            //now all you need to do is define the material for this bodypart
        }
          */

    }
         
}
