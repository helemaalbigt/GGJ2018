using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextPrompt : MonoBehaviour {
    public GameObject _bottomScreenPrompt;
    public Text _text;
    public GameObject _nextPrompt;

    private bool _expectCallback;

    public void ShowText(String message) {
        _expectCallback = false;

        _bottomScreenPrompt.SetActive(true);
        _nextPrompt.SetActive(false);

        StartCoroutine(PrintMessage(message, ()=> {}));
    }

    public void ShowText(String message, float delay) {
        _expectCallback = false;

        _bottomScreenPrompt.SetActive(true);
        _nextPrompt.SetActive(false);

        StartCoroutine(PrintMessage(message, () => { }));

        Invoke("Clear", delay);
    }

    public void ShowText(String message, Action callback) {
        _expectCallback = true;

        _bottomScreenPrompt.SetActive(true);
        _nextPrompt.SetActive(false);

        StartCoroutine(PrintMessage(message, callback));
    }

    IEnumerator PrintMessage(string message, Action callback) {
        _text.text = "";

        for (int i = 0; i < message.Length; i++) {
            if (Input.GetKeyDown(KeyCode.Space)) {
                _text.text = message;
            } else {
                _text.text += message[i];
                yield return null;
            }
        }

        yield return null;

        if (_expectCallback) {
            _nextPrompt.SetActive(true);
            while (!Input.GetKeyDown(KeyCode.Space)) {
                yield return null;
            }

            yield return null;
            yield return null;

            Clear();
            callback();
        }
    }

    public void Clear() {
        StopAllCoroutines();
        _text.text = "";
        _bottomScreenPrompt.SetActive(false);
        _nextPrompt.SetActive(false);
    }
}
