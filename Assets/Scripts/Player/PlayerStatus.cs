using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerStatus : MonoBehaviour
{

    ItemData items = new ItemData();
    ItemData.InventoryMemory card;
    public string[] deck;

    LinkedList<ItemData.InventoryMemory> imHands = new LinkedList<ItemData.InventoryMemory>();

    //플레이어의 능력치
    public struct pStatus
    {
        public float hp;                                //체력
        public float velocity;                          //속도
        public float power;                             //출력, 힘
        public float Weight;                            //무게
        public float jumpPower;                         //점프력

        public float boostAmount;                        //부스트 양 
        public float boostTransfom;                     //부스트 변화값
        public float boostVelocity;                     //부스트의 속도
        public float boostRate;
        public float boostCoolinRate;
        public float boostStateTime;
    }

    public struct ExtraWeapon
    {
        //Head
        GameObject[] HeadExtra;
        //Body
        GameObject[] bodyExtra;
        //Arm
        GameObject[] ArmExtra;
        //Leg
        GameObject[] LegExtra;
        //BackBack
        GameObject[] BakcPackExtra;
    }


    public pStatus status;

    public GameObject booster;
    // Use this for initialization
    void Start()
    {
        deck = new string[30];

        status.Weight = 300;
        status.velocity = 15;
        status.jumpPower = 30;
        status.boostVelocity = 50;
        status.hp = 100;

        card.name = "Box_0";
        card.type = "0";
        card.value = "Box";
        imHands.AddFirst(card);
        // card.maxCount = "3"
        card.name = "Wall_0";
        card.type = "0";
        card.value = "Wall";
        imHands.AddFirst(card);
        card.name = "Wall_0";
        card.type = "0";
        card.value = "Box";
        imHands.AddFirst(card);
    }


    // Update is called once per frame
    void Update()
    {
        imHands.Remove(card);
    }

    void CalculateParts()
    {

    }
}
public class IM
 {
        public string name;        //이름
        public string type;        //타입
        public string value;       //내용물
 }
public class Node
{
    public int _key;
    public IM data;
    public Node next;
    public Node before;
}
public class IM_LinkedList: MonoBehaviour
{
    Node _head;
    Node _end;

    public void init_Link()
    {
        _head = new Node();
        _end = new Node();
        _head._key = 0;
        _head.data = null;
        _end._key = 1;
        _end.data = null;
        _head.next = _end;
        _end.next = _end;
    }

    public void add_Link(Node lNode, Node rNode)
    {

        //if(_head.data == null)
        // {
        //     _head.data = rNode.data;
        // }
        /*   else
           {
               Node tempNode = new Node();
               tempNode._key = nKey;
               tempNode.next = _head.next;
               tempNode.before = _head;
           }
           */
        rNode.before = lNode;
        rNode.next = lNode.before;
        lNode.next.before = rNode;
        lNode.next = rNode;
    }

}


