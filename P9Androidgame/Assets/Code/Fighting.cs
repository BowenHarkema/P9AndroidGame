using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fighting : MonoBehaviour {

    private Vector2 _TouchStartPos;
    private Vector2 _TouchEndPos;

	void Update ()
    {
        if (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                _TouchStartPos = touch.position;
                _TouchEndPos = touch.position;
            }
            else if (touch.phase == TouchPhase.Moved)
            {
                _TouchEndPos = touch.position;
            }
            else if (touch.phase == TouchPhase.Ended)
            {
                _TouchEndPos = touch.position;

                if (Mathf.Abs(_TouchEndPos.x - _TouchStartPos.x) > Mathf.Abs(_TouchEndPos.y - _TouchStartPos.y))
                {
                    if (_TouchEndPos.x > _TouchStartPos.x)
                    {
                        Debug.Log("swipe right");
                    }
                }
                else
                {
                    if (_TouchEndPos.y > _TouchStartPos.y)
                    {
                        Debug.Log("swipe Up");
                    }

                    if (_TouchEndPos.y < _TouchStartPos.y)
                    {
                        Debug.Log("swipe down");
                    }
                }
            }
        }
    }
}
