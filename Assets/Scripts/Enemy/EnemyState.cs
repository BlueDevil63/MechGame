using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyState : MonoBehaviour {


    float stateTime = 0.0f;
    public float idleStateMaxTime = 2.0f;

    public float speed = 15.0f;
    public float rotationSpeed = 15.0f;
    public float attackabeRange = 1.5f;
    public float moveRange = 10.0f;
    public float attackMaxTime = 2.0f;
    public int eHp = 5;

    float distance = 200;
    private CharacterController charController;

    private Animator _animator;

    private Transform target = null;
    NavMeshAgent nmAgent;
    
    public enum ENEMYSTATE
    {
        NONE = -1,
        IDLE = 0,
        MOVE,
        ATTACK,
        DAMAGE,
        DEAD
    }
    ENEMYSTATE enemyState = ENEMYSTATE.IDLE;
    // Use this for initialization
    delegate void FsmFunction();
    Dictionary<ENEMYSTATE, FsmFunction> dicState = new Dictionary<ENEMYSTATE, FsmFunction>();


    void Awake()
    {
        nmAgent = GetComponent<NavMeshAgent>();
        _animator = GetComponentInChildren<Animator>();
    }
    void Start()
    {

        dicState[ENEMYSTATE.NONE] = None;
        dicState[ENEMYSTATE.IDLE] = Idle;
        dicState[ENEMYSTATE.MOVE] = Move;
        dicState[ENEMYSTATE.ATTACK] = Attack;
        dicState[ENEMYSTATE.DAMAGE] = Damage;
        dicState[ENEMYSTATE.DEAD] = Dead;
        
       // FindPlayer();
    }
    // Update is called once per frame
    void Update()
    {
        if(target == null)
        {
            FindPlayer();
        }
        distance = (target.position - transform.position).magnitude;
        dicState[enemyState]();
       
    }
    void FindPlayer()
    {
        GameObject gTarget = GameObject.Find("Player");
       // target = GameObject.Find("Player").transform;
        target = gTarget.GetComponentInChildren<Transform>();
        charController = GetComponent<CharacterController>();
    }

    void None()
    {

    }
   public  void Idle()
    {
        _animator.SetBool("run", false);
        _animator.SetBool("idle", true);
        stateTime += Time.deltaTime;
        if (stateTime > idleStateMaxTime)
        {
            stateTime = 0.0f;
            enemyState = ENEMYSTATE.MOVE;
        }
    }
   public void Move()
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
            nmAgent.SetDestination(target.transform.position);
            /*
            Vector3 dir = target.position - transform.position;
            dir.y = 0.0f;
            dir.Normalize();

            charController.SimpleMove(dir * speed);
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(dir), rotationSpeed * Time.deltaTime);
            */
        }
    }
   public void Attack()
    {
        if (distance > attackabeRange)
        {
            enemyState = ENEMYSTATE.IDLE;
        }

    }
   public void Damage()
    {
        --eHp;
        stateTime = 0;

        enemyState = ENEMYSTATE.IDLE;
        if (eHp <= 0)
        {
            enemyState = ENEMYSTATE.DEAD;
        }
    }
   public void Dead()
    {
        Destroy(this.gameObject);
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Bullet(Clone)")
            enemyState = ENEMYSTATE.DAMAGE;
    }
}
