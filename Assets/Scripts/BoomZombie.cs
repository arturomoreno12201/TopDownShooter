using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BoomZombie : MonoBehaviour {

    public float lookRaidius = 10f;
    public float Speed = 10f;
    public int damage = 50;

    Player health;
    Transform target;
    NavMeshAgent nav;



    // Use this for initialization
    void Start()
    {

        target = PlayerManager.instance.Player.transform;

        health = GetComponent<Player>();
      
        nav = GetComponent<NavMeshAgent>();

    }

    // Update is called once per frame
    void Update()
    {
        float dis = Vector3.Distance(target.position, transform.position);

        nav.SetDestination(target.position);

        if (dis <= lookRaidius)
        {
            nav.speed = 5;

            Collider[] objectDamaged = Physics.OverlapSphere(transform.position, lookRaidius);
            for (int i = 0; i < objectDamaged.Length; i++)
            {
                objectDamaged[i].GetComponent<Player>().startingHealth -= damage;
            }
            Destroy(gameObject);
        }

    }

    public void Attack()
    {
        

        if (health.currentHealth > 0)
        {
            health.TakeDamage(damage);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, lookRaidius);
    }
}
