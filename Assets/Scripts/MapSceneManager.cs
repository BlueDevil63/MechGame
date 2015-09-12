using UnityEngine;
using System.Collections;

public class MapSceneManager : MonoBehaviour {


    float timer;
    int currentDate;
    int currentMinute;
    int currentHour;
	// Use this for initialization
	void Start () {
        timer = 0;
        currentDate = 0;
        currentMinute = 0;
        currentHour = 0;
	}
	
	// Update is called once per frame
	void Update () {

        timer += Time.deltaTime;
        CalculateTime(timer);
	}

    void CalculateTime(float timer)
    {
        if (timer == 30)
        {
            currentMinute++;
            timer = 0;
        }
        if( currentMinute == 60)
        {
            currentHour++;
            currentMinute = 0;
        }
        if( currentHour == 24 )
        {
            currentDate++;
            currentHour = 0;
        }
    }
}
