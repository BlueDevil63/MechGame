using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {

    public bool onGround;
    public bool onBoost;


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
        if (!(x == 0 && z == 0))
        {
            _transform.Translate(Vector3.forward * _playerstatus.status.velocity * z * Time.deltaTime, Space.Self);
            _transform.Translate(Vector3.right * _playerstatus.status.velocity * x * Time.deltaTime, Space.Self);
            _animator.SetBool("run", true);
        }
        else
        {
            _animator.SetBool("run", false);
        }
    }
   public void Avoidance()
    {

    }
    public void BoostMove(float x, float z, bool on)
    {
        if (on == true)
        {
            if (x == 0 && z == 0)
            {
                _playerstatus.booster.SetActive(true);
                onBoost = true;
            }
            else
            {
                _transform.Translate(Vector3.right * _playerstatus.status.boostVelocity * x * Time.deltaTime, Space.Self);
                _transform.Translate(Vector3.forward * _playerstatus.status.boostVelocity * z * Time.deltaTime, Space.Self);
                _playerstatus.booster.SetActive(true);
                onBoost = true;
            }
        }
        else
        {
            onBoost = false;
            _playerstatus.booster.SetActive(false);
        }

    }
   public  void GunAttack()
    {

    }
   public void Melee()
    {

    }
  public  void Hook()
    {

    }
   public  void WallClimb()
    {

    }

    //  지면에 닿았는지
   public void GroundCheck()
    {
        velocity = _rigidbody.velocity;
        Ray ray = new Ray(transform.position + Vector3.up * 0.1f, -Vector3.up);

        RaycastHit[] hits = Physics.RaycastAll(ray, 0.1f);
        rayHitComparer = new RayHItComparer();
        System.Array.Sort(hits, rayHitComparer);

       if (velocity.y < _playerstatus.status.jumpPower * 0.5f)
        {
            onGround = false;
            _rigidbody.useGravity = true;


            foreach (var hit in hits)
            {
                if(!hit.collider.isTrigger)
                {
                    if(velocity.y <= 0)
                    {
                        _rigidbody.position = Vector3.MoveTowards(_rigidbody.position, hit.point, Time.deltaTime * 100); 
                    }

                    onGround = true;
                    _rigidbody.useGravity = false;
                }
            }
            Debug.Log(_rigidbody.useGravity);
        }
    }
    // 중력
    void Gravity()
    {
        _rigidbody.mass *= (_playerstatus.status.Weight/10);
    }

    class RayHItComparer : IComparer
    {
        public int Compare(object x, object y)
        {
            return ((RaycastHit)x).distance.CompareTo(((RaycastHit)y).distance);
        }
    }

}

