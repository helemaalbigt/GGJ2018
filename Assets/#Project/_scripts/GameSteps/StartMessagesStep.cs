using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class StartMessagesStep : GameStep
{
    [Space(15)]
    public TextPrompt _prompt;

    private string msg1 = "\"This has gone on long enough.\"";
    private string msg2 = "\"You watch these prisoners every day\"";
    private string msg3 = "\"Now you're going to help me get them out.\"";
    private string msg4 = "\"Starting with this one.\"";

    public override void StartStep() {
        ShowMsg1();
    }

    private void ShowMsg1() {
        _prompt.ShowText(msg1, ShowMsg2);
    }

    private void ShowMsg2() {
        _prompt.ShowText(msg2, ShowMsg3);
    }

    private void ShowMsg3() {
        _prompt.ShowText(msg3, ShowMsg4);
    }

    private void ShowMsg4() {
        _prompt.ShowText(msg4);
        Next();
    }
}
