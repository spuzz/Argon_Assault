using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerController : MonoBehaviour {

    [Header("General")]
    [Tooltip("in ms^-1")][SerializeField] float xControlSpeed = 4f;
    [Tooltip("in ms^-1")] [SerializeField] float yControlSpeed = 4f;
    [Tooltip("in m")] [SerializeField] float xRange = 7f;
    [Tooltip("in m")] [SerializeField] float yRange = 4f;

    [Header("Screen-position Based")]
    [SerializeField] float positionPitchFactor = -5f;
    [SerializeField] float positionYawFactor = 5f;

    [Header("Control-Throw Based")]
    [SerializeField] float controlPitchFactor = -15f;
    [SerializeField] float controlRollFactor = -15f;

    float xOffset;
    float yOffset;
    float xThrow;
    float yThrow;

    bool isControlEnabled = true;
    // Update is called once per frame
    void Update ()
    {
        if(isControlEnabled == true)
        {
            ProcessTranslation();
            ProcessRotation();
        }

    }

    void OnPlayerDeath()
    {
        isControlEnabled = false;
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
        xOffset = (xThrow * xControlSpeed) * Time.deltaTime;
        float rawNewXPos = transform.localPosition.x + xOffset;
        float xpos = Mathf.Clamp(rawNewXPos, -xRange, xRange);

        yThrow = CrossPlatformInputManager.GetAxis("Vertical");
        yOffset = (yThrow * yControlSpeed) * Time.deltaTime;
        float rawNewYPos = transform.localPosition.y + yOffset;
        float ypos = Mathf.Clamp(rawNewYPos, -yRange, yRange);

        transform.localPosition = new Vector3(xpos, ypos, transform.localPosition.z);
    }
}
