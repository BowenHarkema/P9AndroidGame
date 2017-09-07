using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fighting : MonoBehaviour {

    private Vector2 _TouchStartPos;
    private Vector2 _TouchEndPos;
    private float _DragDistanceH, _DragDistanceW;

    private float _RageMeter;

    private void Start()
    {
        Debug.Log("Activated");
        _DragDistanceH = Screen.height * 15 / 100;
        _DragDistanceW = Screen.width * 20 / 100;

    }

    void Update ()
    {

       // Debug.Log("distance " + Mathf.Abs(_TouchEndPos.x - _TouchStartPos.x));
        Debug.Log("Screen % " + Screen.width * 30 / 100);

        if (Input.touchCount == 1)
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

                if (Mathf.Abs(_TouchEndPos.x - _TouchStartPos.x) > _DragDistanceW || Mathf.Abs(_TouchEndPos.y - _TouchStartPos.y) > _DragDistanceH)
                {
                    Debug.Log("Swipe");

                    if (Mathf.Abs(_TouchEndPos.x - _TouchStartPos.x) > Mathf.Abs(_TouchEndPos.y - _TouchStartPos.y))
                    {
                        if (_TouchEndPos.x > _TouchStartPos.x)
                        {
                            gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.right * 500);
                        }
                    }
                    else
                    {
                        if (_TouchEndPos.y > _TouchStartPos.y)
                        {
                            gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 500);
                        }

                        if (_TouchEndPos.y < _TouchStartPos.y)
                        {
                            Debug.Log("swipe down");
                        }
                    }
                }
                else
                {
                    Debug.Log("Tap");
                }
            }
        }
    }
}
