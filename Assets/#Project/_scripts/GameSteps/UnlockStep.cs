using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;
using VRTK.UnityEventHelper;

public class UnlockStep : GameStep {
    public VRTK_SnapDropZone_UnityEvents events;
    public TextPrompt _prompt;
    [Space(25)]
    public bool autoskip;

    private string msg1 = "\"Good.\"";
    private string msg2 = "\"There's a panel on the wall they can now unlock.\"";
    private string msg3 = "\"Guide them to the lock.\"";

    public override void StartStep() {
        events.OnObjectSnappedToDropZone.AddListener(OnUnlock);

        ShowMsg1();

        if(autoskip)
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

    private void OnUnlock(object arg0, SnapDropZoneEventArgs snapDropZoneEventArgs) {
        ClearAndNext();
    }

    private void ClearAndNext() {
        _prompt.Clear();
        Next();
    }
}
