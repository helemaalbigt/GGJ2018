using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BottomScreenPrompt : GameStep
{
    public enum NextMethod
    {
        confirmation,
        wait,
        noWait,
        nextStep
    }

    [Space(15)]
    public string message;
    public GameObject _bottomScreenPrompt;
    public Text _text;
    public GameObject _nextPrompt;
    public NextMethod _nextMethod;

    private bool _nextStepDone;

    public override void StartStep() {
        if (_nextMethod == NextMethod.nextStep) {
            nextStep.onActionComplete += () => _nextStepDone = true;
        }

        StartCoroutine(ShowPrompt());
    }

    IEnumerator ShowPrompt() {
        if (_text != null) {
            _bottomScreenPrompt.SetActive(true);
            _nextPrompt.SetActive(false);
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
        }

        switch (_nextMethod) {
            case NextMethod.confirmation:
                _nextPrompt.SetActive(true);
                while (!Input.GetKeyDown(KeyCode.Space)) {
                    yield return null;
                }
                break;

            case NextMethod.wait:
                yield return new WaitForSeconds(2f);
                break;

            case NextMethod.noWait:
                break;

            case NextMethod.nextStep:
                while (!_nextStepDone) {
                    yield return null;
                }
                break;
        }

        _bottomScreenPrompt.SetActive(false);
        yield return null;
        Next();
    }
}
