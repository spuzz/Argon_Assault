using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour {

    [Tooltip("In seconds")][SerializeField] float levelLoadDelay = 1f;
    [Tooltip("FX prefab on player")] [SerializeField] GameObject deathFX;
    private void OnTriggerEnter(Collider other)
    {
        StartDeathSequence();
    }

    private void StartDeathSequence()
    {
        deathFX.SetActive(true);
        SendMessage("OnPlayerDeath");
        Invoke("RestartLevel", levelLoadDelay);
    }

    private void RestartLevel()
    {
        SceneManager.LoadScene(1);
    }
}
