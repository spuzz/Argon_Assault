﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour {

    // Use this for initialization
    void Start()
    {
        Invoke("LoadFirstScene", 2);
    }

    void LoadFirstScene()
    {
        SceneManager.LoadScene("Level 1");
    }
    // Update is called once per frame
    void Update () {
		
	}
}
