using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class SuccessMessageStep : GameStep {
    [Space(25)]
    public TextPrompt _prompt;
    public PushAction _openDoor;
    public TeleportPrisoner _teleport;
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
        _openDoor.Push();
    }

    private void TeleportPlayerOutside() {
        _teleport.Teleport();
        Next();
    }
}
