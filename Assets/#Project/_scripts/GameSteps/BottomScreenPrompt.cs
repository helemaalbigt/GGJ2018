using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BottomScreenPrompt : GameStep
{
    [Space(15)]
    public string message;
    public GameObject _bottomScreenPrompt;
    public Text _text;
    public GameObject _nextPrompt;

    public override void StartStep() {
        StartCoroutine(ShowPrompt());
    }

    IEnumerator ShowPrompt() {
        _text.text = "";
        for(int i = 0; i < message.Length; i++) {
            _text.text += message[i];
            yield return new WaitForSeconds(.1f);
        }

        while (!Input.GetKeyDown(KeyCode.Space)) {
            yield return null;
        }

        Next();
    }
}
