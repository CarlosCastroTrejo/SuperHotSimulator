using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessageSpotGame : MonoBehaviour {
    public ScreenMessageManagerGame screenMessageManager;
    public ScreenMessage []messages;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            foreach (ScreenMessage s in messages) {
                screenMessageManager.ShowMessage(s);
            }   
            Destroy(this.gameObject);
        }
    }

    void Start () {
        screenMessageManager = ScreenMessageManagerGame.instance;
    }

    // Update is called once per frame
    void Update () {
		
	}
}
