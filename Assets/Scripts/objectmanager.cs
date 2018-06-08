using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectmanager : MonoBehaviour {

    public Transform SpawnPoint;

    public GameObject[] newThing;
  
    public string[] stuff;

    string thing = "Holder";
    GameObject things;
    GameObject stuffs;
   
    int index;
   


    // Use this for initialization
    void Start () {

        index =     

        things = GameObject.FindGameObjectWithTag(thing);
        stuffs = GameObject.Find(stuff[index]);
     
	}
	
	// Update is called once per frame
	void Update () {
        //things.transform.Rotate(0, 100 * Time.deltaTime, 0);
       
         Destroy(GameObject.FindGameObjectWithTag(thing));
        HiFriend();
       
	}

    void HiFriend()
    {
        if (GameObject.Find(stuff[index]))
        {
            Instantiate(newThing[3], SpawnPoint.position, SpawnPoint.rotation);
           
        }
    }
}
