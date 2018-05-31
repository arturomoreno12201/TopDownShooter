using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SpiterZombie : MonoBehaviour {

    public Transform target;
    public float Range;
    public string targetsTag = "Player";

    public Transform Rpart;
    public float tSpeed = 5;

    NavMeshAgent nav;

    // Use this for initialization
    void Start()
    {
        InvokeRepeating("UpdateTarget", 0, 0.5f);
        target = PlayerManager.instance.Player.transform;

        nav = GetComponent<NavMeshAgent>();
        
    }


    void UpdateTarget()
    {
        GameObject[] targets = GameObject.FindGameObjectsWithTag("Player");
        float shortD = Mathf.Infinity;
        GameObject nearest = null;

        foreach (GameObject targe in targets)
        {
            float distarget = Vector3.Distance(transform.position, targe.transform.position);

            if (distarget < shortD)
            {
                shortD = distarget;
                nearest = targe;
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

        

        if (target == null)
            return;

        Vector3 dir = target.position - transform.position;
        Quaternion lookrot = Quaternion.LookRotation(dir);
        Vector3 rot = Quaternion.Lerp(Rpart.rotation, lookrot, Time.deltaTime * tSpeed).eulerAngles;
        Rpart.rotation = Quaternion.Euler(0f, rot.y, 0f);

    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position, Range);
    }
}
