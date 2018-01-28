using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuccessMessageStep : GameStep {
    [Space(25)]
    public TextPrompt _prompt;
    private string msg1 = "\"They made it.\"";

    public override void StartStep() {
        ShowMsg1();
        Invoke("OpenDoor", 4);
        Invoke("TeleportPlayerOutside",9);
    }

    private void ShowMsg1() {
        _prompt.ShowText(msg1,5f);
    }

    private void OpenDoor() {

    }

    private void TeleportPlayerOutside() {
        
        Next();
    }
}
