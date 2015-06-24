using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BoosterGage : MonoBehaviour {

   Image boosterImage;
    public float boosterGage;
    public float boosterMov;

	// Use this for initialization
	void Start () {
        boosterImage = GetComponent<Image>();
       
	}
	
	// Update is called once per frame
	void Update () {
        boosterGage = Player.instance.pBoostGage;
        boosterMov = Player.instance.pBoost;
        BoosterUpdate();
	
	}
    void BoosterUpdate()
    {
        boosterImage.fillAmount = boosterMov / boosterGage;
        if (boosterImage.fillAmount < 0.45)
        {
            boosterImage.color = Color.red;
        }
        else { boosterImage.color = Color.yellow; }
    }
}