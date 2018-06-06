using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PLayerHealthPickUp : MonoBehaviour {

    public int AddHealth = 7;
    Player playerH;
    GameObject player;

    // Use this for initialization
    void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        playerH = player.GetComponent<Player>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (playerH.currentHealth > 0)
            {
                playerH.GetHealth(AddHealth);
                Destroy(gameObject);
            }
        }
    }
}
