using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FastZombie : MonoBehaviour {

    public float lookRaidius = 10f;
    public float Speed = 10f;

    Transform target;
    NavMeshAgent nav;

    

    // Use this for initialization
    void Start()
    {

        target = PlayerManager.instance.Player.transform;

        nav = GetComponent<NavMeshAgent>();

    }

    // Update is called once per frame
    void Update()
    {
        float dis = Vector3.Distance(target.position, transform.position);

        nav.SetDestination(target.position);

        if (dis <= lookRaidius)
        {
            nav.speed = Speed;
        }

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, lookRaidius);
    }
}
