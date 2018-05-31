using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{

    public float TimeBetweenAttacks;
    public int AttackDamage = 10 ;

    Player playerH;
    GameObject Player;
    bool PlayerInRange;
    float timer;

	// Use this for initialization
	void Start ()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        playerH = Player.GetComponent<Player>();
	}

	void OnTriggerEnter(Collider col)
    {
        if (col.gameObject == Player)
        {
            PlayerInRange = true;
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.gameObject == Player)
        {
            PlayerInRange = false;
        }
    }

	// Update is called once per frame
	void Update ()
    {
        timer += Time.deltaTime;

        if (timer >= TimeBetweenAttacks && PlayerInRange)
        {

            Attack();

        }

        if (playerH.currentHealth <= 0)
        {
            //Debug.Log("stop");
        }
	}
    

    public void Attack()
    {
        timer = 0;

        if (playerH.currentHealth > 0)
        {
            playerH.TakeDamage(AttackDamage);
        }
    }
}
