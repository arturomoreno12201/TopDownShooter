using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuletDamage : MonoBehaviour
{

    public float TimeBetweenD;
    public int Damage = 20;

    EnemyHealth EnemyH;
    Transform target;
    bool enemyinRang;
    float timer;

    
    // Use this for initialization
    void Start () 
    {
        target = EnemyManager.instance.Enemy.transform;
	}

	private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject)
        {



        }
    }

	// Update is called once per frame
	void Update () {
		
	}
}
