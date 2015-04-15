using UnityEngine;
using System.Collections;

public class Hook : MonoBehaviour {
    public GameObject hookfire;
    public GameObject SpawnPoint0;
    public GameObject SpawnPoint1;
    public GameObject AimPoint;
    public int fireNumber =2;
     bool hook2fire = false;
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
                // hookObject.SetActive(false);
                if (fireNumber == 2)
                {
                    if (hook2fire == true)
                    {
                        Debug.Log("Destroy");
                        GameObject hooks = GameObject.Find("/hook(Clone)");
                        Destroy(hooks);
                        hook2fire = false;
                    }
                   Vector3 deltapos = shootToward - SpawnPoint0.transform.position;
                
                    hookers = (GameObject)Instantiate(hookfire, SpawnPoint0.transform.position, SpawnPoint0.transform.rotation);
                  hookers.GetComponent<Rigidbody>().velocity = deltapos.normalized * shootSpeed;
                  //  hookers.GetComponent<Rigidbody>().AddForce(SpawnPoint0.transform.forward * shootSpeed);
                  --fireNumber;
                  
                }
                else
                {
                    GameObject hooks = GameObject.Find("/hook(Clone)");
                    Destroy(hooks);
                    Vector3 deltapos = shootToward - SpawnPoint1.transform.position;      
                    hookers = (GameObject)Instantiate(hookfire, SpawnPoint1.transform.position, SpawnPoint1.transform.rotation);
                  hookers.GetComponent<Rigidbody>().velocity = deltapos.normalized * shootSpeed;
                  //  hookers.GetComponent<Rigidbody>().AddForce(SpawnPoint1.transform.forward * shootSpeed);     
                    fireNumber++;
                    hook2fire = true;
                  
                }
          
            }

        }
    
     

	
	
}
