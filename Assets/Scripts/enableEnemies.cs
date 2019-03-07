using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class enableEnemies : MonoBehaviour {

    public static enableEnemies instance;
    GameObject[] enemies;

    // Use this for initialization
    private void Awake()
    {
        if (instance == null) instance = this;
        enemies = GameObject.FindGameObjectsWithTag("Enemy");

    }

    void Start()
    {
  

    }

    // Update is called once per frame
    void Update()
    {
       
    }

   public void Activar()
    {

        for (int x = 0; x < enemies.Length; x++)
        {
            enemies[x].GetComponent<EnemyControl>().enabled = true;
            enemies[x].transform.GetChild(0).GetComponent<EnemyIK>().enabled = true;
            enemies[x].transform.GetChild(0).GetChild(2).gameObject.SetActive(true);

        }

    }

  
}
