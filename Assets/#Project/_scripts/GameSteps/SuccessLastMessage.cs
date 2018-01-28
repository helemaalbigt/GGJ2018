using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuccessLastMessage : GameStep {
    [Space(25)]
    public TextPrompt _prompt;
    private string msg1 = "\"They'll know what to do next.\"";

    public override void StartStep() {


        ShowMsg1();
    }

    private void ShowMsg1() {
        _prompt.ShowText(msg1, 5f);
    }

    private void OnLeverPulled() {
        //TODO:First turn all screens white
        Next();
    }
}
