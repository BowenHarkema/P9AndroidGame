using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    [SerializeField]
    private Transform _PlayerTarget;

    [SerializeField]
    private float _FollowDelay;

	void FixedUpdate ()
    {
        float selfx = transform.position.x;
        float targetx = _PlayerTarget.transform.position.x;

        float selfy = transform.position.y;
        float targety = _PlayerTarget.transform.position.y;

        gameObject.transform.position = new Vector3(Mathf.Lerp(selfx, targetx, _FollowDelay), Mathf.Lerp(selfy, targety + 4, _FollowDelay), _PlayerTarget.transform.position.z - 10f);
	}
}
