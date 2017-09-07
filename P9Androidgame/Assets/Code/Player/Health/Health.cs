using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour {

    [SerializeField]
    public int _Health;

	void Update ()
    {
        if (_Health <= 0)
        {
            SceneManager.LoadScene("Game Over");
        }	
	}
}
