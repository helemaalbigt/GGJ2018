using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearMessageStep : GameStep {
    [Space(15)]
    public TextPrompt _prompt;

    public override void StartStep() {
        _prompt.Clear();
        Next();
    }
}
