using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour {
    public ScreenMessageManagerGame screenMessageManager;
    public ScreenMessage[] messages;

    

    void Start()
    {
        screenMessageManager = ScreenMessageManagerGame.instance;
    }

    void Messages()
    {
        foreach (ScreenMessage s in messages)
        {
            screenMessageManager.ShowMessage(s);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
        {
            InvokeRepeating("Messages", 0, 1);
            screenMessageManager.gameObject.transform.GetChild(0).gameObject.SetActive(true);
            Destroy(this.gameObject);
        }
    }
}
