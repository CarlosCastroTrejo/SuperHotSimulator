using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour {

	// Use this for initialization
	void Start () {

      
    }
	
	// Update is called once per frame
	void Update () {
        float mouseX = Input.GetAxisRaw("Mouse X");
        float mouseY = Input.GetAxisRaw("Mouse Y");
        float vertical = Input.GetAxisRaw("Vertical");
        float horizontal= Input.GetAxisRaw("Horizontal");

        float targetScale = 0.1f;
        if (mouseX != 0 || mouseY != 0) targetScale = 0.3f;
        if (vertical != 0 || horizontal != 0) targetScale = 0.8f;

        Time.timeScale = Mathf.Lerp(Time.timeScale, targetScale, 0.05f);
        Time.fixedDeltaTime = 0.02f * Time.timeScale;
    }
}
