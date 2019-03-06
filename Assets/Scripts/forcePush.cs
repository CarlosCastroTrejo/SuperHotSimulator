using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class forcePush : MonoBehaviour {

    public Rigidbody rb;
	// Use this for initialization
	void Start () {

        rb.AddRelativeForce(0,8000,0);

        Destroy(gameObject, 1);

    }



}
