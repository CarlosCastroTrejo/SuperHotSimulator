using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessageSpot : MonoBehaviour {
    public ScreenMessageManager screenMessageManager;
    public ScreenMessage []messages;

    void SuperHotMessage()
    {
        foreach (ScreenMessage s in messages)
        {
            screenMessageManager.ShowMessage(s);
        }
    }


    void Start () {
        screenMessageManager = ScreenMessageManager.instance;
        InvokeRepeating("SuperHotMessage", 0,2);
    }

    // Update is called once per frame
    void Update () 
    {

       
    }
}
