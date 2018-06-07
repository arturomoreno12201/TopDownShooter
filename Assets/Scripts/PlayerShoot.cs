using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour {

    public int DamageShoot = 20;
    public float TimeBetweenShots = 0.15f;
    public float range = 100;

    
    Ray ShootRay;
    RaycastHit Shoothit;
    int shootMask;
    float timer;

   public LineRenderer BuletTrail;
    float effectsDisplayTime = 0.2f;


    // Use this for initialization
    void Start ()
    {

        shootMask = LayerMask.GetMask("Shootable");

        BuletTrail = GetComponent<LineRenderer>();
		
	}
	
	// Update is called once per frame
	void Update ()
    {

        timer += Time.deltaTime;

        if (Input.GetButton("Fire1") && timer >= TimeBetweenShots)
        {

            Shoot();

        }

        if (timer >= TimeBetweenShots * effectsDisplayTime)
        {

            DisableEffect();

        }
	}

    public void DisableEffect()
    {

        BuletTrail.enabled = false;
        
    }

    void Shoot()
    {

        timer = 0;

        BuletTrail.enabled = true;
        BuletTrail.SetPosition(0, transform.position);
        

        ShootRay.origin = transform.position;
        ShootRay.direction = transform.forward;

        if (Physics.Raycast(ShootRay, out Shoothit, range, shootMask))
        {

            EnemyHealth enemyHealth = Shoothit.collider.GetComponent<EnemyHealth>();

            if (enemyHealth != null)
            {
                enemyHealth.takeDamage(DamageShoot, Shoothit.point);
            }

        }

        else
        {
            BuletTrail.SetPosition(1, ShootRay.origin + ShootRay.direction * range);
        }

    }
}
