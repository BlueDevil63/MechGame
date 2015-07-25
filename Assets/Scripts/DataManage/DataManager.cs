using UnityEngine;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

public class DataManager : DataTools {
    PartData partData;
    Rect _Load, _LoadMSG;
    PlayerData _playerData;
    string _fileLocation;
    string loadData;
	// Use this for initialization
	void Start () {
        partData = new PartData();
        _Load = new Rect(20, 120, 120, 30);
        _LoadMSG = new Rect(10, 140, 400, 40);
        _fileLocation = "Assets/Data";
	}
    void OnGUI()
    {
        if (GUI.Button(_Load, "Load"))
        {
            GUI.Label(_LoadMSG, "Loading from: " + _fileLocation);
           loadData = LoadXML(loadData, "PartData"+".xml", _fileLocation);
           if( loadData.ToString() != "")
           {
               partData = (PartData)DeserializeObject(loadData, "part");
               Debug.Log("part headName =" + partData._head.name);
               Debug.Log("part bodyName =" + partData._body.name);
               Debug.Log("part bodyWeight = " + partData._body.weight);
           }
            
        }
    }
    void SumStatus(PlayerData _pData,  MechData _mData)
    {
        
        loadData= LoadXML(loadData, _pData._user.head + ".xml", _fileLocation);
       
    }
	
	// Update is called once per frame
	void Update () {

	
	}
}
