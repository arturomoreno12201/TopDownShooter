﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriendBullet : MonoBehaviour {

     Transform tar;
    public float speed;
    public GameObject splatter;

    public string Tags;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(Tags))
        {
            Destroy(gameObject);
            Instantiate(splatter, transform.position, transform.rotation);
        }
    }
    public void Seek(Transform _target)
    {

        tar = _target;

    }

    // Update is called once per frame
    void Update()
    {
        if (tar == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = tar.position - transform.position;
        float disthisFrame = speed * Time.deltaTime;

        if (dir.magnitude <= disthisFrame)
        {

            //HitTarget();
            return;

        }
        transform.Translate(dir.normalized * disthisFrame, Space.World);
    }


}
