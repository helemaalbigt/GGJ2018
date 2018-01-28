using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuseStep : GameStep
{
    public GameStep failStep;

    public override void StartStep() {
        Invoke("Next", 2f);
    }
}
