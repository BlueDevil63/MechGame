using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
    public static GameManager instance;
    public enum ObjectCategory { WALL, NOMAL, NOHOOK };

    void Awake()
    {
        instance = this;
       
    }

	// Use this for initialization
	void Start () {
        Cursor.visible = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
