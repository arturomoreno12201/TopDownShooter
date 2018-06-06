using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriendsDamage : MonoBehaviour {

    public float TimeBetweenAttacks;
    public int AttackDamage = 10;

    EnemyHealth enemyH;
    GameObject enemy;
    bool PlayerInRange;
    float timer;

  

    // Use this for initialization
    void Start()
    {
        enemy = GameObject.FindGameObjectWithTag("Enemy");
        enemyH = enemy.GetComponent<EnemyHealth>();
        
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject == enemy)
        {
            PlayerInRange = true;
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.gameObject == enemy)
        {
            PlayerInRange = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= TimeBetweenAttacks && PlayerInRange)
        {

            Attack();

        }

        if (enemyH.currentHealth <= 0)
        {
            Debug.Log("stop");
        }
    }


    public void Attack()
    {
        timer = 0;

        if (enemyH.currentHealth > 0)
        {
            enemyH.TakeDamage(AttackDamage);
        }

    }
}
