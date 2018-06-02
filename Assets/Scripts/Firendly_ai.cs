using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Firendly_ai : MonoBehaviour
{


    public float lookro;

    NavMeshAgent nav;
    Transform target;

	// Use this for initialization
	void Start () {
        nav = GetComponent<NavMeshAgent>();
        target = PlayerManager.instance.Player.transform;
	}
	
	// Update is called once per frame
	void Update ()
    {
        float dis = Vector3.Distance(target.position, transform.position);

        if (dis <= lookro)
        {
            nav.SetDestination(target.position);
            if (dis <= nav.stoppingDistance)
            {
                LookAtPlayer();
            }
        }
	}
    void LookAtPlayer()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookro);
    }
}
