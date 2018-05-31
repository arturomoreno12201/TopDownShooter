﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyHealth : MonoBehaviour {

    public int StartingHealth = 100;
    public int currentHealth;

    public float sink = 2.5f;

    bool isDead;
    bool isSinking;

    BoxCollider boxCol;

	// Use this for initialization
	void Start () {

        boxCol = GetComponent<BoxCollider>();
    currentHealth = StartingHealth;
    }
	
	// Update is called once per frame
	void Update ()
    {

        if (isSinking)
        {
            transform.Translate(-Vector3.up * sink * Time.deltaTime);
        }
		
	}

    public void takeDamage(int Amount, Vector3 hitpoint)
    {

        if (isDead)
            return;
        currentHealth -= Amount;

        if (currentHealth <= 0)
        {
            Death();
            Destroy(gameObject);
        }

    }

    void Death()
    {

        isDead = true;

        boxCol.isTrigger = true;

        

    }

    public void Sinking()
    {

        GetComponent<NavMeshAgent>().enabled = false;

        GetComponent<Rigidbody>().isKinematic = true;

        isSinking = true;

        Destroy(gameObject, 2f);

    }

}