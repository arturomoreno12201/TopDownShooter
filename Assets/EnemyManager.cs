using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour {

    #region

    public static EnemyManager instance;

    void Awake()
    {

        instance = this;
        
    }
    #endregion

    public GameObject Enemy;


}
