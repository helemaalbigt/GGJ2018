using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CeilingStep : GameStep
{
    [Space(25)]
    public KillerCollider ceilingCollider;
    public GameStep failStep;

    public override void StartStep() {
        ceilingCollider.collisionEvents.AddListener(OnCeilingKill);
    }

    private void OnCeilingKill() {
        failStep.StartStep();
    }
}
