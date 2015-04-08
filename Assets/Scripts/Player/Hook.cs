using UnityEngine;
using System.Collections;

public class Hook : MonoBehaviour {
    public GameObject hookObject0;
    public GameObject hookObject1;
    public GameObject hookfire;
    public GameObject SpawnPoint0;
    public GameObject SpawnPoint1;
    public GameObject AimPoint;
  //  bool fire;
   // public GameObject testObject;
    public float shootSpeed = 150.0f;
   

	// Use this for initialization
	void Start () {
       
	
	}
	
	// Update is called once per frame
	void Update () {
    
        Vector3 shootToward;
        GameObject hookers;
        shootToward = AimPoint.transform.position;
        SpawnPoint0.transform.LookAt(shootToward);
        SpawnPoint1.transform.LookAt(shootToward);

        if (Input.GetKeyDown(KeyCode.F))
        {
            if (Player.instance.hookCount > 0)
            {

                // hookObject.SetActive(false);
                if (Player.instance.hookCount == 2 || Player.instance.hookCount == 0)
                {                   
                    if(Player.instance.hookCount == 0)
                    {
                        SpawnPoint1.SetActive(true);
                    }

                    --Player.instance.hookCount;
                   
                    Vector3 deltapos = shootToward - SpawnPoint0.transform.position;
                    SpawnPoint0.SetActive(false);
                    hookers = (GameObject)Instantiate(hookfire, SpawnPoint0.transform.position, SpawnPoint0.transform.rotation);
                    hookers.GetComponent<Rigidbody>().velocity = deltapos.normalized * shootSpeed;
                    if (Player.instance.hookCount == 0)
                    {
                        ++Player.instance.hookCount;
                    }

                }
                else
                {
                    --Player.instance.hookCount;
                 
                    Vector3 deltapos = shootToward - SpawnPoint1.transform.position;
                    SpawnPoint1.SetActive(false);
                    hookers = (GameObject)Instantiate(hookfire, SpawnPoint1.transform.position, SpawnPoint1.transform.rotation);
                    hookers.GetComponent<Rigidbody>().velocity = deltapos.normalized * shootSpeed;
                    SpawnPoint0.SetActive(true);

                }
                //   if(Player.instance.hookCount <2)
                //  {
                //       Vector3 returnPos = hookers.transform.position - SpawnPoint0.transform.position;
                //        hookers.GetComponent<Rigidbody>().velocity = returnPos.normalized * shootSpeed;
                //      ++Player.instance.hookCount;
                //  }
            }
        }
    
        }

	
	
}
