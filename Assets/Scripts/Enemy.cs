using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	// Use this for initialization
	void Start () {
        AddNonTriggerBoxCollider();
        

    }

    private void AddNonTriggerBoxCollider()
    {
        Collider  collider = gameObject.AddComponent<BoxCollider>();
        collider.isTrigger = false;
    }

    private void OnParticleCollision(GameObject other)
    {
        Destroy(gameObject);
    }
    // Update is called once per frame
    void Update () {
		
	}
}
