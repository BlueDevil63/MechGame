using UnityEngine;
using System.Collections;

public class Hook : MonoBehaviour {
    public GameObject hookObject;
    public GameObject hookfire;
    public GameObject SpawnPoint;
    public GameObject AimPoint;
   // public GameObject testObject;
    public float shootSpeed = 150.0f;

	// Use this for initialization
	void Start () {
       
	
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 shootToward;       

        shootToward = AimPoint.transform.position;
        SpawnPoint.transform.LookAt(shootToward);

        if (Input.GetKeyDown(KeyCode.F))
        {
            Vector3 deltapos = shootToward - hookObject.transform.position;
            hookObject.SetActive(false);
            GameObject hookers = (GameObject)Instantiate(hookfire, SpawnPoint.transform.position, SpawnPoint.transform.rotation);
            hookers.GetComponent<Rigidbody>().velocity = deltapos.normalized * shootSpeed;
        }

	
	}
}
