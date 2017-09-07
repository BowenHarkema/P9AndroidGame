using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementPlayer : MonoBehaviour {

    [SerializeField]
    private float _Speed, _MaxSpeed, _JumpSpeed;

    private bool _FaceRight = true;
    private bool _Jumping = false;
    private bool _Grounded = false;

    private Animator _Anim;
    private Rigidbody2D _RBody;

    [SerializeField]
    private Transform _GroundCheck;

    void Awake ()
    {
        _Anim = gameObject.GetComponent<Animator>();
        _RBody = gameObject.GetComponent<Rigidbody2D>();
	}
	
	void Update ()
    {
        _Grounded = Physics.Linecast(transform.position, _GroundCheck.position, 1 << LayerMask.NameToLayer("Ground"));

	}

    private void FixedUpdate()
    {
        float hinput = Input.GetAxis("Horizontal");
        if (hinput > 0 || hinput < 0)
        {
            _Anim.SetInteger("State", 1);
        }
        else if (hinput == 0)
        {
            _Anim.SetInteger("State", 0);
        }

        if (hinput * _RBody.velocity.x < _MaxSpeed)
        {
            _RBody.AddForce(Vector3.right * hinput * _Speed);
        }

        if (Mathf.Abs(_RBody.velocity.x) > _MaxSpeed)
        {
            _RBody.velocity = new Vector3(Mathf.Sign(_RBody.velocity.x) * _MaxSpeed, _RBody.velocity.y, 0);
        }

        if (_Jumping)
        {
            _Anim.SetInteger("State",2);
            _RBody.AddForce(new Vector3(0f, _JumpSpeed, 0f));
            _Jumping = false;
        }
    }

    public void SetValues(float newspeed, float newjumpforce, float newmaxspeed)
    {
        _Speed = newspeed;
        _JumpSpeed = newjumpforce;
        _MaxSpeed = newmaxspeed;
    }
}
