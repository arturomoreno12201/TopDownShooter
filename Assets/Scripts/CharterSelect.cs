using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class CharterSelect : MonoBehaviour {

    List<GameObject> PlayerList;


    objectmanager obmg;

    private GameObject[] Charterlist;
    private int index=0;
    SceneManager current;

    // Use this for initialization
    void Start()
    {

        obmg = GetComponent<objectmanager>();

        Charterlist = new GameObject[transform.childCount];

        for (int i = 0; i < transform.childCount; i++)
        {
            Charterlist[i] = transform.GetChild(i).gameObject;

        }

        foreach (GameObject go in Charterlist)
        {
            go.SetActive(false);
        }

        if (Charterlist[index])
        {
            Charterlist[index].SetActive(true);
        }

    }


    public void leftArrow()
    {

        Charterlist[index].SetActive(false);

        index--;
        if (index < 0)
        {
            index = Charterlist.Length - 1;

        }

        Charterlist[index].SetActive(true);
    }

    public void rightArrow()
    {

        Charterlist[index].SetActive(false);

        index++;
        if (index == Charterlist.Length)
        {
            index = 0;

        }

        Charterlist[index].SetActive(true);
    }

    public void selectButtton()
    {
        DontDestroyOnLoad(transform.root.gameObject);
        obmg.index = this.index;
    }

    public void select(string LevelName)
    {
        SceneManager.LoadScene(LevelName);
    }
}
