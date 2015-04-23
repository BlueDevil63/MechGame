using UnityEngine;
using System.Collections;

public class TPSAimShoot : MonoBehaviour
{

    RaycastHit hit;
    
     public Camera pCamera;
    //hooks
     public GameObject hookBullet;
     public GameObject spawnPoint0;
     public GameObject spawnPoint1;
    //Guns
     public GameObject gun;
     public GameObject bullet;
     public GameObject gunSpawnPoint;
     //public GameObject gunHand;
    // public GameObject AimPoint;
     public int fireNumber = 2;
     bool hook2fire = false;
     public float shootSpeed = 150.0f;

	// Use this for initialization
	void Start () {
      //  gun = GameObject.Find("/Player/PrototypeGun");
        
      //  Debug.Log(gun.name);
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        Ray ray = pCamera.ViewportPointToRay(new Vector3( 0.5f, 0.6f, 0));

        Debug.DrawRay(ray.origin, ray.direction * 200, Color.green);
        if(Physics.Raycast(ray.origin, ray.direction*200, out hit))
        {
           // gunHand.transform.LookAt(hit.point);
            gun.transform.LookAt(hit.point);
            
           // Debug.Log(hit.point);
            HookShoot(hit.point);
            GunShoot(hit.point);
        }
	

	}

    void HookShoot(Vector3 AimPoint)
    {
        // Vector3 shootToward;
        GameObject hookers;
        // shootToward = AimPoint.transform.position;
        spawnPoint0.transform.LookAt(AimPoint);
        spawnPoint1.transform.LookAt(AimPoint);

        if (Input.GetKeyDown(KeyCode.F))
        {

            if (fireNumber == 2)
            {
                    if (hook2fire == true)
                    {
                        Debug.Log("Destroy");
                        GameObject hooks = GameObject.Find("/hook(Clone)");
                        Destroy(hooks);
                        hook2fire = false;
                    }
                Vector3 deltapos = AimPoint - spawnPoint0.transform.position;
                hookers = (GameObject)Instantiate(hookBullet, spawnPoint0.transform.position, spawnPoint0.transform.rotation);
                hookers.GetComponent<Rigidbody>().velocity = deltapos.normalized * shootSpeed;
                //  hookers.GetComponent<Rigidbody>().AddForce(SpawnPoint0.transform.forward * shootSpeed);
               // fireNumber = 2;
                fireNumber--;
            }
            else
            {
                GameObject hooks = GameObject.Find("/hook(Clone)");
                Destroy(hooks);
                Vector3 deltapos = AimPoint - spawnPoint1.transform.position;
                hookers = (GameObject)Instantiate(hookBullet, spawnPoint1.transform.position, spawnPoint1.transform.rotation);
                hookers.GetComponent<Rigidbody>().velocity = deltapos.normalized * shootSpeed;
                hook2fire = true;
                fireNumber++;
                //  hookers.GetComponent<Rigidbody>().AddForce(SpawnPoint1.transform.forward * shootSpeed);    
            }
        }
    }

    void GunShoot(Vector3 AimPoint)
    {
        // Vector3 shootToward;
        // shootToward = AimPoint.transform.position;
        gunSpawnPoint.transform.LookAt(AimPoint);
        if (Input.GetButtonDown("Fire1"))
        {
            Vector3 deltapos = AimPoint - gunSpawnPoint.transform.position;
            GameObject insBullet = (GameObject)Instantiate(bullet, gunSpawnPoint.transform.position, gunSpawnPoint.transform.rotation);
            insBullet.GetComponent<Rigidbody>().velocity = deltapos.normalized * shootSpeed;
        }
    }
}
