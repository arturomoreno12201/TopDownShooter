using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirendShoot : MonoBehaviour {

    UnityEngine.AI.NavMeshAgent nav;
    private EnemyHealth targetEnemy;

    

    [Header ("bullet and shoot things")]
    public Transform target;
    public float Range;
    public string targetsTag = "Enemy";
    public float firecount = 0;
    public float fireRate = 1;
    public float timer;
    public Transform Rpart;
    public float tSpeed = 5;
    public GameObject Spit;
    public Transform firePoint;

    [Header("Laser")]
    public bool useLaser = false;
    public int damageOverTime = 30;
    public float slowAmount = .5f;
    public LineRenderer lineRenderer;
    public ParticleSystem impactEffect;
    public Light impactLight;



    // Use this for initialization
    void Start()
    {
        InvokeRepeating("UpdateTarget", 0, 0.5f);
        target = PlayerManager.instance.Player.transform;

        nav = GetComponent<UnityEngine.AI.NavMeshAgent>();

    }


    void UpdateTarget()
    {
        GameObject[] targets = GameObject.FindGameObjectsWithTag(targetsTag);
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
        {
            if (useLaser)
            {
                if (lineRenderer.enabled)
                {
                    lineRenderer.enabled = false;
                    impactEffect.Stop();
                    impactLight.enabled = false;
                }
            }

            return;
        }

        lookAtTarget();
        if (useLaser)
        {
            Laser();
        }
        else
        {
            if (timer <= 0f)
            {

                shoot();
                timer = 1 / fireRate;
            }
            timer -= Time.deltaTime;
        }
    }

    void LockOnTarget()
    {
        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(Rpart.rotation, lookRotation, Time.deltaTime * tSpeed).eulerAngles;
        Rpart.rotation = Quaternion.Euler(0f, rotation.y, 0f);
    }
    void lookAtTarget()
    {
        Vector3 dir = target.position - transform.position;
        Quaternion lookrot = Quaternion.LookRotation(dir);
        Vector3 rot = Quaternion.Lerp(Rpart.rotation, lookrot, Time.deltaTime * tSpeed).eulerAngles;
        Rpart.rotation = Quaternion.Euler(0f, rot.y, 0f);
    }
    void Laser()
    {
        targetEnemy.TakeDamage(damageOverTime);
        

        if (!lineRenderer.enabled)
        {
            lineRenderer.enabled = true;
            impactEffect.Play();
            impactLight.enabled = true;
        }

        lineRenderer.SetPosition(0, firePoint.position);
        lineRenderer.SetPosition(1, target.position);

        Vector3 dir = firePoint.position - target.position;

        impactEffect.transform.position = target.position + dir.normalized;

        impactEffect.transform.rotation = Quaternion.LookRotation(dir);
    }

    void shoot()
    {

        GameObject SpitGo = (GameObject)Instantiate(Spit, firePoint.position, firePoint.rotation);
        SpitBall spt = SpitGo.GetComponent<SpitBall>();

        if (spt != null)
            spt.Seek(target);

    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position, Range);
    }
}
