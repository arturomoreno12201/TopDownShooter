using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour {

    public Player playerHealth;
    public float restartDelay = 5f;
    
    float restartTimer;
    Animator anim;
	// Use this for initialization
	void Start () {
        
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update ()
    {

        if (playerHealth.currentHealth <= 0)
        {
            anim.SetTrigger("Dead");

            restartTimer += Time.deltaTime;

            if (restartTimer >= restartDelay)
            {
               SceneManager.LoadScene("SampleScene");
            }
        }

	}
}
