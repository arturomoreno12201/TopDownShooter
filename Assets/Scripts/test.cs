using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour {

    public int AttackDamage = 10;

    EnemyHealth enemyH;
    GameObject enemy;

    void Start()
    {
        enemy = GameObject.FindGameObjectWithTag("Enemy");
        enemyH = enemy.GetComponent<EnemyHealth>();

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            if (enemyH.currentHealth > 0)
            {
                enemyH.TakeDamage(AttackDamage);
            }
        }
    }
}
