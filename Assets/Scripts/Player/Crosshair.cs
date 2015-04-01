using UnityEngine;
using System.Collections;

public class Crosshair : MonoBehaviour {

    public Texture2D CrosshairImage;
   // public Camera camera;
    private float ImageWidth = 32*1.5f;
    private float ImageHeight = 32*1.5f;

	// Use this for initialization
	void Start () {
        Cursor.visible = false;
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


    void OnGUI()
    {
        GUI.DrawTexture(new Rect(Screen.width/2-(ImageWidth/2), Screen.height/3, ImageWidth, ImageHeight), CrosshairImage);
    }
}
