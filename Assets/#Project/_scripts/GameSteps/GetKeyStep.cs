using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;
using VRTK.UnityEventHelper;

public class GetKeyStep : GameStep
{
    public VRTK_InteractableObject_UnityEvents events;

    public override void StartStep() {
        events.OnGrab.AddListener(OnGrab);

        Invoke("Next", 2f);
    }

    private void OnGrab(object arg0, InteractableObjectEventArgs interactableObjectEventArgs) {
        Next();
    }
}
