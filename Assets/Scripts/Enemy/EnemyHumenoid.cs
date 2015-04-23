using UnityEngine;
using System.Collections;

public class EnemyHumenoid : MonoBehaviour {


    float stateTime = 0.0f;
    public float idleStateMaxTime = 1.0f;

    public float speed = 15.0f;
    public float rotationSpeed = 15.0f;
    public float attackabeRange = 1.5f;
    public float moveRange = 10.0f;
    float attackMaxTime = 2.0f;

    CharacterController charController;

    Animator _animator;

    Transform target;
    int eHp = 5;


    public enum ENEMYSTATE
    {
        NONE = -1,
        IDLE = 0,
        MOVE,
        ATTACK,
        DAMAGE,
        DEAD
    }
    ENEMYSTATE enemyState =  ENEMYSTATE.IDLE;
	// Use this for initialization

    void Awake()
    {
        _animator = GetComponent<Animator>();
    }
	void Start () {
        target = GameObject.Find("Player").transform;

        charController = GetComponent<CharacterController>();

	
        
	}
	
	// Update is called once per frame
	void Update () {

         float distance = (target.position - transform.position).magnitude;
        switch(enemyState)
        {
            case ENEMYSTATE.IDLE:
                {
                    _animator.SetBool("run", false);
                    _animator.SetBool("idle", true);
                    stateTime += Time.deltaTime;
                    if(stateTime> idleStateMaxTime)
                    {
                        stateTime = 0.0f;
                        enemyState = ENEMYSTATE.MOVE;
                    }
                }
                break;
            case ENEMYSTATE.MOVE:
                {
                    _animator.SetBool("idle", false);
                    _animator.SetBool("run", true);
                    

                        if (distance < attackabeRange)
                        {
                            enemyState = ENEMYSTATE.ATTACK;

                            stateTime = attackMaxTime;
                        }
                        else
                        {
                            Vector3 dir = target.position - transform.position;
                            dir.y = 0.0f;
                            dir.Normalize();

                            charController.SimpleMove(dir * speed);
                            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(dir), rotationSpeed * Time.deltaTime);
                        }              
                 
                }
                break;
            case ENEMYSTATE.ATTACK:
                    {
                        if(distance > attackabeRange)
                        {
                            enemyState = ENEMYSTATE.IDLE;
                        }

                    }
                break;
            case ENEMYSTATE.DAMAGE:
                {
                    --eHp;
                    stateTime = 0;
                    
                    enemyState = ENEMYSTATE.IDLE;
                    if(eHp<= 0)
                    {
                        enemyState = ENEMYSTATE.DEAD;
                    }
                }
                break;
            case ENEMYSTATE.DEAD:
                {
                    Destroy(this.gameObject);
                }
                break;
        }
	
	}

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Bullet(Clone)")
            enemyState = ENEMYSTATE.DAMAGE;
    }
}
