using UnityEngine;
using System.Collections;

public class Combine : MonoBehaviour {
   // public GameObject PlayerPart;
  //  public Mesh baseMesh;

   void MeshConnect(GameObject part, Mesh baseMesh)
    {
        part.AddComponent<SkinnedMeshRenderer>();
        /*MESH*/
        Mesh sourceMesh = Instantiate(baseMesh) as Mesh;
       // sourceMesh.recalu

    }

}
