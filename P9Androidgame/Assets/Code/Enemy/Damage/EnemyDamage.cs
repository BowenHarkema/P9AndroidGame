using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour {

    [SerializeField]
    private float _PushForce;

    [SerializeField]
    private GameObject _EnemyBody;

    private void Start()
    {
        _EnemyBody = transform.parent.gameObject;
    }

    private void OnTriggerEnter2D(Collider2D other)
    { 
        if (other.transform.tag == "Player")
        {
            other.GetComponent<Health>()._Health -= 1;
            other.GetComponent<Rigidbody2D>().AddForce(-Vector2.right * 2000);
            //other.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 100);

            _EnemyBody.GetComponent<Rigidbody2D>().AddForce(Vector2.right * 10000 / 2);
            //_EnemyBody.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 100);
        }
    }
}
