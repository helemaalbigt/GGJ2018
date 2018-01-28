using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class SuccessLastMessage : GameStep {
    [Space(25)]
    public TextPrompt _prompt;
    public VRTK_Lever lever;
    private string msg1 = "\"They'll know what to do next.\"";

    private bool leverThrown;

    public override void StartStep() {
        lever.ValueChanged += OnLeverPulled;

        ShowMsg1();
    }

    private void ShowMsg1() {
        _prompt.ShowText(msg1, 5f);
    }

    private void OnLeverPulled(object sender, Control3DEventArgs control3DEventArgs) {
        if (!leverThrown) {
            leverThrown = true;
            Next();
        }
    }
}
