using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ScreenMessage{
    public string message;
    public float time;

    public ScreenMessage(string s, float t) {
        message = s;
        time = t;
    }

    public string GetMessage() {
        return message;
    }

    public float GetTime() {
        return time;
    }
}
