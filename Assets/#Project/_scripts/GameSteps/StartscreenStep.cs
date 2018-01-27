using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR;

public class StartscreenStep : GameStep
{
    public GameObject _titleScreen;
    public Text _startPrompt;

    public override void StartStep() {
        SetupScene();
        StartCoroutine(WaitForUsers());
    }

    private void SetupScene() {
        _titleScreen.SetActive(true);
        _startPrompt.text = "press space to start";
    }

    IEnumerator WaitForUsers() {
        bool pcReady = false;
        bool vrReady = false;

        while (!pcReady || !vrReady) {
            if (Input.GetKeyDown(KeyCode.Space) && !pcReady) {
                pcReady = true;
                Debug.Log("yup " + vrReady);
                if(!vrReady)
                    _startPrompt.text = "waiting for VR player...";
            }

            if (XRDevice.userPresence == UserPresenceState.Present) {
                vrReady = true;
            }

            yield return null;
        }

        _titleScreen.SetActive(false);

        Debug.Log("GAME START");
        Next();
    }
}
