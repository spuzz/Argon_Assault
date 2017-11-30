using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour {

    [Tooltip("in ms^-1")][SerializeField] float xSpeed = 4f;
    float xOffset;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        float xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        xOffset = (xThrow * xSpeed) * Time.deltaTime;
        print(Time.deltaTime);
	}
}
