using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementEnemy : MonoBehaviour {

    [SerializeField]
    private float _Speed, _MaxSpeed;

    private bool _Grounded = false;

    private Rigidbody2D _RBody;

    [SerializeField]
    private Transform _GroundCheck;

    void Awake()
    {
        _RBody = gameObject.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        _Grounded = Physics2D.Linecast(transform.position, _GroundCheck.position, -1 << LayerMask.NameToLayer("Ground"));
    }

    private void FixedUpdate()
    {
        float hinput = -1f;

        if (hinput * _RBody.velocity.x < _MaxSpeed)
        {
            _RBody.AddForce(Vector2.right * hinput * _Speed);
        }

        if (Mathf.Abs(_RBody.velocity.x) > _MaxSpeed)
        {
            _RBody.velocity = new Vector2(Mathf.Sign(_RBody.velocity.x) * _MaxSpeed, _RBody.velocity.y);
        }
    }
}
