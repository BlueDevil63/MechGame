﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GUIManager : MonoBehaviour {
    public Image boosterImage;
    public float boosterGage;
    public float boosterMov;

	// Use this for initialization
	void Start () {
        boosterImage = GetComponent<Image>();
       
	}
	
	// Update is called once per frame
	void Update () {
        boosterGage = Player.instance.pBuster;
        boosterMov = PlayerMovement.instance.buster;
        BoosterUpdate();
	
	}
    void BoosterUpdate()
    {
        boosterImage.fillAmount = boosterMov / boosterGage;
    }
}
