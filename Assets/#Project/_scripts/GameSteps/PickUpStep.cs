using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;
using VRTK.UnityEventHelper;

public class PickUpStep : GameStep
{
    public VRTK_InteractableObject_UnityEvents events;
    public TextPrompt _prompt;
    [Space(25)]
    public bool autoskip;

    private string msg1 = "\"It's too dark for them to see...\"";
    private string msg2 = "\"So you'll have to be their eyes.\"";
    private string msg3 = "\"We dropped a key by the door - guide them to it.\"";

    public override void StartStep() {
        events.OnGrab.AddListener(OnGrab);
        ShowMsg1();

        if (autoskip)
            Invoke("ClearAndNext", 10f);
    }

    private void ShowMsg1() {
        _prompt.ShowText(msg1, ShowMsg2);
    }

    private void ShowMsg2() {
        _prompt.ShowText(msg2, ShowMsg3);
    }

    private void ShowMsg3() {
        _prompt.ShowText(msg3, 5f);
    }

    private void OnGrab(object arg0, InteractableObjectEventArgs interactableObjectEventArgs) {
        ClearAndNext();
    }

    private void ClearAndNext() {
        Debug.Log("CLEAR");
        _prompt.Clear();
        Next();
    }
}
