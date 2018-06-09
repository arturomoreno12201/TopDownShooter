using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectmanager : MonoBehaviour {

    public Transform SpawnPoint;

    public GameObject[] newThing;
  
    public string[] stuff ;

    string thing = "Holder";
    GameObject things;
    GameObject stuffs;
   
    public int index = 0;
    


    // Use this for initialization
    void Start () {

        
        things = GameObject.FindGameObjectWithTag(thing);
        stuffs = GameObject.Find(stuff[index]);
     
	}
	
	// Update is called once per frame
	void Update () {
        //things.transform.Rotate(0, 100 * Time.deltaTime, 0);


        if (SpawnPoint == null)
        {
            SpawnPoint = GameObject.FindGameObjectWithTag("SpawnPoint").transform;
        }
       
        HiFriend();
        
        
	}

    void HiFriend()
    {
        GameObject nipslip = GameObject.FindGameObjectWithTag("Holder");

        if (nipslip != null)
        {
            Instantiate(newThing[index], SpawnPoint.position, SpawnPoint.rotation);
            Destroy(nipslip);
        }
    }
}
