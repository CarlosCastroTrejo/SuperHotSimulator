using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enableGun : MonoBehaviour {

    // Use this for initialization
    public enableEnemies habilitar;
	void Start () {
        habilitar = enableEnemies.instance;
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {   
            other.transform.GetChild(0).GetChild(0).gameObject.SetActive(true);
            habilitar.Activar();
            Destroy(this.gameObject);
        }
    }
}
