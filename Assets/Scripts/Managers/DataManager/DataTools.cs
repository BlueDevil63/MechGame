using UnityEngine;
//using UnityEditor;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;
using System.Text;
//using System.Runtime.Serialization;

public class DataTools : MonoBehaviour {
   
    //Byte -> string
   public  string UTF8ByteArrayToString(byte[] gameData)
    {
        UTF8Encoding encoding = new UTF8Encoding();
        string constructedString = encoding.GetString(gameData);
        return (constructedString);
    }
    //String -> byte
    public byte[] StringToUTF8ByteArray(string pxmlString)
    {
        UTF8Encoding encoding = new UTF8Encoding();
        byte[] byteArray = encoding.GetBytes(pxmlString);
        return byteArray;
    }
    //세이브 할때 사용
    
    public string SerlializeObject(object pObject, string type)
    {
        string xmlizedString = null;
        MemoryStream mStream = new MemoryStream();
        XmlSerializer xs = new XmlSerializer(typeof(PlayerData));
        switch(type)
        {
            case "part" :
            xs = new XmlSerializer(typeof(PartData));
            break;
            case "player":
            xs = new XmlSerializer(typeof(PlayerData));
            break;
            case "Item":
            xs = new XmlSerializer(typeof(ItemData));
            break;
            case "city" :
            xs = new XmlSerializer(typeof(CityData));
            break;
            case "weapon" :
            xs = new XmlSerializer(typeof(WeaponData));
            break;
            case "area":
            xs = new XmlSerializer(typeof(AreaData));
            break;
            default :
            xs = new XmlSerializer(typeof(PlayerData));
            break;
        }
        XmlTextWriter textWriter = new XmlTextWriter(mStream, Encoding.UTF8);
        xs.Serialize(textWriter, pObject);
        mStream = (MemoryStream)textWriter.BaseStream;
        xmlizedString = UTF8ByteArrayToString(mStream.ToArray());
        return xmlizedString;
       
    }
 


    public  object DeserializeObject(string pXmlizedString, string type)
    {
        XmlSerializer xs;
        switch (type)
        {
            case "part":
                xs = new XmlSerializer(typeof(PartData));
                break;
            case "player":
                xs = new XmlSerializer(typeof(PlayerData));
                break;
            case "Item":
                xs = new XmlSerializer(typeof(ItemData));
                break;
            case "city":
                xs = new XmlSerializer(typeof(CityData));
                break;
            case "weapon":
                xs = new XmlSerializer(typeof(WeaponData));
                break;
            case "area":
                xs = new XmlSerializer(typeof(AreaData));
                break;
            default:
                xs = new XmlSerializer(typeof(PlayerData));
                break;
        }
        MemoryStream mStream = new MemoryStream(StringToUTF8ByteArray(pXmlizedString));
        XmlTextWriter textWriter = new XmlTextWriter(mStream, Encoding.UTF8);
        return xs.Deserialize(mStream);
    }
 
        
    public void CreateXML(string _data, string _FileName, string _FileLocation)
    {
        StreamWriter writer;
        FileInfo t = new FileInfo(_FileLocation + "\\" + _FileName);
            if(!t.Exists)
            {
                writer = t.CreateText();
            }
            else
            {
                t.Delete();
                writer = t.CreateText();
            }
            writer.Write(_data);
            writer.Close();
    }

    public string LoadXML(string _data, string _FileName, string _FileLocation)
    {
        StreamReader r = File.OpenText(_FileLocation + "\\" + _FileName);
        string _info = r.ReadToEnd();
        r.Close();
        _data = _info;
        return _data;
    }
}

public class CityData
{
    public City _city1;
    public City _city2;
    public City _city3;
    public City _city4;
    public City _city5;
    public CityData() { } 
    public struct City
    {
       public string name;
       public string companyName;
       public float techLevel, depLevel, durability;        //기술력, 방어력, 내구도
       public float techExp, depExp, durExp;
       public float inflation;                             //물가 상승률

        public List<string> _IMList;
        public List<string> _PrefabsList;
        public List<string> _HeadList;
        public List<string> _BodyList;
        public List<string> _ArmList;
        public List<string> _LegList;
        public List<string> _BackPackList;
        public List<string> _WeaponList;
    }
}
public class AreaData
{
    public Area _area1;
    public Area _area2;
    public Area _area3;
    public Area _area4;
    public Area _area5;
    public AreaData() { }
    public struct Area
    {
        public string name;
        public int maxFloor;
        public int lastFloor;
        public float difficulty;
        public float captureRate;
    }
}
public class PlayerData 
{
    
    public User _user;
    public PlayerData() { }
    public struct User
    {
        public string head, body, arm, leg, backpack, weapon1, weapon2; //파츠 정보
        public string name;            //이름
        public int money;              //돈
        public int food;               //소지 식량
        public int energy;             //소지 에너지
        public int chapter;            //현재 진행된 챕터
        public string residence;       //현재 거주지
        public string location;        //현재 위치(어느 던전 몇번째인지)
        public List<string> _IMList;
        public List<string> _PrefabsList;
        public List<string> _HeadList;
        public List<string> _BodyList;
        public List<string> _ArmList;
        public List<string> _LegList;
        public List<string> _BackPackList;
        public List<string> _WeaponList;
        public List<string> _IMDeck;
    } 
}
public class MechData
{
    public struct Mech
    {
        public string mechName;
        public float dep;
        public float weight;
        public float lockOnDis;
        public float armSpeed;
        public float cpacity;
        public float power;
        public float speed;
        public float storeBoost;
        public float coolingRate;
        public float useRate;
        public float boostSpeed;

    }
}
public class PartData
{
    public Head _head;
    public Body _body;
    public Arm _arm;
    public Leg _leg;
    public BackPack _backPack;
    public PartData() { }
    public struct Head
    {
        public string name;
        public float def;
        public float lockOnDis;
        public float weight;
        public string extra;
    }
    public struct Body
    {
        public string name;
        public float def;
        public float capacity;         //에너지 수용량
        public float weight;
        public string extra;
    }
    public struct Leg
    {
        public string name;
        public float def;
        public float weight;
        public float maxWeight;
        public float power;
        public float speed;
        public string extra;
    }
    public struct Arm
    {
        public string name;
        public float def;
        public float weight;
        public float power;
        public float Speed;
        public string extra;
    }
    public struct BackPack
    {
        public string name;
        public float def;
        public float weight;
        public float capacity;  
        public float storeBoost;
        public float coolingRate;
        public float useRate;
        public float Speed;
        public string extra;
    }
 
}
public class WeaponData
{

    public struct LongWeapon
    {
        public string name;
        public string type;
        public float weight;
        public float power;
        public float effectiveRange;
        public float maxBullet;
        public string extra;
    }
    public struct ShotWeapon
    {
        public string name;
        public string type;
        public float weight;
        public float power;
        public float effectiveRange;
        public string extra;
    }
}
public class ItemData
{
    public ItemData() { }
    InventoryMemory imCard;
    public struct InventoryMemory
    {
        public string name;        //이름
        public string type;        //타입
        public string value;       //내용물
       // public int maxCount;     //가질 수 있는 최대개수
    }
    public struct Food
    {
        public string name;
        public int cost;
    }
    public struct Enegry
    {
        public string name;
        public int cost;
    }        
    public struct PrefabItem
    {
        public string name;
        public int level;
        public int cost;
    }
}


