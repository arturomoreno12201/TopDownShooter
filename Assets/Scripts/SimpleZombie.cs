using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SimpleZombie : MonoBehaviour
{

    Transform target;

    NavMeshAgent nav;

	// Use this for initialization
	void Start ()
    {

        target = PlayerManager.instance.Player.transform;

        nav = GetComponent<NavMeshAgent>();  

	}
	
	// Update is called once per frame
	void Update () {

        nav.SetDestination(target.position);
		
	}
}
