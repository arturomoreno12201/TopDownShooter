using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SpiterZombie : MonoBehaviour {

    public float Range;
    public string targetsTag = "Player";
    public Transform target;

    NavMeshAgent nav;

    // Use this for initialization
    void Start()
    {

        target = PlayerManager.instance.Player.transform;

        nav = GetComponent<NavMeshAgent>();
        InvokeRepeating("UpDateTarget",0,0.5f);
    }


    void UpDateTarget()
    {
        GameObject[] targets = GameObject.FindGameObjectsWithTag(targetsTag);
        float shortD = Mathf.Infinity;
        GameObject nearest = null;

        foreach (GameObject target in targets)
        {
            float distarget = Vector3.Distance(transform.position, target.transform.position);

            if (distarget < shortD)
            {
                shortD = distarget;
                nearest = target;
            }
        }
        if (nearest != null && shortD <= Range)
        {

            target = nearest.transform;

        }
        else
        {
            target = null;
        }
    }


    // Update is called once per frame
    void Update()
    {
        
        nav.SetDestination(target.position);

        if (target = null)
            return;

    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position, Range);
    }
}
