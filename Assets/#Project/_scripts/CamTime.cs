using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode]
public class CamTime : MonoBehaviour
{
    public Text _text;

	void Update () {
	    _text.text = "11-10-84 " + IntToTwoDigitString(DateTime.Now.Hour) + ":" + IntToTwoDigitString(DateTime.Now.Minute) +
	                ":" + IntToTwoDigitString(DateTime.Now.Second);
	}

    private string IntToTwoDigitString(int value) {
        return (value < 10) ? "0" + value : value.ToString();
    }
}
