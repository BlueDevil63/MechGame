using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HpGage : MonoBehaviour
{


    Image hPImage;
    public float hPGage;
    public float hPMov;

    // Use this for initialization
    void Start()
    {
        hPImage = GetComponent<Image>();

    }

    // Update is called once per frame
    void Update()
    {
        hPGage = Player.instance.pHp;
        hPMov = Player.instance.pHpDamaged;
        HPUpdate();

    }
    void HPUpdate()
    {
        hPImage.fillAmount = hPMov / hPGage;
        if (hPImage.fillAmount < 0.45)
        {
            hPImage.color = Color.red;
        }
        else { hPImage.color = Color.green; }
    }
}