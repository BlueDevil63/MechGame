using UnityEngine;
using System.Collections;

public class IMData : MonoBehaviour {


    enum memoryType {
        NOMAL,
        WEAPON,

    }
    public struct memorys
    {
        memoryType type;
        string name;
        GameObject memoryObject;
    }
}
