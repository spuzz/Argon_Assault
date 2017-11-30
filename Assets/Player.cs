using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour {

    [Tooltip("in ms^-1")][SerializeField] float xSpeed = 6f;
    [Tooltip("in ms^-1")] [SerializeField] float ySpeed = 4f;
    [SerializeField] float positionPitchFactor = -5f;
    [SerializeField] float positionYawFactor = 5f;
    [SerializeField] float controlPitchFactor = -15f;
    [SerializeField] float controlRollFactor = -15f;
    float xOffset;
    float yOffset;
    float xThrow;
    float yThrow;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        ProcessTranslation();
        ProcessRotation();
    }

    private void ProcessRotation()
    {
        float pitch = transform.localPosition.y * positionPitchFactor + (yThrow * controlPitchFactor);
        float yaw = transform.localPosition.x * positionYawFactor;
        float roll = (yThrow * controlRollFactor); ;
        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }

    private void ProcessTranslation()
    {
        xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        xOffset = (xThrow * xSpeed) * Time.deltaTime;
        float rawNewXPos = transform.localPosition.x + xOffset;
        float xpos = Mathf.Clamp(rawNewXPos, -5.5f, 5.5f);

        yThrow = CrossPlatformInputManager.GetAxis("Vertical");
        yOffset = (yThrow * ySpeed) * Time.deltaTime;
        float rawNewYPos = transform.localPosition.y + yOffset;
        float ypos = Mathf.Clamp(rawNewYPos, -3f, 3f);

        transform.localPosition = new Vector3(xpos, ypos, transform.localPosition.z);
    }
}
