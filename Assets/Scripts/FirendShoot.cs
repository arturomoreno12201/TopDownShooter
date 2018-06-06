using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirendShoot : MonoBehaviour {

    public Transform target;
    public float Range;
    public string targetsTag = "Enemy";
    public float firecount = 0;
    public float fireRate = 1;
    public float timer;
    public Transform Rpart;
    public float tSpeed = 5;

    UnityEngine.AI.NavMeshAgent nav;

    public GameObject Spit;
    public Transform firePoint;

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
            return;

        Vector3 dir = target.position - transform.position;
        Quaternion lookrot = Quaternion.LookRotation(dir);
        Vector3 rot = Quaternion.Lerp(Rpart.rotation, lookrot, Time.deltaTime * tSpeed).eulerAngles;
        Rpart.rotation = Quaternion.Euler(0f, rot.y, 0f);

        if (timer <= 0f)
        {

            shoot();
            timer = 1 / fireRate;
        }
        timer -= Time.deltaTime;
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
