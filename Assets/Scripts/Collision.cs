using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour 
{

   public GameObject ragdoll;
	// Use this for initialization
	void Start () 
    {
		
	}
	
	// Update is called once per frame
	void Update () 
    {

		
	}

  

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Bala"))
        {
            Instantiate(ragdoll,this.transform.position,Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
