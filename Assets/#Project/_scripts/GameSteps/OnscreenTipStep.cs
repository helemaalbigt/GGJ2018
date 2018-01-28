using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnscreenTipStep : GameStep {
    [Space(15)]
    public Text _title;
    public Text _startPrompt;
    public GameObject _collabTip;

    public override void StartStep() {
        SetupScript();
        StartCoroutine(ShowPrompt());
    }

    private void SetupScript() {
        _title.gameObject.SetActive(false);
        _startPrompt.gameObject.SetActive(false);
        _collabTip.gameObject.SetActive(false);
    }

    IEnumerator ShowPrompt(){
        yield return new WaitForSeconds(1f);

        _collabTip.gameObject.SetActive(true);

        while (!Input.GetKeyDown(KeyCode.Space)) {
            yield return null;
        }

        Next();
    }
}
