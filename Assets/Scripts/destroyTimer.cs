using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyTimer : MonoBehaviour {

    public float time;
    public float timer = 1;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
       
        if (time <= 0)
        {
            Destroy(gameObject);
            time = 1 / timer;
        }

        time -= Time.deltaTime;
    }
}
