using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelLoader : MonoBehaviour
{
    [SerializeField]
    private Transform _Spawnpos;

    [SerializeField]
    private List<GameObject> _Scenes;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            Instantiate(_Scenes[0], _Spawnpos);
        }
    }
}
