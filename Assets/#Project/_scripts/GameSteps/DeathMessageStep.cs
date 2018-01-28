using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathMessageStep : GameStep {

    [Space(25)]
    public TextPrompt _prompt;
    private string msg1 = "\"They're dead.\"";
    private string msg2 = "\"What have you done...\"";

    public override void StartStep() {
        ShowMsg1();
    }

    private void ShowMsg1() {
        _prompt.ShowText(msg1, ShowMsg2);
    }

    private void ShowMsg2() {
        _prompt.ShowText(msg2, Next);
    }
}
