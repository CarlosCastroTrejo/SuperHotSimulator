using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class ScreenMessageManager : MonoBehaviour {
    Queue<ScreenMessage> messages;
    public Text screenMessageText;
    public Text flashingText;
    string blankText = "";
    string writingText;
    bool isBlinking = true;

    public static ScreenMessageManager instance;

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



     IEnumerator BlinkText()
    {
        //blink it forever. You can set a terminating condition depending upon your requirement. Here you can just set the isBlinking flag to false whenever you want the blinking to be stopped.
        while (isBlinking)
        {
            //set the Text's text to blank
            flashingText.text = blankText;
            //display blank text for 0.5 seconds
            yield return new WaitForSeconds(.5f);
            //display “I AM FLASHING TEXT” for the next 0.5 seconds
            flashingText.text = writingText;
            yield return new WaitForSeconds(.5f);
        }
    }

    IEnumerator Coroutine1() {
        while (true)
        {
            //Debug.Log("Coroutine1");
            if (messages.Count > 0)
            {
                if (messages.Count % 2 != 0)
                {
                    screenMessageText.fontStyle = FontStyle.Bold;
                    screenMessageText.font = (Font)Resources.Load("RobotoB"); 
                }
                else
                {
                    screenMessageText.fontStyle = FontStyle.Normal;
                    screenMessageText.font = (Font)Resources.Load("RobotoT"); 
                }
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
        screenMessageText = transform.Find("SUPER").GetComponent<Text>();
        flashingText = transform.Find("Click").GetComponent<Text>();
        flashingText.font = (Font)Resources.Load("RobotoT");
        writingText = flashingText.text;

        //screenMessageText = this.GetComponent<Text>();
        messages = new Queue<ScreenMessage>();
        StartCoroutine(Coroutine1());
        StartCoroutine(BlinkText());
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene("GameScene");
        }

    }

}

