﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitGame : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Application.Quit();
    }
}
