using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {

    public bool onGround;
    public bool onBoost;
  public Camera camera;

    IComparer rayHitComparer;

    Animator _animator;
    Rigidbody _rigidbody;
    PlayerStatus _playerstatus;
    Vector3 velocity;

    private Transform _transform;


	// Use this for initialization
    void Start () {
        _animator = GetComponentInChildren<Animator>();

        _rigidbody = GetComponent<Rigidbody>();

        _playerstatus = GetComponent<PlayerStatus>();
        _transform = GetComponent<Transform>();
	}
	
	// Update is called once per frame
    //캐릭터 움직임
    public  void Move(float x, float z)
    {
        if (GroundCheck())
        {
            if (!(x == 0 && z == 0))
            {
                _transform.Translate(Vector3.forward * _playerstatus.status.velocity * z * Time.deltaTime, Space.Self);
                _transform.Translate(Vector3.right * _playerstatus.status.velocity * x * Time.deltaTime, Space.Self);
            // _transform.Translate(Vector3.forward * _playerstatus.status.velocity * z * Time.deltaTime, camera.transform );
            //  _transform.Translate(Vector3.right * _playerstatus.status.velocity * x * Time.deltaTime, camera.transform);
                _animator.SetBool("run", true);
            }
            else
            {
                _animator.SetBool("run", false);
            }
           // _rigidbody.useGravity = true;
        }
        else {
            Gravity() ;
        }
    }
    //부스터 이동
    public void BoostMove(float x, float z, bool on)
    {
        //부스터가 현재 켜져 있는가?
        if (on == true)
        {
            //플레이어의 방향키 입력이 없다면 위로 이동
            if (x == 0 && z == 0)
            {
                _transform.Translate(Vector3.up * _playerstatus.status.boostVelocity * 3 * Time.deltaTime, Space.Self);  
            }
            //플레이어의 방향키 입력이 있다면 방향대 움직임
            else
            {
                _transform.Translate(Vector3.right * _playerstatus.status.boostVelocity * x * Time.deltaTime, Space.Self);
                _transform.Translate(Vector3.forward * _playerstatus.status.boostVelocity * z * Time.deltaTime, Space.Self);
            }

            _playerstatus.booster.SetActive(true);
            onBoost = true;
        }
        else
        {
            onBoost = false;
            _playerstatus.booster.SetActive(false);
        }

    }
    //회피 행동
    public void Avoidance()
    {

    }
    //메인 무기 공격
    public  void MainWeaponAttack()
    {
        Debug.Log("main");
    }
    //서브 무기 공격
    public void SubWeaponAttack()
    {
        Debug.Log("sub");
    }
    //메인 무기 교체
    public void WeaponSwap()
    {
        Debug.Log("Swap");
    }
    //후크 발사
    public  void HookShot()
    {

    }
    //후크 당기기
    public void HookPull()
    {

    }
    public  void WallClimb()
    {

    }
    //지면에 닿았는지
    public bool GroundCheck()
    {
        RaycastHit hitInfo;
        Debug.DrawLine(transform.position + (Vector3.up * 0.1f), transform.position + (Vector3.up * 0.1f) + (Vector3.down * 0.1f));
        if (Physics.Raycast(transform.position + (Vector3.up * 0.1f), Vector3.down, out hitInfo, 0.1f))
        {
            onGround = true;
            return true;
        }
        else {
            onGround = false;
            return false;
        }
    }
    public void RayGroundCheck()
    {
        velocity = _rigidbody.velocity;
      // Ray ray = new Ray(transform.position + Vector3.up * 0.1f, -Vector3.up);
        
        Vector3[] tPos = new Vector3[5];
        tPos[0] = new Vector3(transform.position.x -0.8f, transform.position.y, transform.position.z + 0.8f);
        tPos[1] = new Vector3(transform.position.x + 0.8f, transform.position.y, transform.position.z + 0.8f);
        tPos[2] = new Vector3(transform.position.x - 0.8f, transform.position.y, transform.position.z - 0.8f);
        tPos[3] = new Vector3(transform.position.x + 0.8f, transform.position.y, transform.position.z - 0.8f);
        tPos[4] = transform.position;
        Ray[] ray = new Ray[5];
        int groundHIt = 0;

        for (int i = 0; i < 5; i++)
        {
            ray[i] = new Ray(tPos[i] + Vector3.up * 0.1f, -Vector3.up);
            Debug.DrawRay(tPos[i] + Vector3.up * 0.1f, -Vector3.up);
        }

        RaycastHit hit;
        for(int k = 0; k < 5; k++)
        {
            if(Physics.Raycast(ray[k], out hit))
            {
                groundHIt++;
            }
        }
        if (groundHIt > 2)
        {
            onGround = true;
            _rigidbody.useGravity = false;
        }
        else
        {
            onGround = false;
            _rigidbody.useGravity = true;
        }

        /*
        
        Debug.DrawRay(transform.position + Vector3.up * 0.1f, -Vector3.up);
        RaycastHit[] hits = Physics.RaycastAll(ray, 0.1f);
       rayHitComparer = new RayHItComparer();
        System.Array.Sort(hits, rayHitComparer);

       if (velocity.y < _playerstatus.status.jumpPower * 0.5f)
        {
            onGround = false;
            _rigidbody.useGravity = true;
            Gravity();


            foreach (var hit in hits)
            {
                if(!hit.collider.isTrigger)
                {
                    if(velocity.y <= 0)
                    {
                       // _rigidbody.position = Vector3.MoveTowards(_rigidbody.position, hit.point, Time.deltaTime * 100); 
                    }

                    onGround = true;
                    _rigidbody.useGravity = false;
                }
            }
            Debug.Log(_rigidbody.useGravity);
        }
        */
        //  onGround = true;
        //   _rigidbody.useGravity = false;

    }
    // 중력
    void Gravity()
    {
        Vector3 GravityForce = (Physics.gravity * _playerstatus.status.Weight / 100)*2 - Physics.gravity;
        _rigidbody.AddForce(GravityForce);
    }
    class RayHItComparer : IComparer
    {
        public int Compare(object x, object y)
        {
            return ((RaycastHit)x).distance.CompareTo(((RaycastHit)y).distance);
        }
    }

}

