using UnityEngine;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using UnityEngine.UI;
using System.Xml.Serialization;
public class MapMgr: DataTools {
    PlayerData _playerData;
    CityData _cityData;
    AreaData _areaData;
    string _fileLocation;
    string loadData;
    string selectArea;
    //Player
    public Text playerName;
    public Text energy;
    public Text foodStuffs;
    public Text money;
    //City
    public Text cityName;
    public Text techLv;
    public Text techExp;
    public Text defLv;
    public Text defExp;
    public Text durLv;
    public Text durExp;
    public Text price;
    //Area
    public Text areaName;
    public Text lastFloor;
    public Text captureRate;
    //Time
    float timer;
    int currentDate;
    int currentMinute;
    int currentHour;
    public Text Hour;
    public Text Minute;
    public Text Date;


    // Use this for initialization
    void Start () {
        _playerData = new PlayerData();
        _fileLocation = "Assets/Data";
        _playerData = LoadPlayerData(_playerData);
        playerName.text = _playerData._user.name;
        energy.text = "에너지 : "+_playerData._user.energy;
        foodStuffs.text = "남은 식량 :" + _playerData._user.food;
        money.text = _playerData._user.money + "G";

        _cityData = new CityData();
        _cityData = LoadCityData(_cityData);



        timer = 0;
        currentDate = 0;
        currentMinute = 0;
        currentHour = 0;
    }
	
	// Update is called once per frame
	void Update () {
        selectArea = name;
        timer += Time.deltaTime;
      //  Debug.Log(timer);
        CalculateTime();
        
    }
    public void ClickArea()
    {

    }
    public void ClickCity()
    {

        if (name == "Rokia")
        {
            cityName.text = _cityData._city5.name;
            techLv.text = _cityData._city5.techLevel.ToString();
            techExp.text = _cityData._city5.techExp.ToString();

            defLv.text = _cityData._city5.depLevel.ToString();
            defExp.text = _cityData._city5.depExp.ToString();

            durLv.text = _cityData._city5.durability.ToString();
            durExp.text = _cityData._city5.durExp.ToString();

            price.text = _cityData._city5.inflation.ToString();
        }
        if (name == "Etruria")
        {
            cityName.text = _cityData._city4.name;
            techLv.text = _cityData._city4.techLevel.ToString();
            techExp.text = _cityData._city4.techExp.ToString();

            defLv.text = _cityData._city4.depLevel.ToString();
            defExp.text = _cityData._city4.depExp.ToString();

            durLv.text = _cityData._city4.durability.ToString();
            durExp.text = _cityData._city4.durExp.ToString();

            price.text = _cityData._city4.inflation.ToString();
        }

       if( name =="Avalon")
       {
           cityName.text = _cityData._city3.name;
           techLv.text = _cityData._city3.techLevel.ToString();
           techExp.text = _cityData._city3.techExp.ToString();

           defLv.text = _cityData._city3.depLevel.ToString();
           defExp.text = _cityData._city3.depExp.ToString();

           durLv.text = _cityData._city3.durability.ToString();
           durExp.text = _cityData._city3.durExp.ToString();

           price.text = _cityData._city3.inflation.ToString();
       }
        
       if( name =="Tantalos")
       {
           cityName.text = _cityData._city2.name;
           techLv.text = _cityData._city2.techLevel.ToString();
           techExp.text = _cityData._city2.techExp.ToString();

           defLv.text = _cityData._city2.depLevel.ToString();
           defExp.text = _cityData._city2.depExp.ToString();

           durLv.text = _cityData._city2.durability.ToString();
           durExp.text = _cityData._city2.durExp.ToString();

           price.text = _cityData._city2.inflation.ToString();
       }
       if (name == "Atena")
       {
           cityName.text = _cityData._city1.name;
           techLv.text = _cityData._city1.techLevel.ToString();
           techExp.text = _cityData._city1.techExp.ToString();

           defLv.text = _cityData._city1.depLevel.ToString();
           defExp.text = _cityData._city1.depExp.ToString();

           durLv.text = _cityData._city1.durability.ToString();
           durExp.text = _cityData._city1.durExp.ToString();

           price.text = _cityData._city1.inflation.ToString();
       }

    }
    public void Customize()
    {
        Application.LoadLevel("CustomizeScene");
    }
    public void IntoDungen()
    {
        Application.LoadLevel("BattleScene");
    }

   PlayerData LoadPlayerData(PlayerData _pData)
    {
        loadData = LoadXML(loadData, "NewPlayerData.xml", _fileLocation);
        if (loadData.ToString() != "")
        {
            _pData = (PlayerData)DeserializeObject(loadData, "player");
            Debug.Log("플레이어 음식량 =" + _pData._user.food);
            Debug.Log("플레이어 에너지 =" + _pData._user.energy);
            Debug.Log("플레이어 이름 = " +_pData._user.name);
        }
        return _pData;
    }

    CityData LoadCityData(CityData _cData)
   {
         loadData = LoadXML(loadData, "CityData.xml", _fileLocation);
           if (loadData.ToString() != "")
        {
            _cData = (CityData)DeserializeObject(loadData, "city");
           
        }
           return _cData;
   }

    void CalculateTime()
    {
        if (timer >= 5)
        {
            currentMinute++;
            timer = 0;
        }
        if (currentMinute == 60)
        {
            currentHour++;
            currentMinute = 0;
        }
        if (currentHour == 24)
        {
            currentDate++;
            currentHour = 0;
        }

        Date.text = currentDate + "일";
        if(currentHour<10)
            Hour.text = "0" + currentHour; 
        else { Hour.text = currentHour + ""; }
        if (currentMinute < 10)
            Minute.text = ":0"+ currentMinute;
        else { Minute.text = ":" + currentMinute; }
    }

}
