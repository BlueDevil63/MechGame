﻿using UnityEngine;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

public class CreateData : DataTools {
    Rect _Save, _Player, _SaveMSG, _PlaterMSG;
    Rect _Part;
    bool _ShouldSave, _ShouldLoad, _SwitchSave, _SwitchLoad;
    CityData city;
    PartData parts;
    PlayerData player;
    string _fileLocation; 
    string _fileName;
    string _data;
	// Use this for initialization
	void Start () {
        _Save = new Rect(10, 80, 100, 20);
        _Player = new Rect(100, 100, 100, 20);
        _Part = new Rect(110, 80, 100, 20);
       // _Load = new Rect(10, 100, 100, 20);
        _SaveMSG = new Rect(10, 120, 400, 40);
       // _LoadMSG = new Rect(10, 140, 400, 40);

       // _fileLocation = Application.dataPath;
        _fileLocation = "Assets/Data";
        player = new PlayerData();
        player._user.name = "BlueDevil63";
        player._user.money = 20000;
        player._user.energy = 10;
        player._user.food = 7;
        player._user.chapter = 0;
        player._user.residence = "Atena";
        player._user.location = "Atena";
        player._user.head = "Elpida Head";
        player._user.body = "Elpida Body";
        player._user.arm = "Elpida Arm";
        player._user.leg = "Elpida Leg";
        player._user.backpack = "Elpida BackPack";
        player._user.weapon1 = "ProtoGun";
        player._user.weapon2 = "none";

        //nomal data;
        player._user._IMList = new List<string>();
        player._user._IMList.Add("Box_0");
        player._user._IMList.Add("Wall_0");
        player._user._IMList.Add("Dummy_0");
        player._user._PrefabsList = new List<string>();
        player._user._PrefabsList.Add(null);
        player._user._HeadList = new List<string>();
        player._user._HeadList.Add("Elpida Head");
        player._user._BodyList = new List<string>();
        player._user._BodyList.Add("Elpida Body");
        player._user._ArmList = new List<string>();
        player._user._ArmList.Add("Elpida Arm");
        player._user._LegList = new List<string>();
        player._user._LegList.Add("Elpida Leg");
        player._user._BackPackList = new List<string>();
        player._user._BackPackList.Add("Elpida BackPack");
        player._user._WeaponList = new List<string>();
        player._user._WeaponList.Add("ProtoGun");
        player._user._IMDeck = new List<string>();
        player._user._IMDeck.Add("box_0");
        player._user._IMDeck.Add("wall_0");
        player._user._IMDeck.Add("Dummy_0");




        city = new CityData();
        city._city1.name = "Atena";
        city._city1.companyName = "Jeus";
        city._city1.techLevel = 1.0f;           //기술력 E
        city._city1.techExp = 0;
        city._city1.depLevel = 3.0f;            //방어력 C
        city._city1.depExp = 0;
        city._city1.durability = 2.0f;          //내구도 D
        city._city1.inflation = 1.0f;           //물가 E
        city._city1._IMList = new List<string>();
        city._city1._IMList.Add(null);
        city._city1._PrefabsList = new List<string>();
        city._city1._PrefabsList.Add(null);
        city._city1._HeadList = new List<string>();
        city._city1._HeadList.Add(null);
        city._city1._BodyList = new List<string>();
        city._city1._BodyList.Add(null);
        city._city1._ArmList = new List<string>();
        city._city1._ArmList.Add(null);
        city._city1._LegList = new List<string>();
        city._city1._LegList.Add(null);
        city._city1._BackPackList = new List<string>();
        city._city1._BackPackList.Add(null);
        city._city1._WeaponList = new List<string>();
        city._city1._WeaponList.Add(null);

        city._city2.name = "Tantalos";
        city._city2.companyName = "Atlas";
        city._city2.techLevel = 3.0f;           //기술력 C
        city._city2.techExp = 0;
        city._city2.depLevel = 2.0f;            //방어력 D
        city._city2.depExp = 0;
        city._city2.durability = 1.0f;          //내구도 E
        city._city2.inflation = 2.5f;         //물가 D+

        city._city2._IMList = new List<string>();
        city._city2._IMList.Add(null);
        city._city2._PrefabsList = new List<string>();
        city._city2._PrefabsList.Add(null);
        city._city2._HeadList = new List<string>();
        city._city2._HeadList.Add(null);
        city._city2._BodyList = new List<string>();
        city._city2._BodyList.Add(null);
        city._city2._ArmList = new List<string>();
        city._city2._ArmList.Add(null);
        city._city2._LegList = new List<string>();
        city._city2._LegList.Add(null);
        city._city2._BackPackList = new List<string>();
        city._city2._BackPackList.Add(null);
        city._city2._WeaponList = new List<string>();
        city._city2._WeaponList.Add(null);

        city._city3.name = "Avalon";
        city._city3.companyName = "Odin";
        city._city3.techLevel = 2.0f;           //기술력 D
        city._city3.techExp = 0;
        city._city3.depLevel = 3.0f;            //방어력 C
        city._city3.depExp = 0;
        city._city3.durability = 1.0f;          //내구도 E
        city._city3.inflation = 2.0f;         //물가 D

        city._city3._IMList = new List<string>();
        city._city3._IMList.Add(null);
        city._city3._PrefabsList = new List<string>();
        city._city3._PrefabsList.Add(null);
        city._city3._HeadList = new List<string>();
        city._city3._HeadList.Add(null);
        city._city3._BodyList = new List<string>();
        city._city3._BodyList.Add(null);
        city._city3._ArmList = new List<string>();
        city._city3._ArmList.Add(null);
        city._city3._LegList = new List<string>();
        city._city3._LegList.Add(null);
        city._city3._BackPackList = new List<string>();
        city._city3._BackPackList.Add(null);
        city._city3._WeaponList = new List<string>();
        city._city3._WeaponList.Add(null);

        city._city4.name = "Etruria";
        city._city4.companyName = "Janus";
        city._city4.techLevel = 3.0f;           //기술력 D
        city._city4.techExp = 0;
        city._city4.depLevel = 2.0f;            //방어력 D
        city._city4.depExp = 0;
        city._city4.durability = 2.0f;          //내구도 D
        city._city4.inflation = 1.5f;         //물가 E+

        city._city4._IMList = new List<string>();
        city._city4._IMList.Add(null);
        city._city4._PrefabsList = new List<string>();
        city._city4._PrefabsList.Add(null);
        city._city4._HeadList = new List<string>();
        city._city4._HeadList.Add(null);
        city._city4._BodyList = new List<string>();
        city._city4._BodyList.Add(null);
        city._city4._ArmList = new List<string>();
        city._city4._ArmList.Add(null);
        city._city4._LegList = new List<string>();
        city._city4._LegList.Add(null);
        city._city4._BackPackList = new List<string>();
        city._city4._BackPackList.Add(null);
        city._city4._WeaponList = new List<string>();
        city._city4._WeaponList.Add(null);

        city._city5.name = "Rokia";
        city._city5.companyName = "Jotunnheim";
        city._city5.techLevel = 1.0f;           //기술력 D
        city._city5.techExp = 0;
        city._city5.depLevel = 3.0f;            //방어력 C
        city._city5.depExp = 0;
        city._city5.durability = 3.0f;          //내구도 C
        city._city5.inflation = 1.0f;         //물가 E

        city._city5._IMList = new List<string>();
        city._city5._IMList.Add(null);
        city._city5._PrefabsList = new List<string>();
        city._city5._PrefabsList.Add(null);
        city._city5._HeadList = new List<string>();
        city._city5._HeadList.Add(null);
        city._city5._BodyList = new List<string>();
        city._city5._BodyList.Add(null);
        city._city5._ArmList = new List<string>();
        city._city5._ArmList.Add(null);
        city._city5._LegList = new List<string>();
        city._city5._LegList.Add(null);
        city._city5._BackPackList = new List<string>();
        city._city5._BackPackList.Add(null);
        city._city5._WeaponList = new List<string>();
        city._city5._WeaponList.Add(null);

        parts = new PartData();
        parts._head.name = "Elpida Head";
        parts._head.def = 6.0f;
        parts._head.weight = 10.0f;
        parts._head.lockOnDis = 500.0f;
        parts._head.extra = "";

        parts._arm.name = "Elpida Arm";
        parts._arm.def = 6.0f;
        parts._arm.weight = 50.0f;
        parts._arm.power = 70.0f;
        parts._arm.Speed = 7.0f;
        parts._arm.extra = "";

        parts._leg.name = "Elpida Leg";
        parts._leg.def = 6.0f;
        parts._leg.power = 70.0f;
        parts._leg.speed = 7.0f;
        parts._leg.weight = 70.0f;
        parts._leg.maxWeight = 350.0f;
        parts._leg.extra = "";

        parts._body.name = "Elpida Body";
        parts._body.def = 6.0f;
        parts._body.capacity = 7;
        parts._body.weight = 40.0f;
        parts._body.extra = "";

        parts._backPack.name = "Elpida BackPack";
        parts._backPack.def = 6.0f;
        parts._backPack.capacity = 4;
        parts._backPack.storeBoost = 200.0f;
        parts._backPack.coolingRate = 70.0f;
        parts._backPack.useRate = 10.0f;


	}
	
	// Update is called once per frame
	void Update () {	}
    void OnGUI()
    {
        if(GUI.Button(_Save, "City"))
        {
            _fileName = "CityData.xml";
            GUI.Label(_SaveMSG, "Saving to" + _fileName);
            _data = SerlializeObject(city, "city");

            CreateXML(_data, _fileName, _fileLocation);
         
        }
        if (GUI.Button(_Part, "Parts"))
        {
            _fileName = "PartData.xml";
            _data = SerlializeObject(parts, "part");
            CreateXML(_data, _fileName, _fileLocation);

        }
        if(GUI.Button(_Player, "CreatePlayer"))
        {
            _fileName = "PlayerData.xml";
            _data = SerlializeObject(player, "player");
            CreateXML(_data, _fileName, _fileLocation);
        }
    }

}
