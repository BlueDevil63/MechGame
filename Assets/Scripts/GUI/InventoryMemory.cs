using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class InventoryMemory : MonoBehaviour {
    public RectTransform list;
    public int count;
    private float currentPos;
    private float movePos;
    private bool isScroll;


    public GameObject inventoryList;
    public List<GameObject> iImageList = new List<GameObject>();
  //  List<>
	// Use this for initialization
	void Start() {
        currentPos = list.localPosition.x;
        movePos = list.rect.xMax - list.rect.xMax / count;
        Player.instance.selectMemory = 2;
       // GenerateImage();
	}
	
	// Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            if (Player.instance.selectMemory > 1)
            {
                Player.instance.selectMemory--;
                Left();
            }
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (Player.instance.selectMemory < 3)
            {
                Player.instance.selectMemory++;
                Right();
            }
        }
    }

    public void Right()
    {
        if(list.rect.xMin + list.rect.xMax/count != movePos)
        {
            isScroll = true;
            movePos = currentPos - list.rect.width / count;
            currentPos = movePos;
            StartCoroutine(Scroll());
        }
    }
    public void  Left()
    {
        if (list.rect.xMax + list.rect.xMax / count != movePos)
        {
            isScroll = true;
            movePos = currentPos + list.rect.width / count;
            currentPos = movePos;
            StartCoroutine(Scroll());
        }
    }



    IEnumerator Scroll()
    {
        while(isScroll)
        {
            list.localPosition = Vector2.Lerp(list.localPosition, new Vector2(movePos, 0), Time.deltaTime * 5);
            if(Vector2.Distance(list.localPosition, new Vector2(movePos, 0))< 0.1f)
            {
                isScroll = false;
            }
            yield return null;

        }
    }


    void GenerateImage()
    {
        int icount = 0;
        for (int i = 0; i <= Player.instance.iMemorys.Count; i++)
        {
            switch(Player.instance.iMemorys[i])
            {
                case "memory0":
                    icount = 0;
                    break;
                case "memory1":
                    icount = 1;
                    break;
                case "memory2":
                    icount = 2;
                    break;

            }
            GameObject ivImage = Instantiate(iImageList[icount]) as GameObject;
            ivImage.transform.parent = inventoryList.transform;
           
        }
    }
}
