using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenMessageManagerGame : MonoBehaviour {
    Queue<ScreenMessage> messages;
    public Text screenMessageText;
    public Text sideNotes;

    public static ScreenMessageManagerGame instance;

    private void Awake()
    {
        if (instance == null) instance = this;
    }

    public void ShowMessage(string s, float t) {
        ScreenMessage sm = new ScreenMessage(s, t);
        messages.Enqueue(sm);
    }

    public void ShowMessage(ScreenMessage s)
    {
        messages.Enqueue(s);
    }

    IEnumerator Coroutine1() {
        while (true)
        {
            //Debug.Log("Coroutine1");
            if (messages.Count > 0)
            {
                ScreenMessage sm = messages.Dequeue();
                //Debug.Log(sm.GetMessage());
                screenMessageText.text = sm.GetMessage();
                SoundManager.instance.PlaySound(sm.GetMessage());
                yield return new WaitForSecondsRealtime(sm.GetTime());
            }
            else {
                screenMessageText.text = "";
                yield return null;
            }
            //yield return null;
            //yield return new WaitForSeconds(1);
            //yield return new WaitForSecondsRealtime(1);
        }
    }

	// Use this for initialization
	void Start () {
        screenMessageText = transform.Find("Text").GetComponent<Text>();
        screenMessageText = transform.Find("Notes").GetComponent<Text>();
        //screenMessageText = this.GetComponent<Text>();
        messages = new Queue<ScreenMessage>();
        StartCoroutine(Coroutine1());
    }
	
}
