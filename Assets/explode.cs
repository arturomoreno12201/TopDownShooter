using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explode : MonoBehaviour {

    public int AttackDamage = 10;

    EnemyHealth enemyH;
    GameObject enemy;
   public BoxCollider box;

    void Start()
    {
        enemy = GameObject.FindGameObjectWithTag("Enemy");
        enemyH = enemy.GetComponent<EnemyHealth>();
        box = GetComponent<BoxCollider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            if (enemyH.currentHealth > 0)
            {
                box.size = new Vector3(5, 5, 5);
                enemyH.TakeDamage(AttackDamage);
            }
        }
    }
    private void OnTriggerStay(Collider other)
    {

    }
}
