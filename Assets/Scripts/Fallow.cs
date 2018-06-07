using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fallow : MonoBehaviour {

    public float speedx;
    public float yOffset;
    public float speedz;
     Transform target;

    public float rspeed;
    public bool clockwRotate;

    float timer = 0;

    // Use this for initialization
    void Start()
    {
        target = PlayerManager.instance.Player.transform;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime * rspeed;
        Rotation();
        transform.LookAt(target);
    }

    void Rotation()
    {
        if (clockwRotate)
        {
            float x = -Mathf.Cos(timer) * speedx;
            float z = Mathf.Sin(timer) * speedz;
            Vector3 pos = new Vector3(x, yOffset, z);
            transform.position = pos + target.position;
        }
        else
        {
            float x = Mathf.Cos(timer) * speedx;
            float z = Mathf.Sin(timer) * speedz;
            Vector3 pos = new Vector3(x, yOffset, z);
            transform.position = pos + target.position;
        }
    }
}
