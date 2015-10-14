using UnityEngine;
using System.Collections;

public class Radar : MonoBehaviour {

    public enum RadarTypes : int {Textured, Round, Transparent };

    //표시 위치
    public Vector2 radarLocationCustom;
    public RadarTypes radarType = RadarTypes.Round;
    public Color radarBackgroundA = new Color(255, 255, 0);
    public Color radarBackgroundB = new Color(0, 255, 255);
    public Texture2D radarTexture;
    public float radarSize = 0.20f;
    public float radarZoom = 0.60f;

    //중심 오브젝트 정보
    public bool radarCenterAcive;
    public Color radarCenterColor = new Color(255, 255, 255);
    public string radarCenterTag;

    //신호 정보
    public bool radarBlipActive;
    public Color radarBlipColor = new Color(0, 0, 255);
    public string radarBlipTag;

    public bool radarBlip2Active;
    public Color radarBlip2Color = new Color(0, 255,0);
    public string radarBlip2Tag;

    public bool radarBlip3Active;
    public Color radarBlip3Color = new Color(255,0,0);
    public string radarBlip3Tag;

    public bool radarBlip4Active;
    public Color radarBlip4Color = new Color(255, 0, 255);
    public string radarBlip4Tag;

    private GameObject _centerObject;
    private int _radarWidth;
    private int _radarHeight;
    private Vector2 _radarCenter;
    private Texture2D _radarCenterTexture;
    private Texture2D _radarBlipTexture;
    private Texture2D _radarBlip2Texture;
    private Texture2D _radarBlip3Texture;
    private Texture2D _radarBlip4Texture;
    // Use this for initialization
    void Start () {
        _radarWidth = (int)(Screen.width * radarSize);
        _radarHeight = _radarWidth;
        //레이더의 중심 설정;
        _radarCenter = new Vector2(Screen.width - _radarWidth / 2, _radarHeight / 2);


        //레이더 텍스처 초기화
        _radarCenterTexture = new Texture2D(3, 3, TextureFormat.RGB24, false);
        _radarBlipTexture = new Texture2D(3, 3, TextureFormat.RGB24, false);
        _radarBlip2Texture = new Texture2D(3, 3, TextureFormat.RGB24, false);
        _radarBlip3Texture = new Texture2D(3, 3, TextureFormat.RGB24, false);
        _radarBlip4Texture = new Texture2D(3, 3, TextureFormat.RGB24, false);

        //레이더 텍스쳐 생성
        CreateBlipTexture(_radarCenterTexture, radarCenterColor);
        CreateBlipTexture(_radarBlipTexture, radarBlipColor);
        CreateBlipTexture(_radarBlip2Texture, radarBlip2Color);
        CreateBlipTexture(_radarBlip3Texture, radarBlip3Color);
        CreateBlipTexture(_radarBlip4Texture, radarBlip4Color);

        if(radarType != RadarTypes.Textured)
        {
            radarTexture = new Texture2D(_radarWidth, _radarHeight, TextureFormat.RGB24, false);
            CreateRoundTexture(radarTexture, radarBackgroundA, radarBackgroundB);
        }

        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag(radarCenterTag);
        _centerObject = gos[0];

    }
   
	
	// Update is called once per frame
	void OnGUI () {

        GameObject[] gos;
        if(radarType != RadarTypes.Transparent)
        {
            Rect radarRect = new Rect(_radarCenter.x - _radarWidth / 2, _radarCenter.y - _radarHeight / 2, _radarWidth, _radarHeight);
            GUI.DrawTexture(radarRect, radarTexture);
        }

        if(radarBlipActive)
        {
            gos = GameObject.FindGameObjectsWithTag(radarBlipTag);
            
            foreach(GameObject go in gos)
            {
                DrawBlip(go, _radarBlipTexture);
            }      
        }
        if (radarBlip2Active)
        {
            gos = GameObject.FindGameObjectsWithTag(radarBlip2Tag);

            foreach (GameObject go in gos)
            {
                DrawBlip(go, _radarBlip2Texture);
            }
        }
        if (radarBlip3Active)
        {
            gos = GameObject.FindGameObjectsWithTag(radarBlip3Tag);

            foreach (GameObject go in gos)
            {
                DrawBlip(go, _radarBlip3Texture);
            }
        }
        if (radarBlip4Active)
        {
            gos = GameObject.FindGameObjectsWithTag(radarBlip4Tag);

            foreach (GameObject go in gos)
            {
                DrawBlip(go, _radarBlip4Texture);
            }
        }

        Rect centerRect = new Rect(_radarCenter.x - 1.5f, _radarCenter.y - 1.5f, 3, 3);
        GUI.DrawTexture(centerRect, _radarCenterTexture);

    }


    void DrawBlip(GameObject go, Texture2D BlipTexture)
    {
        if(_centerObject)
        {
            Vector3 centerPos = _centerObject.transform.position;
            Vector3 extPos = go.transform.position;

            float dist = Vector3.Distance(centerPos, extPos);


            float bx = centerPos.x - extPos.x;
            float by = centerPos.z - extPos.z;

            if(dist <= (_radarWidth - 2) * 0.5 / radarZoom)
            {
                Rect clipRect = new Rect(_radarCenter.x - bx - 1.5f, _radarCenter.y + by - 1.5f, 3, 3);
                GUI.DrawTexture(clipRect, BlipTexture);
            }

        }
    }

    void CreateBlipTexture(Texture2D tex, Color c)
    {
        Color[] cols = { c, c, c, c, c, c, c, c, c };
        tex.SetPixels(cols, 0);
        tex.Apply();
    }

    void CreateRoundTexture(Texture2D tex, Color aC, Color bC)
    {
        Color c = new Color(0, 0, 0);
        int size = (int)((_radarWidth / 2) / 4);

        for(int x = 0; x< _radarWidth; x++)
        {
            for(int y = 0; y < _radarWidth; y++)
            {
                tex.SetPixel(x, y, c);
            }
        }
        for(int r = 4; r>0; r--)
        {
            if(r%2 == 0)
            {
                c = aC;
            }
            else
            {
                c = bC;
            }
            DrawFiledCircle(tex, (int)(_radarWidth / 2), (int)(_radarHeight / 2), (r * size), c);
        }
        tex.Apply();
    }

    void DrawFiledCircle(Texture2D tex, int cX, int cY, int r, Color color)
    {
        for(int x = -r; x < r; x++)
        {
            int height = (int)Mathf.Sqrt(r * r - x * x);

            for(int y = -height; y < height; y++)
            {
                tex.SetPixel(x + cX, y + cY, color);
            }
        }
    }


    
}
