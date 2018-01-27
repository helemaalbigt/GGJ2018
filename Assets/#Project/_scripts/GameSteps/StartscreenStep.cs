using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR;

public class StartscreenStep : GameStep
{
    public Text _title;
    public Text _startPrompt;
    public GameObject _collabTip;

    public override void StartStep() {
        SetupScene();
        StartCoroutine(WaitForUsers());
    }

    private void SetupScene() {
        _title.gameObject.SetActive(true);
        _startPrompt.gameObject.SetActive(true);
        _collabTip.gameObject.SetActive(false);

        _startPrompt.text = "press space to start";
    }

    IEnumerator WaitForUsers() {
        bool pcReady = false;
        bool vrReady = false;

        while (!pcReady || !vrReady) {
            if (Input.GetKeyDown(KeyCode.Space) && !pcReady) {
                pcReady = true;
                if(!vrReady)
                    _startPrompt.text = "waiting for VR player...";
            }

            if (XRDevice.userPresence == UserPresenceState.Present) {
                vrReady = true;
            }

            yield return null;
        }

        Next();
    }
}
